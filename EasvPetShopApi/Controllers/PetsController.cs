using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pet.Menu.Core.ApplicationService;
using Pet.Menu.Core.ApplicationService.Services;
using Pet.Menu.Core.Entity;

namespace EasvPetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _PetService;

        public PetsController(IPetService petService)
        {
            _PetService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<PetEntity>> Get()
        {
            return _PetService.GetAllPets();
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<PetEntity> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater than 0");
            return _PetService.FindPetByIdIncludeOwner(id);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<PetEntity> Post([FromBody] PetEntity pet)
        {
            if(string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Name is Required for Creating Pets");
            }
            if (pet.Price < 0)
            {
                return BadRequest("Price is Required for Creating Pets");
            }
            if (string.IsNullOrEmpty(pet.Color))
            {
                return BadRequest("Color is Required for Creating Pets");
            }

            return _PetService.CreatePets(pet);
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<PetEntity> Put(int id, [FromBody] PetEntity pet)
        {
            if (id < 1 || id != pet.Id)
            {
                return BadRequest("Parameter Id and pet Id must be the same");
            }
            
            return Ok(_PetService.UpdatePet(pet));
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult<PetEntity> Delete(int id)
        {
            var PetEntity = _PetService.DeletePet(id);
            if (PetEntity == null)
            {
                return StatusCode(404, "Did not find Pet with Id" + id);
            }
            return Ok($"Pet with Id: {id} is Deleted");
        }
    }
}
