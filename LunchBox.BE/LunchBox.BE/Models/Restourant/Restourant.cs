﻿using System.Collections.Generic;

namespace LunchBox.BE.Models.Restourant
{
    public class Restourant : MongoModelBase
    {
        public string Name { get; set; }
        public string LogoImageUrl { get; set; }
        public Address Address { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
    }
}
