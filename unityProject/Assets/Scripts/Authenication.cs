using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Database;


public class Authenication : MonoBehaviour
{
    FirebaseAuth auth;
    DatabaseReference dbRef;

    #region  UI Elements
    [Header("Registration UI Elements")]
    [Space(5)]
    [SerializeField] private InputField EmailSignUp;
    [SerializeField] private InputField PasswordSignUp;
    [SerializeField] private Button SignUpButton;
    #endregion

    [SerializeField] private Text DebugText;

    // Use this for initialization
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;


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
                {"email" , newUser.Email}
             };

			 //Save to DB
			dbRef.Child(DataService.Instance.RefUser).Child(newUser.UserId).SetValueAsync(userData);

             DebugText.text = "Welcome : " + newUser.Email;
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

             DebugText.text = "Welcome : " + newUser.Email;
         });

    }
}
