using BackendASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // StudentDbContext คือคลาสที่ เชื่อมต่อฐานข้อมูล มี DbSet
        private readonly StudentDbContext _context;

        public CategoryController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //ดึงรายการทั้งหมด
                var category = _context.Categorys.ToList();
                if (category.Count == 0)
                {
                    return NotFound("category Not available");
                }
                return Ok(category);
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
                var percels = _context.Categorys.Find(id);
                if (percels == null)
                {
                    return NotFound($"category detail not found with id {id}");
                }
                return Ok(percels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(Category model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("category create.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public IActionResult Put(Category model)
        {

            if (model == null || model.CategoryId == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid.");
                }
                else if (model.CategoryId == 0)
                {
                    return BadRequest($"Model id {model.CategoryId} is null. ");
                }
            }
            try
            {
                var percel = _context.Categorys.Find(model.CategoryId);
                if (percel == null)
                {
                    return NotFound($"category Id {model.CategoryId} is invalid");
                }
                percel.CategoryId = model.CategoryId;
                percel.CategoryName = model.CategoryName;

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
                var percel = _context.Categorys.Find(id);
                if (percel == null)
                {
                    return NotFound($"category id {id} is null");
                }
                _context.Categorys.Remove(percel);
                _context.SaveChanges();
                return Ok("category delete successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
