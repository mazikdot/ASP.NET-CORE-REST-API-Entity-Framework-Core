using BackendASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PercelController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public PercelController(StudentDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //ดึงรายการทั้งหมด
                var percels = _context.Percels.ToList();
                if (percels.Count == 0)
                {
                    return NotFound("Percel Not available");
                }
                return Ok(percels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var percels = _context.Percels.Find(id);
                if (percels == null)
                {
                    return NotFound($"Percel detail not found with id {id}");
                }
                return Ok(percels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(Percel model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Percel create.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public IActionResult Put(Percel model) {

            if (model == null || model.id == 0)
            {
                if(model == null)
                {
                    return BadRequest("Model data is invalid.");
                } else if(model.id == 0)
                {
                    return BadRequest($"Model id {model.id} is null. ");
                }
            }
            try
            {
                var percel = _context.Percels.Find(model.id);
                if (percel == null)
                {
                    return NotFound($"Percel Id {model.id} is invalid");
                }

                percel.id = model.id;
                percel.PercelName = model.PercelName;
                percel.CategoryId = model.CategoryId;

                _context.SaveChanges();
                return Ok("percel details update");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete] 
        public IActionResult Delete(int id)
        {
            try
            {
                var percel = _context.Percels.Find(id);
                if (percel == null)
                {
                    return NotFound($"Percel id {id} is null");
                }
                _context.Percels.Remove(percel);
                _context.SaveChanges();
                return Ok("Percel delete successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
