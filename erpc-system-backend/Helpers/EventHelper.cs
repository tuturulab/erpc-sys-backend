using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace erpc_system_backend.Helpers
{
    public class EventHelper 
    {
        [Required]
        public String title {get; set;}
        [Required]
        public DateTime? end { get; set; }
        [Required]
        public DateTime? start { get; set; }
        [Required]
        public String description {get; set;}
        
    
    }
}