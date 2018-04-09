using System;

namespace Sheep.Site.Api.Models
{
    public class Vaccine
    {
        public int vaccineID { get; set; }
        public Animal Animal { get; set; }
        public string vaccineName { get; set; }
        public string vaccineDosage { get; set; }
        public DateTime vaccineDate { get; set; }
        public string vaccineComment { get; set; }
    }
}
