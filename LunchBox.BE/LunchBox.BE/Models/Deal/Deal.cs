using System;
using System.Collections.Generic;
using MongoDB.Driver.GeoJsonObjectModel;

namespace LunchBox.BE.Models.Deal
{
    public class Deal : MongoModelBase
    {
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string RestourantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string time { get; set; }
    }

    public class Android
    {
        public string app_name { get; set; }
        public string package { get; set; }
        public string url { get; set; }
    }

    public class Io
    {
        public string app_name { get; set; }
        public string app_store_id { get; set; }
        public string url { get; set; }
    }

    public class AppLinks
    {
        public List<Android> android { get; set; }
        public List<Io> ios { get; set; }
    }

    public class Cover
    {
        public string cover_id { get; set; }
        public int offset_x { get; set; }
        public int offset_y { get; set; }
        public string source { get; set; }
        public string id { get; set; }
    }

    public class Engagement
    {
        public int count { get; set; }
        public string social_sentence { get; set; }
    }

    public class Hour
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Location
    {
        public string city { get; set; }
        public string country { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string street { get; set; }
        public string zip { get; set; }
        public string located_in { get; set; }
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> PointLocation { get; set; }
    }

    public class Parking
    {
        public int lot { get; set; }
        public int street { get; set; }
        public int valet { get; set; }
    }

    public class PaymentOptions
    {
        public int amex { get; set; }
        public int cash_only { get; set; }
        public int discover { get; set; }
        public int mastercard { get; set; }
        public int visa { get; set; }
    }

    public class Data
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Picture
    {
        public Data data { get; set; }
    }

    public class Datum2
    {
        public DateTime created_time { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }


    public class Cursors2
    {
        public string after { get; set; }
    }

    public class Paging
    {
        public Cursors2 cursors { get; set; }
        public string next { get; set; }
    }

    public class RootObject
    {
        public List<Restaurant> data { get; set; }
        public Paging paging { get; set; }
    }
}
