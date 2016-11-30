using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Requests.Haunts
{
    public class HauntAddRequest
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }        
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }


    }
}