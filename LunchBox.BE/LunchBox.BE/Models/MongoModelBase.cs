using System;

namespace LunchBox.BE.Models
{
    public class MongoModelBase
    {
        public string Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;
    }
}
