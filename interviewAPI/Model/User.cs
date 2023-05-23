namespace interviewAPI.Models;

public class User{
    public string Id {get; private set;} = "";
    public string name {get; set;} = "";
    public string email {get; set;} = "";

    public string? phoneNumber {get; set;}

    public string? age {get; set;}
    private Guid guid = Guid.NewGuid();

    public User(string name, string email){
        this.name = name;
        this.email = email;
        this.Id = guid.ToString();
    }
}