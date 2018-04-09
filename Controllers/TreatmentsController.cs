using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sheep.Site.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sheep.Site.Api.Controllers
{
    [Route("api/[controller]")]
    public class TreatmentsController : Controller
    {
        private readonly SheepSiteContext db;
        
        public TreatmentsController(SheepSiteContext db)
        {
            this.db = db;

            if(this.db.Treatments.Count() == 0)
            {
                this.db.Treatments.Add(new Treatment {
                    treatmentID = 1,
                    treatmentName = "Sheep Flu",
                    treatmentDosage = "30 ml",
                    treatmentDate = default(DateTime),
                    treatmentComment = "for the strain of 2018"
                });
                
                this.db.Treatments.Add(new Treatment {
                    treatmentID = 2,
                    treatmentName = "Sheep cold",
                    treatmentDosage = "30 ml",
                    treatmentDate = default(DateTime),
                    treatmentComment = "for the strain of 2018"
                });

                this.db.SaveChanges();
            }
        }
        [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(db.Treatments);
            }

        [HttpGet("{tid}", Name="GetTreatments")]
        public IActionResult GetById(int tid)
        {
            var treatment = db.Treatments.Find(tid);
            
            if(treatment == null)
            {
                return NotFound();
            }
            return Ok(treatment);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Treatment treatment)
        {
            if(treatment == null)
            {
                return BadRequest();
            }

            this.db.Treatments.Add(treatment);
            this.db.SaveChanges();

            return CreatedAtRoute("GetTreatment", new { tid = treatment.treatmentID}, treatment);
        }

        [HttpPut("{tid}")]

        public IActionResult Put(int tid, [FromBody]Treatment newTreatment)
        {
            if (newTreatment == null || newTreatment.treatmentID !=tid)
            {
                return BadRequest();
            }
            var currentTreatment = this.db.Treatments.FirstOrDefault(x => x.treatmentID == tid);

            if (currentTreatment == null)
            {
                return NotFound();
            }

            currentTreatment.treatmentName = newTreatment.treatmentName;
            currentTreatment.treatmentDosage = newTreatment.treatmentDosage;
            currentTreatment.treatmentDate = newTreatment.treatmentDate;
            currentTreatment.treatmentComment = newTreatment.treatmentComment;
            

            this.db.Treatments.Update(currentTreatment);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{tid}")]
        public IActionResult Delete(int tid)
        {
            var treatment = this.db.Treatments.FirstOrDefault(x => x.treatmentID == tid);

            if (treatment == null)
            {
                return NotFound();
            }
            
            this.db.Treatments.Remove(treatment);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
