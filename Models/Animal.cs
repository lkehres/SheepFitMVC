using System;
using System.Collections.Generic;
using Sheep.Site.Api.Controllers;
using Sheep.Site.Api.Models;

namespace Sheep.Site.Api.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public DateTime sheepDOB { get; set; }
        public string sheepGender { get; set; }
        public List<Vaccine> Vaccines { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<Pregnancy> Pregnancies { get; set; }

    }
}
