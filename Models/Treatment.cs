using System;

namespace Sheep.Site.Api.Models
{
    public class Treatment
    {
        public int treatmentID { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public string treatmentName { get; set; }
        public string treatmentDosage { get; set; }
        public DateTime treatmentDate { get; set; }
        public string treatmentComment { get; set; }
    }
}
