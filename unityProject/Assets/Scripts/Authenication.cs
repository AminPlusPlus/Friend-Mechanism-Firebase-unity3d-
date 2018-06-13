using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Authenication : MonoBehaviour 
{


	#region  UI Elements
	[Header("UI Elements")]
	[Space(5)]
	[Header("Sign In")]
	[SerializeField] private InputField EmailSignIn;
	[SerializeField] private InputField PasswordSignIn;

	[Header("Sign Up")]
	[Space(5)]
	[SerializeField] private InputField EmailSignUp;
	[SerializeField] private InputField PasswordSignUp;
	[SerializeField] private InputField ConfirmPassword;
	#endregion


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
