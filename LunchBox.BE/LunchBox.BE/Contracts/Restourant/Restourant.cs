using System.Collections.Generic;

namespace LunchBox.BE.Contracts.Restourant
{
    public class Restourant
    {
        public string Name { get; set; }
        public string LogoImageUrl { get; set; }
        public Models.Restourant.Address Address { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
    }
}
