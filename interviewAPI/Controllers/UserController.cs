using Microsoft.AspNetCore.Mvc;
using interviewAPI.Models;
namespace interviewAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase{

    private static List<User> Users = new List<User>{
        new User("Test", "hello@gmail.com"),
        new User("Hello", "bye@gmail.com"),
        new User("Dylan", "dylan@gmail.com"),
        new User("Jhon", "john@yopmail.com")
    };

    [HttpGet()]
    public async Task<IActionResult> Get(){
        if (Users == null){
            return NotFound();
        }
        return Ok(Users.ToArray());
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> Get(string username){
        User[] users = Users.Where(i => i.name.Equals(username)).ToArray();
        return Ok(users);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(User user){
        User newUser = new User(user.name, user.email);
        Users.Add(newUser);
        return Ok(newUser.Id);
    
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id,[FromBody] User request){ 
        var user = Users.Find(u => u.Id.Equals(id));
        if (user == null){
            return BadRequest("User not found");
        }

        user.name = request.name;
        user.email = request.email;
        user.phoneNumber = request.phoneNumber;
        user.age = request.age;

        return Ok(Users);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id){
        var user = Users.Find(u => u.Id.Equals(id));
        if (user == null){
            return BadRequest("User not found");
        }
        Users.Remove(user);
        return Ok(user);

        
    }
}