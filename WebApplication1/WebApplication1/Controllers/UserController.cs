using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>();

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id); 
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User request)
        {
            _users.Add(request);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User request)
        {
           var user = _users.FirstOrDefault(x => x.Id == id);
            if(user != null)
            {
                user.Name = request.Name;
                user.Email = request.Email;
                user.Job = request.Job;
                user.address = request.address;
                user.phone = request.phone;

                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(user);
        }
    } 
}
