using Magic_VillaAPI.Data;
using Magic_VillaAPI.Models;
using Magic_VillaAPI.Models.VillaDto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Magic_VillaAPI.Controllers
{
    [ApiController]
    [Route("api/VillaApi")]
    public class  VillaAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult <IEnumerable<HouseDTO>> GetVillas()
        {
            return Ok (VillaStore.HouseList);
        }

        [HttpGet("{id:int}", Name = "GetVillas")]

        public ActionResult<HouseDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.HouseList.FirstOrDefault(e => e.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost("{id:int}", Name = "GetVillas")]

        public ActionResult<HouseDTO> CreateVilla([FromBody]HouseDTO villa)
        {
            if (VillaStore.HouseList.FirstOrDefault(e=>e.Name.ToLower()==villa.Name.ToLower()) != null) 
            {
                ModelState.AddModelError("CustomError", "Name Already Exists!!!");
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest();
            }
            if (villa.Id > 0)
            {
                ModelState.AddModelError("CustomError", "ID Must NOt BE Greater than Zero!!!");
                 return BadRequest(ModelState);
            }
            villa.Id = VillaStore.HouseList.OrderByDescending(e => e.Id).FirstOrDefault().Id + 1;
            VillaStore.HouseList.Add(villa);
            return CreatedAtRoute("GetVillas", new {id = villa.Id }, villa);
        }

        [HttpDelete("{id:int}")]

        public ActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("CustomError", "Error ID");
                return BadRequest(ModelState);
            }
            var villa = VillaStore.HouseList.FirstOrDefault(e => e.Id == id);
            
            if (villa == null)
            {
                ModelState.AddModelError("CustomError", "Can Not Find Any Villa With The Id");
                return BadRequest(ModelState);
            }
            

            VillaStore.HouseList.Remove(villa);
            return NoContent();
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateVilla(int id, [FromBody] HouseDTO villa)
        {

            if (villa == null || id != villa.Id)
            {
                return BadRequest("Invalid Request");
            }
            var Updatevilla = VillaStore.HouseList.FirstOrDefault(e => e.Id == id);
            Updatevilla.Id = villa.Id;
            Updatevilla.Name = villa.Name;
            Updatevilla.Sqft = villa.Sqft;
            Updatevilla.Address = villa.Address;
   
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePrtialVilla")]

        public IActionResult UpdatePrtialVilla(int id, JsonPatchDocument<HouseDTO> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.HouseList.FirstOrDefault(e => e.Id == id);
            
            if (villa == null)
            {
                return BadRequest();
            }
            patch.ApplyTo(villa, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
