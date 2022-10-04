using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TravelApi.Models
{
    public class Destination
    {
        [Required]
        public int DestinationId{get; set;}
        [Required]
        [StringLength(15 , ErrorMessage = "UserName must not be more than 15 characters")]
        public string Username{get; set;}
        [Required]
        public string Country{get; set;}
        [Required]
        public string City{get; set;}
        [Required]
        public string DestinationName{get; set;}
        public string Review{get; set;}
        public double OverallRating {get; set;}
    }
}