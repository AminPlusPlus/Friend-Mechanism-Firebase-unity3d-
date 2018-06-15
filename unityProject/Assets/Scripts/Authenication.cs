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

	[SerializeField] private Text DebugText;

	// Use this for initialization
	void Start () 
	{
		auth = FirebaseAuth.DefaultInstance;
	}
	
	

	public void SignUp ()
	{
		auth.CreateUserWithEmailAndPasswordAsync(EmailSignUp.text,PasswordSignUp.text).ContinueWith(task => 
		{
			 if (task.IsCanceled)
            {
                DebugText.text = ("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                DebugText.text =("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                DebugText.text = (task.Exception.InnerExceptions[0].Message);
                return;
            }
			
			FirebaseUser newUser = task.Result;

			DebugText.text = "Welcome : " + newUser.Email;
		});


		//after sign in Button Interaction is Disable
	}
}
