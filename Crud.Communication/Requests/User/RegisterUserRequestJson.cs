namespace Communication.Requests.User;

public class RegisterUserRequestJson {
    public string Name{ get; set; }
    public string Email{ get; set; }
    public string Password{ get; set; }

    public RegisterUserRequestJson(string name, string email, string password){
        Name = name;
        Email = email;
        Password = password;
    }
}