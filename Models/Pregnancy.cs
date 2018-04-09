using System;

namespace Sheep.Site.Api.Models
{
    public class Pregnancy
    {
        public int pregnancyID { get; set; }
        public Animal Animal { get; set; }
        public string conceptionDate { get; set; }
        public string estBirth { get; set; }
        public string actBirth { get; set; }
        public int numberOfBabies { get; set; }
        public string pregnancyComment { get; set; }
    }
}
