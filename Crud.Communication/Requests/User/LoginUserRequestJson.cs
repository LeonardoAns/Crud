namespace Communication.Requests.User;

public class LoginUserRequestJson {
    public string Email{ get; set; }
    public string Password{ get; set; }

    public LoginUserRequestJson(string email, string password){
        Email = email;
        Password = password;
    }
}