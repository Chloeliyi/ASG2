public class User {
    public string username;
    public string email;
    public string password;
    public bool userStatus;
    public User() {
    }

    public User(string username, string email, string password, bool userStatus) {
        this.username = username;
        this.email = email;
        this.password = password;
        this.userStatus = userStatus;
    }
}