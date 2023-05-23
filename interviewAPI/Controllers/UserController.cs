using Microsoft.AspNetCore.Mvc;
using interviewAPI.Models;
namespace interviewAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase{

    private static List<User> Users = new List<User>{
        new User("Test", "hello@gmail.com", null, 0),
        new User("Hello", "bye@gmail.com", null, 0),
        new User("Dylan", "dylan@gmail.com", null, 0),
        new User("Jhon", "john@yopmail.com", null, 0),
        new User("Jim Carrey", "jimcarrey@gmail.com", null, 0),
        new User("louis wilson", "best_detective@gmail.com", null, 0),
        new User("Jim Carry", "jimcarrey@gmail.com", null, 0),
        new User("Ashton Kutcher", "ashton@gmail.com", "123456789", 0),
        new User("Bob Bobson", "bobsquare@gmail.com", "0165545545", 54),
        new User("Aron A Aronson", "aronfive@gmail.com", "0165545545", 29),
        new User("Todd Bonzales", "todbon@gmail.com", null, 32),
        new User("Aron B Aronson", "aronfive@gmail.com", "0165545545", 23)
    };

    [HttpGet()]
    public async Task<IActionResult> Get([FromQuery] string? email,[FromQuery] string? phone,[FromQuery] string? orderBy){
        User[] users = Users.ToArray();
        if(!string.IsNullOrEmpty(email)) users = users.Where(user => user.email.Equals(email)).ToArray();
        if(!string.IsNullOrEmpty(phone)) users = users.Where(user => user.phoneNumber != null && user.phoneNumber.Equals(phone)).ToArray();
        if(!string.IsNullOrEmpty(orderBy)){
            switch (orderBy){
                case "email":
                    users = users.OrderBy(user => user.email).ToArray();
                    break;

                case "name":
                    users = users.OrderBy(user => user.name).ToArray();
                    break;

                case "phoneNumber":
                    users = users.OrderBy(user => user.phoneNumber).ToArray();
                    break;

                case "age":
                    users = users.OrderBy(user => user.age).ToArray();
                    break;
                    
                case "id":
                    users = users.OrderBy(user => user.Id).ToArray();
                    break;

                default:
                    users = users.OrderBy(user => user.Id).ToArray();
                    break;
            }
        }
        return Ok(users);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] User added){
        User newUser = new User(added.name, added.email, added.phoneNumber, added.age);
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