using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sheep.Site.Api.Models;
using Sheep.Site.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Sheep.Site.Api.Controllers
{
    [Route("api/[controller]")]
    public class AnimalsController : Controller
    {
        private readonly SheepSiteContext db;
        
        public AnimalsController(SheepSiteContext db)
        {
            this.db = db;

            if(this.db.Animals.Count() == 0)
            {
                this.db.Animals.Add(new Animal {
                    Id = 1,
                    sheepDOB = default(DateTime),
                    sheepGender = 'F'
                });
                
                this.db.Animals.Add(new Animal
                {
                    Id = 2,
                    sheepDOB = default(DateTime),
                    sheepGender = 'M'
                });

                this.db.Animals.Add(new Animal
                {
                    Id = 3,
                    sheepDOB = default(DateTime),
                    sheepGender = 'M'
                });

                this.db.SaveChanges();
            }
        }
        [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(db.Animals);
            }

        [HttpGet("{id}", Name="GetAnimal")]
        public IActionResult GetById(int id)
        {
            var animal = db.Animals.Find(id);
            
            if(animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Animal animal)
        {
            if(animal == null)
            {
                return BadRequest();
            }

            this.db.Animals.Add(animal);
            this.db.SaveChanges();

            return CreatedAtRoute("GetAnimal", new { id = animal.Id}, animal);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Animal newAnimal)
        {
            if (newAnimal == null || newAnimal.Id !=id)
            {
                return BadRequest();
            }
            var currentAnimal = this.db.Animals.FirstOrDefault(x => x.Id == id);

            if (currentAnimal == null)
            {
                return NotFound();
            }

            currentAnimal.sheepDOB = newAnimal.sheepDOB;
            currentAnimal.sheepGender = newAnimal.sheepGender;

            this.db.Animals.Update(currentAnimal);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = this.db.Animals.FirstOrDefault(x => x.Id == id);

            if (animal == null)
            {
                return NotFound();
            }
            
            this.db.Animals.Remove(animal);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
