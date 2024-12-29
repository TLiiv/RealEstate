using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Server.Data;
using RealEstate.Server.Models;

namespace RealEstate.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Users
        [HttpGet]
        public async Task<IActionResult> Index(int  pageIndex = 0, int pageSize = 10)
        {
            BaseResponseModel response = new BaseResponseModel();
            try
            {
                var userCount = await _context.Users.CountAsync(); 
                var userList = await _context.Users
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync(); 

                response.Status = true;
                response.StatusMessage = "Success";
                response.Data = new {Users = userList, Count = userCount};

                return Ok(response);

            }
            catch (Exception ex)
            {

                response.Status = false;
                response.StatusMessage = "Something went wrong";
                
               return BadRequest(response);
            }
        }

        // GET: User
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            BaseResponseModel response = new BaseResponseModel();
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.UserId == id); // Async single user retrieval

                if (user == null)
                {
                    response.Status = false;
                    response.StatusMessage = "Record not found";
                    return NotFound(response);
                }

                response.Status = true;
                response.Data = user;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMessage = "Something went wrong";
                return BadRequest(response);
            }
        }
    }
}
