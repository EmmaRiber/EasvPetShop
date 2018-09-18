using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pet.Menu.Core.ApplicationService;
using Pet.Menu.Core.Entity;

namespace EasvPetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/Owner
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwners();
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be larger than 0");

            return _ownerService.FindOwnerById(id);
        }

        // POST: api/Owner
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("First name is Required for Creating Owner");
            }
            if (string.IsNullOrEmpty(owner.LastName))
            {
                return BadRequest("Last name is Required for Creating Owner");
            }
            if (string.IsNullOrEmpty(owner.Adress))
            {
                return BadRequest("Adress is Required for Creating Owner");
            }
            return _ownerService.CreateOwner(owner);
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.OwnerId)
            {
                return BadRequest("Parameter Id and order Id must be the same");
            }
            
            return Ok(_ownerService.UpdateOwner(owner));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var Owner = _ownerService.DeleteOwner(id);
            if (Owner == null)
            {
                return StatusCode(404, "Did not find Owner with Id" + id);
            }
            return Ok($"Owner with Id: {id} is deleted");
        }
    }
}
