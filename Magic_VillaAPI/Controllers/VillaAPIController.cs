using Magic_VillaAPI.Data;
using Magic_VillaAPI.Models;
using Magic_VillaAPI.Models.HouseDto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magic_VillaAPI.Controllers
{
    [ApiController]
    [Route("api/VillaApi")]
    public class  VillaAPIController : ControllerBase

    {
        private readonly ApplicationDbContext db;
        public VillaAPIController(ApplicationDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public ActionResult <IEnumerable<HouseDTO>> GetVillas()
        {
            return Ok (db.Houses);
        }

        [HttpGet("{id:int}", Name = "GetVillas")]

        public ActionResult<HouseDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = db.Houses.FirstOrDefault(e => e.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost("{id:int}", Name = "GetVillas")]

        public ActionResult<HouseDTO> CreateVilla([FromBody]HouseDTO house)
        {
            if (db.Houses.FirstOrDefault(e=>e.Name.ToLower()==house.Name.ToLower()) != null) 
            {
                ModelState.AddModelError("CustomError", "Name Already Exists!!!");
                return BadRequest(ModelState);
            }
            if (house == null)
            {
                return BadRequest();
            }
            if (house.Id > 0)
            {
                ModelState.AddModelError("CustomError", "ID Must NOt BE Greater than Zero!!!");
                 return BadRequest(ModelState);
            }
            House model = new()
            {
                Id = house.Id,
                Name = house.Name,
                Sqft = house.Sqft,
                Address = house.Address,
                HouseNumber = house.HouseNumber,
                CreatedTime = DateTime.Now,
            };
            db.Houses.Add(model);
            db.SaveChanges();
            

            return CreatedAtRoute("GetVillas", new {id = house.Id }, house);
        }

        [HttpDelete("{id:int}")]

        public ActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("CustomError", "Error ID");
                return BadRequest(ModelState);
            }
            var villa = db.Houses.FirstOrDefault(e => e.Id == id);
            
            if (villa == null)
            {
                ModelState.AddModelError("CustomError", "Can Not Find Any Villa With The Id");
                return BadRequest(ModelState);
            }
             

            db.Houses.Remove(villa);
            db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateVilla(int id, [FromBody] HouseDTO house)
        {

            if (house == null || id != house.Id)
            {
                return BadRequest("Invalid Request");
            }
            //var Updatevilla = db.Houses.FirstOrDefault(e => e.Id == id);
            //Updatevilla.Id = villa.Id;
            //Updatevilla.Name = villa.Name;
            //Updatevilla.Sqft = villa.Sqft;
            //Updatevilla.Address = villa.Address;

            House model = new()
            {
                Id = house.Id,
                Name = house.Name,
                Sqft = house.Sqft,
                Address = house.Address,
                HouseNumber = house.HouseNumber,
                CreatedTime = DateTime.Now,
            };         
            db.Houses.Update(model);
            db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePrtialVilla")]

        public IActionResult UpdatePrtialVilla(int id, JsonPatchDocument<HouseDTO> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }
            var house = db.Houses.AsNoTracking().FirstOrDefault(e => e.Id == id);
            HouseDTO model = new()
            {
                Id = house.Id,
                Name = house.Name,
                Sqft = house.Sqft,
                Address = house.Address,
                HouseNumber = house.HouseNumber,
                
            };
            if (house == null)
            {
                return BadRequest();
            }
            
            patch.ApplyTo(model, ModelState);
            House model2 = new House()
            {
                Id = house.Id,
                Name = house.Name,
                Sqft = house.Sqft,
                Address = house.Address,
                HouseNumber = house.HouseNumber,
            };
            db.Houses.Update(model2);
            db.SaveChanges();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
