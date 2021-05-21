using System;
using System.Collections.Generic;
using castle.Models;
using castle.Services;
using Microsoft.AspNetCore.Mvc;

namespace castle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastlesController : ControllerBase
    {
        private readonly CastlesService _service;

        public CastlesController(CastlesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Castle>> GetAllCastles()
        {
            try
            {
                IEnumerable<Castle> castles = _service.GetAllCastles();
                return Ok(castles);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Castle> GetCastleById(int id)
        {
            try
            {
                Castle castle = _service.GetCastleById(id);
                return Ok(castle);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Castle> CreateCastle([FromBody] Castle newCastle)
        {
            try
            {
                Castle castle = _service.CreateCastle(newCastle);
                return Ok(castle);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // REVIEW Edit is not working!
        [HttpPut("{id}")]
        public ActionResult<Castle> EditCastle(int id, [FromBody] Castle edit)
        {
            try{
                edit.Id = id;
                Castle edited = _service.EditCastle(edit);
                return Ok(edited);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // REVIEW why is ActionResult a <string>
        [HttpDelete("{id}")]
        public ActionResult<String> DeleteCastle(int id)
        {
            try
            {
                _service.DeleteCastle(id);
                return Ok("Successfully Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}