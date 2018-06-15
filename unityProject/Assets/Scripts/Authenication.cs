using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;


public class Authenication : MonoBehaviour
{
    FirebaseAuth auth;

    #region  UI Elements
    [Header("Registration UI Elements")]
    [Space(5)]
    [SerializeField] private InputField EmailSignUp;
    [SerializeField] private InputField PasswordSignUp;
    [SerializeField] private Button SignUpButton;
    #endregion

    [Header("Panel")]
    [Space(5)]

    [SerializeField] private GameObject RegisPanel;
    [SerializeField] private GameObject GamePanel;


    [SerializeField] private Text DebugText;

    // Use this for initialization
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }



    public void SignUp()
    {
        auth.CreateUserWithEmailAndPasswordAsync(EmailSignUp.text, PasswordSignUp.text).ContinueWith(task =>
         {
             if (task.IsCanceled)
             {
                 DebugText.text = ("CreateUserWithEmailAndPasswordAsync was canceled.");
                 return;
             }
             if (task.IsFaulted)
             {
                 DebugText.text = ("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                 if (task.Exception.InnerExceptions.Count > 0)
                     DebugText.text = (task.Exception.InnerExceptions[0].Message);
                 return;
             }

             FirebaseUser newUser = task.Result;

             Dictionary<string, object> userData = new Dictionary<string, object>()
             {
                {"email" , newUser.Email},
				{"isLive",true}
             };

			 DataService.Instance.CreateUser(newUser.UserId,userData);
			 //creating user
			 User user = new User(newUser.UserId,userData);
			 //set user
			 UserController.Instance.User = user;

			 Debug.Log(UserController.Instance.User.Id);
	
			 DebugText.text = "Welcome : " + UserController.Instance.User.Email;

         });

    }

    public void SignIn()
    {
        auth.SignInWithEmailAndPasswordAsync(EmailSignUp.text, PasswordSignUp.text).ContinueWith(task =>
         {
             if (task.IsCanceled)
             {
                 DebugText.text = ("CreateUserWithEmailAndPasswordAsync was canceled.");
                 return;
             }
             if (task.IsFaulted)
             {
                 DebugText.text = ("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                 if (task.Exception.InnerExceptions.Count > 0)
                     DebugText.text = (task.Exception.InnerExceptions[0].Message);
                 return;
             }

             FirebaseUser newUser = task.Result;

			 DataService.Instance.FetchUserData(newUser.UserId);

             DebugText.text = "Welcome : " + newUser.Email;
         });

    }

	
}
