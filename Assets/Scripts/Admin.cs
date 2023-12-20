public class Admin {
    public string adminname;
    public string email;
    public string password;
    public bool adminStatus;
    public Admin() {
    }

    public Admin(string adminname, string email, string password, bool adminStatus) {
        this.adminname = adminname;
        this.email = email;
        this.password = password;
        this.adminStatus = adminStatus;
    }
}
