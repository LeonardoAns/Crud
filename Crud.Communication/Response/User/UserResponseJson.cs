namespace Communication.Response.User;

public class UserResponseJson {
    public string Token{ get; set; }

    public UserResponseJson(string token){
        Token = token;
    }
}