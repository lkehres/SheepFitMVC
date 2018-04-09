using System;
using System.Collections.Generic;

namespace Sheep.Site.Api.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public DateTime sheepDOB { get; set; }
        public char sheepGender { get; set; }
        public List<Vaccine> vaccineNames { get; set; }
        public List<Treatment> treatmentNames { get; set; }
        public List<Pregnancy> pregnancyNames { get; set; }

    }
}
