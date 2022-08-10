using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace BooksApi.Models
{
    public class Toy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Id")]
        [JsonProperty("Id")]
        public string ToyId {get; set;}

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string ToyName {get; set;}

        public string Category {get; set;}
        public string Description {get; set;}

        [BsonElement("Quantity")]
        [JsonProperty("Quantity")]
        public int QuantityAvailable  {get; set;}


        [BsonElement("DailyRental")]
        [JsonProperty("DailyRental")]
        public decimal DailyRentalCost {get; set;}
        

        [BsonElement("Replacement")]
        [JsonProperty("Replacement")]
        public decimal ReplacementCost {get; set;}
        
        [BsonIgnore]
        [JsonIgnore]
        private decimal _memberDiscount;

        [BsonElement("MemberDiscount")]
        [JsonProperty("MemberDiscount")]
        [RangeAttribute(0,.99)]
        public decimal MembershipDiscount {
            get { return _memberDiscount;}
            set {
                if (value < 0 || value >= 1) {
                    throw new ArgumentOutOfRangeException($"Error: {nameof(value)} must be decimal between 0 and 1.");
                } // sets value as percentage 
                _memberDiscount = value;
            }
        }
    }
}


