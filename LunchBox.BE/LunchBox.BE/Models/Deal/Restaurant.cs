using System.Collections.Generic;

namespace LunchBox.BE.Models.Deal
{
    public class Restaurant : MongoModelBase
    {
        public string about { get; set; }
        public AppLinks app_links { get; set; }
        public int checkins { get; set; }
        public Cover cover { get; set; }
        public string description { get; set; }
        public Engagement engagement { get; set; }
        public List<Hour> hours { get; set; }
        public bool is_permanently_closed { get; set; }
        public bool is_verified { get; set; }
        public string link { get; set; }
        public Location location { get; set; }
        public string name { get; set; }
        public Parking parking { get; set; }
        public PaymentOptions payment_options { get; set; }
        public string phone { get; set; }
        public string price_range { get; set; }
        public int rating_count { get; set; }
        public string single_line_address { get; set; }
        public string website { get; set; }
        public Picture picture { get; set; }
        public double? overall_star_rating { get; set; }
    }
}