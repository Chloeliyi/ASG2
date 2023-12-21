using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using Firebase.Database;
using System.Threading.Tasks;
using Firebase.Extensions;
using TMPro;
using UnityEngine.UI;
using System.Linq;


public class AuthManager : MonoBehaviour
{
    FirebaseAuth auth;

    DatabaseReference mDatabaseRef;

    [SerializeField] private TMP_InputField UsernameSignUp;
    [SerializeField] private TMP_InputField EmailSignUp;
    [SerializeField] private TMP_InputField PasswordSignUp;

    [SerializeField] private TMP_InputField EmailLogIn;
    [SerializeField] private TMP_InputField PasswordLogIn;

    [SerializeField] private TMP_InputField AdminemailLogIn;
    [SerializeField] private TMP_InputField AdminpasswordLogIn;

    [SerializeField] private TextMeshProUGUI profileName;
    [SerializeField] private TextMeshProUGUI profileEmail;
    [SerializeField] private TextMeshProUGUI profilePassword;

    public GameObject StartMenu;

    public GameObject LogInMenu;

    public GameObject SignUpMenu;

    public GameObject GameMenu;

    public GameObject AdminMenu;

    public GameObject ProfileMenu;

    public GameObject LeaderMenu;

    public GameObject QuizMenu;

    public GameObject PuzzleMenu;

    public GameObject AdminViewMenu;

    private bool userStatus = false;
    private string userId;

    private bool adminStatus = false;
    private string adminId;

    private string username;
    private string email;
    private string password;

    private int checkpoints;
    private int quizpoints;
    private float time;

    private string adminemail;
    private string adminpassword;

    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        userStatus = false;

