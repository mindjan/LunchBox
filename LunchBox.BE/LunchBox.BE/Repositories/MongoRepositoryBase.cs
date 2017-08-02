using System;
using System.Collections.Generic;
using System.Linq;
using LunchBox.BE.Models;
using MongoDB.Driver;

namespace LunchBox.BE.Repositories
{
    public class MongoRepositoryBase<T> where T : MongoModelBase
    {
    protected readonly IMongoCollection<T> Collection;
    private readonly string _collectionName;
//    private readonly ILog _logger;

    protected MongoRepositoryBase(string connectionString, string collectionName)
    {
        var mongoUrl = new MongoUrl(connectionString);
        IMongoClient client = new MongoClient(mongoUrl);
        var database = client.GetDatabase(mongoUrl.DatabaseName);
        _collectionName = collectionName;
        //_logger = LogManager.GetLogger(nameof(T), "MongoDb");
        Collection = database.GetCollection<T>(_collectionName);
    }

    public virtual void EnsureIndexes()
    {
    }

    protected void Insert(T entity)
    {
        try
        {
            entity.Id = Guid.NewGuid().ToString();
            Collection.InsertOne(entity);
        }
        catch (MongoWriteException ex)
        {
            if (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
//                _logger.Warn(new
//                {
//                    message = ex.Message,
//                    entity = entity
//                });
            }
            else
            {
//                _logger.Error($"Error Creating {_collectionName} exception message: { ex.Message}");
                throw;
            }
        }
    }


        protected void UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> definition)
    {
        try
        {
            Collection.UpdateMany(filter, definition);
        }
        catch (MongoWriteException ex)
        {
//            _logger.Error($"Error updating {_collectionName} exception message: { ex.Message}");
            throw;
        }
    }


        protected void Delete(FilterDefinition<T> filter)
        {
            Collection.DeleteOne(filter);
        }

        protected void InsertMany(IList<T> entities)
    {
        if (entities.Any())
        {
            try
            {
                Collection.InsertMany(entities);
            }
            catch (MongoWriteException ex)
            {
//                _logger.Error($"Error Creating {_collectionName} exception message: { ex.Message}");
                throw;
            }
        }
    }

    protected virtual T Upsert(FilterDefinition<T> filter, UpdateDefinition<T> definition)
    {
        T upsertedRecord;

        try
        {
            Collection.UpdateOne(filter, definition, new UpdateOptions { IsUpsert = true });
            upsertedRecord = GetOne(filter);
        }
        catch (MongoException ex)
        {
//            _logger.Error($"Error upserting {_collectionName} exception message: { ex.Message}");
            throw;
        }

        return upsertedRecord;
    }

    protected T GetOne(FilterDefinition<T> filter, FindOptions<T, T> options = null)
    {
        var result = Collection.FindSync<T>(filter, options).FirstOrDefault();

        return result;
    }

    protected List<T> GetMany(FilterDefinition<T> filter, FindOptions<T, T> options = null)
    {
        var result = Collection.FindSync<T>(filter, options).ToList();

        return result;
    }
    }
}
