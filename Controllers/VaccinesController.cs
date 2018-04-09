using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sheep.Site.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sheep.Site.Api.Controllers
{
    [Route("api/[controller]")]
    public class VaccinesController : Controller
    {
        private readonly SheepSiteContext db;
        
        public VaccinesController(SheepSiteContext db)
        {
            this.db = db;

            if(this.db.Vaccines.Count() == 0)
            {
                this.db.Vaccines.Add(new Vaccine {
                    vaccineID = 1,
                    vId = 1,
                    vaccineName = "Sheep Flu",
                    vaccineDosage = "30 ml",
                    vaccineDate = default(DateTime),
                    vaccineComment = "for the strain of 2018"
                });
                
                this.db.Vaccines.Add(new Vaccine {
                    vaccineID = 2,
                    vId = 1,
                    vaccineName = "Sheep cold",
                    vaccineDosage = "30 ml",
                    vaccineDate = default(DateTime),
                    vaccineComment = "for the strain of 2018"
                });

                this.db.SaveChanges();
            }
        }
        [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(db.Vaccines);
            }

        [HttpGet("{id}", Name="GetVaccines")]
        public IActionResult GetById(int id)
        {
            var vaccine = db.Vaccines.Find(id);
            
            if(vaccine == null)
            {
                return NotFound();
            }
            return Ok(vaccine);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Vaccine vaccine)
        {
            if(vaccine == null)
            {
                return BadRequest();
            }

            this.db.Vaccines.Add(vaccine);
            this.db.SaveChanges();

            return CreatedAtRoute("GetVaccine", new { id = vaccine.vaccineID}, vaccine);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Vaccine newVaccine)
        {
            if (newVaccine == null || newVaccine.vaccineID !=id)
            {
                return BadRequest();
            }
            var currentVaccine = this.db.Vaccines.FirstOrDefault(x => x.vaccineID == id);

            if (currentVaccine == null)
            {
                return NotFound();
            }

            currentVaccine.vaccineName = newVaccine.vaccineName;
            currentVaccine.vaccineDosage = newVaccine.vaccineDosage;
            currentVaccine.vaccineDate = newVaccine.vaccineDate;
            currentVaccine.vaccineComment = newVaccine.vaccineComment;
            

            this.db.Vaccines.Update(currentVaccine);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var vaccine = this.db.Vaccines.FirstOrDefault(x => x.vaccineID == id);

            if (vaccine == null)
            {
                return NotFound();
            }
            
            this.db.Vaccines.Remove(vaccine);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
