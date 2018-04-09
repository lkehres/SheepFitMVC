using System;

namespace Sheep.Site.Api.Models
{
    public class Vaccine
    {
        public int vaccineID { get; set; }
        public int vId { get; set; }
        // vId is the foreign key to SheepId for vaccines
        public string vaccineName { get; set; }
        public string vaccineDosage { get; set; }
        public DateTime vaccineDate { get; set; }
        public string vaccineComment { get; set; }
    }
}
