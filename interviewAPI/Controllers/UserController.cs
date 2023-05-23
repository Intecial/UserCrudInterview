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
        new User("Jhon", "john@yopmail.com"),
        new User("Jim Carrey", "jimcarrey@gmail.com"),
        new User("louis wilson", "best_detective@gmail.com"),
        new User("Jim Carry", "jimcarrey@gmail.com"),
        new User("Ashton Kutcher", "ashton@gmail.com", "123456789"),
        new User("Bob Bobson", "bobsquare@gmail.com", "0165545545", 54),
        new User("Aron A Aronson", "aronfive@gmail.com", "0165545545", 29),
        new User("Todd Bonzales", "todbon@gmail.com", 32),
        new User("Aron B Aronson", "aronfive@gmail.com", "0165545545", 23)
    };

    [HttpGet()]
    public async Task<IActionResult> Get([FromQuery] string? email,[FromQuery] string? phone,[FromQuery] string? orderBy, [FromQuery] bool isAscending = true){
        User[] users = Users.ToArray();
        if(!string.IsNullOrEmpty(email)) users = users.Where(user => user.email.Equals(email)).ToArray();
        if(!string.IsNullOrEmpty(phone)) users = users.Where(user => user.phoneNumber != null && user.phoneNumber.Equals(phone)).ToArray();
        if(!string.IsNullOrEmpty(orderBy)){
            switch (orderBy){
                case "email":
                    users = isAscending? users.OrderBy(user => user.email).ToArray() : users.OrderByDescending(user => user.email).ToArray();
                    break;

                case "name":
                    users = isAscending? users.OrderBy(user => user.name).ToArray(): users.OrderByDescending(user => user.name).ToArray();
                    break;

                case "phoneNumber":
                    users = isAscending? users.OrderBy(user => user.phoneNumber).ToArray(): users.OrderByDescending(user => user.phoneNumber).ToArray();
                    break;

                case "age":
                    users = isAscending? users.OrderBy(user => user.age).ToArray(): users.OrderByDescending(user => user.age).ToArray();
                    break;
                    
                case "id":
                    users = isAscending? users.OrderBy(user => user.Id).ToArray(): users.OrderByDescending(user => user.Id).ToArray();
                    break;

                default:
                    users = isAscending? users.OrderBy(user => user.Id).ToArray(): users.OrderByDescending(user => user.Id).ToArray();
                    break;
            }
        }
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