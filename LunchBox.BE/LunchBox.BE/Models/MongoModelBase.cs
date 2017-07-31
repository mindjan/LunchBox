using System;

namespace HandyShop.BE.Models
{
    public class MongoModelBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;
    }
}