        AdminViewMenu.gameObject.SetActive(false);
    }

    public void SignUp() {
        username = UsernameSignUp.text.Trim();
        email = EmailSignUp.text.Trim();
        password = PasswordSignUp.text.Trim();

        SignUpUser(username, email, password);
    }

    private void SignUpUser(string username, string email, string password) 
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if(task.IsFaulted || task.IsCanceled)
            {

                //string errorMsg = HandleAuthExceptions(task.Exception);
                //Debug.LogFormat("CreateUserWithEmailAndPasswordAsync Error>>> {0}", errorMsg);
                //SignInErrorText.text += string.Format(errorMsg);

                Debug.LogError("Sorry, there was an error creating your new account, ERROR: " + task.Exception);
                return;//exit from the attempt
                }
                else if (task.IsCompleted)
                {

                    Firebase.Auth.AuthResult newUser = task.Result;
                    Debug.LogFormat("Welcome to DDA Games {0}", newUser.User.Email);
                    //do anything you want after player creation eg. create new player

                    userId = newUser.User.UserId;
                    Debug.Log("userId is: " + userId);
                    userStatus = true;
                    
                    User user = new User(username, email, password, userStatus);
                    string json = JsonUtility.ToJson(user);
                    mDatabaseRef.Child("Users").Child(userId).SetRawJsonValueAsync(json);

                    profileName.text = username;

                    profileEmail.text = email;
                    
                    var passwordLength = password.Length;
                    
                    for (var i = 0; i <= passwordLength; i ++) {
                        profilePassword.text += "*";
                    }

                    CreateAdmin(userId);

                    CreateNewLeader (username); 

                    ClearSignUpFields();
                    
                    ToggleSignUpForm();
                    ToggleGameMenu();
                    
                }
        });
    }

    public void LogIn() {

        string email = EmailLogIn.text.Trim();
        string password = PasswordLogIn.text.Trim();

        LogInUser(email, password);

    }

    public void LogInUser(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                //string errorMsg = HandleAuthExceptions(task.Exception);
                //Debug.LogFormat("CreateUserWithEmailAndPasswordAsync Error>>> {0}", errorMsg);
                //SignInErrorText.text += string.Format(errorMsg);

                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                Firebase.Auth.AuthResult result = task.Result;

                userId = result.User.UserId;
                Debug.Log("userId is: " + userId);
                userStatus = true;

                DatabaseReference Updateref = FirebaseDatabase.DefaultInstance.GetReference("Users/");
                
                Dictionary<string, object> childUpdates = new Dictionary<string, object>();
                childUpdates[userId + "/userStatus"] = userStatus;
                Updateref.UpdateChildrenAsync(childUpdates);

                mDatabaseRef.Child("Users").Child(userId).GetValueAsync().ContinueWithOnMainThread(task => 
                {
                    if (task.IsFaulted) 
                    {
                        Debug.Log("userId does not exist");
                    }
                    else if (task.IsCompleted) 
                    {
                        string json = task.Result.GetRawJsonValue();
                        Debug.Log(json);
                        User user = JsonUtility.FromJson<User>(json);
                        Debug.Log(user.username);

                        profileName.text = user.username;
                    }
                });

                profileEmail.text = email;

                var passwordLength = password.Length;

                for (var i = 0; i <= passwordLength; i ++) {
                    profilePassword.text += "*";
                }

                ClearLogInFields(); 

                ToggleLogInForm();
                ToggleGameMenu();
            }

        });
    }

    public void AdminLogIn() {

        string adminemail = AdminemailLogIn.text.Trim();
        string adminpassword = AdminpasswordLogIn.text.Trim();

        LogInAdmin(email, password);

    }

    public void CreateAdmin(string userId)
    {
        adminId = userId;
        Debug.Log("adminId is: " + userId);
        adminStatus = false;
                    
        Admin admin = new Admin(username, email, password, adminStatus);
        string json = JsonUtility.ToJson(admin);
        mDatabaseRef.Child("Admins").Child(adminId).SetRawJsonValueAsync(json);
    }

    public void LogInAdmin(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                //string errorMsg = HandleAuthExceptions(task.Exception);
                //Debug.LogFormat("CreateUserWithEmailAndPasswordAsync Error>>> {0}", errorMsg);
                //SignInErrorText.text += string.Format(errorMsg);

                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                Firebase.Auth.AuthResult result = task.Result;

                adminId = result.User.UserId;
                Debug.Log("adminId is: " + adminId);
                adminStatus = true;

                DatabaseReference Updateref = FirebaseDatabase.DefaultInstance.GetReference("Admins/");
                
                Dictionary<string, object> childUpdates = new Dictionary<string, object>();
                childUpdates[adminId + "/adminStatus"] = adminStatus;
                Updateref.UpdateChildrenAsync(childUpdates);

                ClearAdminFields();

                ToggleAdminForm();
                ToggleAdminViewMenu();
            }

        });
    }

    public void LogOut()
    {
        FirebaseAuth.DefaultInstance.SignOut();

        userStatus = false;
        DatabaseReference Updateref = FirebaseDatabase.DefaultInstance.GetReference("Users/");
        
        Dictionary<string, object> childUpdates = new Dictionary<string, object>();
        childUpdates[userId + "/userStatus"] = userStatus;
        Updateref.UpdateChildrenAsync(childUpdates);

        profileName.text = "";
        profileEmail.text = "";
        profilePassword.text = "";

        Debug.Log("User has log out.");

        adminStatus = false;
        DatabaseReference newUpdateref = FirebaseDatabase.DefaultInstance.GetReference("Admins/");
        
        Dictionary<string, object> newchildUpdates = new Dictionary<string, object>();
        newchildUpdates[adminId + "/adminStatus"] = adminStatus;
        Updateref.UpdateChildrenAsync(newchildUpdates);

        if (QuizMenu.activeSelf == true) 
        {
            ToggleQuizMenu();
        }
        else if (PuzzleMenu.activeSelf == true) 
        {
            TogglePuzzleMenu();
        }
        else 
        {
            ToggleGameMenu();
            ToggleStartMenu();
        }

        //ToggleGameMenu();
        //ToggleQuizMenu();
        //TogglePuzzleMenu();
        //ToggleStartMenu();
    }

    /*public void GetLeaderDetails(int quizpoints, int checkpoints) 
    {
        Debug.Log(quizpoints);
        Debug.Log(checkpoints);
        username = profileName.text.Trim();
        time = 10;

        CreateNewLeader(username, checkpoints, time, quizpoints);
    }*/

    private void CreateNewLeader (string username) 
    {
        checkpoints = 0;
        quizpoints = 0;
        time = 10;

        Leaderboard leader = new Leaderboard(username, checkpoints, time, quizpoints);
        string json = JsonUtility.ToJson(leader);
        mDatabaseRef.Child("Leaderboard").Child(userId).SetRawJsonValueAsync(json);

    }

    public void CheckForNewQuizScore(int quizpoints) 
    {
        mDatabaseRef.Child("Leaderboard").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted) 
            {
                string json = task.Result.GetRawJsonValue();
                Leaderboard leader = JsonUtility.FromJson<Leaderboard>(json);
                if (quizpoints > leader.quizpoints) 
                {
                    DatabaseReference UpdateLeader= FirebaseDatabase.DefaultInstance.GetReference("Leaderboard/");
                    Dictionary<string, object> childUpdates = new Dictionary<string, object>();
                    childUpdates[userId + "/quizpoints"] = quizpoints;
                    UpdateLeader.UpdateChildrenAsync(childUpdates);
                }
                else {
                    Debug.Log("Score did not go past previous high score");
                }
            }
        });
    }

    private void ClearSignUpFields() 
    {
        UsernameSignUp.text = "";
        EmailSignUp.text = "";
        PasswordSignUp.text = "";
    }

    private void ClearLogInFields() {
        EmailLogIn.text = "";
        PasswordLogIn.text = "";
    }

    private void ClearAdminFields() {
        AdminemailLogIn.text = "";
        AdminpasswordLogIn.text = "";
    }

    public void ToggleStartMenu() {
        bool isActive = StartMenu.activeSelf;

        StartMenu.SetActive(!isActive);
        Debug.Log("Start Menu " + StartMenu.activeSelf);
    }

    public void ToggleSignUpForm() 
    {
        Debug.Log("On SignUp");

        bool isActive = SignUpMenu.activeSelf;

        SignUpMenu.SetActive(!isActive);
        Debug.Log("SignUpMenu is " + SignUpMenu.activeSelf);

    }

    public void ToggleLogInForm() {
        Debug.Log("On LogIn");

        bool isActive = LogInMenu.activeSelf;

        LogInMenu.SetActive(!isActive);
        Debug.Log("LogIn Form " + LogInMenu.activeSelf);

    }

    public void ToggleAdminForm() {
        Debug.Log("On Admin LogIn");

        bool isActive = AdminMenu.activeSelf;

        AdminMenu.SetActive(!isActive);
        Debug.Log("Admin Form " + AdminMenu.activeSelf);

    }

    public void ToggleGameMenu() {
        bool isActive = GameMenu.activeSelf;

        GameMenu.SetActive(!isActive);
        Debug.Log("Game Menu " + GameMenu.activeSelf);
    }

    public void ToggleQuizMenu() {
        bool isActive = QuizMenu.activeSelf;

        QuizMenu.SetActive(!isActive);
        Debug.Log("Quiz Menu " + QuizMenu.activeSelf);
    }

    public void TogglePuzzleMenu() {
        bool isActive = PuzzleMenu.activeSelf;

        PuzzleMenu.SetActive(!isActive);
        Debug.Log("Puzzle Menu " + PuzzleMenu.activeSelf);
    }

    public void ToggleAdminViewMenu() {
        bool isActive = AdminViewMenu.activeSelf;

        AdminViewMenu.SetActive(!isActive);
        Debug.Log("Admin View Menu " + AdminViewMenu.activeSelf);
    }

    public string HandleAuthExceptions(System.AggregateException e)
    {
        string errorMsg = "";

        if (e != null)
        {
            //classify our base exception into a FirebaseException object
            FirebaseException firebaseEx = e.GetBaseException() as FirebaseException;

            //Cast our error codes into proper Firebase AuthError codes
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
            Debug.LogError("Error in auth.... error code: " + errorCode);
            //care for common errors
            //@TODO there may be edge cases or other errors to handle
            //@TODO use meaningful error messages
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    errorMsg += "Missing Email Input";
                    break;
                case AuthError.MissingPassword:
                    errorMsg += "Missing Password Input";
                    break;
                case AuthError.WrongPassword:
                    errorMsg += "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    errorMsg += "Email Is Invalid";
                    break;
                case AuthError.UserNotFound:
                    errorMsg += "User Does Not Exist";
                    break;
                case AuthError.WeakPassword:
                    errorMsg += "Password Length Needs To Be At Least 6 Characters Long";
                    break;
                case AuthError.EmailAlreadyInUse:
                    errorMsg += "Email Is Already In Use ";
                    break;
                case AuthError.UserMismatch:
                    errorMsg += "User Mismatch";
                    break;
                case AuthError.Failure:
                    errorMsg += "Failed to login...";
                    break;
                default:
                    errorMsg += "Issue in authetication" + errorCode;
                    break;
            }
        }
        return errorMsg;
    }
}
