using Microsoft.AspNetCore.Identity;
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
        public async Task<IActionResult> Index(int pageIndex = 0, int pageSize = 10)
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
                response.Data = new { Users = userList, Count = userCount };

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateModel model)
        {
            BaseResponseModel response = new BaseResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    // Create a new User object based on the incoming model
                    var user = new User()
                    {
                        UserId = Guid.NewGuid(),
                        UserFirstName = model.UserFirstName,
                        UserLastName = model.UserLastName,
                        UserEmail = model.UserEmail,
                        UserPassword = model.UserPassword, 
                        CreatedAt = DateTime.UtcNow,
                        Avatar = model.Avatar,
                    };

                    // Add the new user to the database
                    _context.User.Add(user);
                    await _context.SaveChangesAsync();

                    response.Status = true;
                    response.StatusMessage = "User created successfully";
                    response.Data = user;

                    return Ok(response);
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Invalid input data";
                    return BadRequest(response);
                }
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
