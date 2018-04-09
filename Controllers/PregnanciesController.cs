using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sheep.Site.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sheep.Site.Api.Controllers
{
    [Route("api/[controller]")]
    public class PregnanciesController : Controller
    {
        private readonly SheepSiteContext db;
        
        public PregnanciesController(SheepSiteContext db)
        {
            this.db = db;

            if(this.db.Pregnancies.Count() == 0)
            {
                this.db.Pregnancies.Add(new Pregnancy {
                    pregnancyID = 1,
                    conceptionDate = "N/A",
                    estBirth = "N/A",
                    actBirth = "N/A",
                    numberOfBabies = 6,
                    pregnancyComment = "babies all came out healthy"
                });
                
                this.db.Pregnancies.Add(new Pregnancy {
                    pregnancyID = 2,
                    conceptionDate = "N/A",
                    estBirth = "N/A",
                    actBirth = "N/A",
                    numberOfBabies = 3,
                    pregnancyComment = "babies all came out healthy"
                });

                this.db.SaveChanges();
            }
        }
        [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(db.Pregnancies);
            }

        [HttpGet("{id}", Name="GetPregnancies")]
        public IActionResult GetById(int id)
        {
            var pregnancy = db.Pregnancies.Find(id);
            
            if(pregnancy == null)
            {
                return NotFound();
            }
            return Ok(pregnancy);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Pregnancy pregnancy)
        {
            if(pregnancy == null)
            {
                return BadRequest();
            }

            this.db.Pregnancies.Add(pregnancy);
            this.db.SaveChanges();

            return CreatedAtRoute("GetPregnancy", new { id = pregnancy.pregnancyID}, pregnancy);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Pregnancy newPregnancy)
        {
            if (newPregnancy == null || newPregnancy.pregnancyID !=id)
            {
                return BadRequest();
            }
            var currentPregnancy = this.db.Pregnancies.FirstOrDefault(x => x.pregnancyID == id);

            if (currentPregnancy == null)
            {
                return NotFound();
            }

            currentPregnancy.conceptionDate = newPregnancy.conceptionDate;
            currentPregnancy.estBirth = newPregnancy.estBirth;
            currentPregnancy.actBirth = newPregnancy.actBirth;
            currentPregnancy.numberOfBabies = newPregnancy.numberOfBabies;
            currentPregnancy.pregnancyComment = newPregnancy.pregnancyComment;
      
            this.db.Pregnancies.Update(currentPregnancy);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pregnancy = this.db.Pregnancies.FirstOrDefault(x => x.pregnancyID == id);

            if (pregnancy == null)
            {
                return NotFound();
            }
            
            this.db.Pregnancies.Remove(pregnancy);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
