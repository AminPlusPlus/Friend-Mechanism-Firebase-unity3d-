using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileUser : MonoBehaviour 
{
	[Header("UI Elements")]
	[SerializeField] private Image profileIcon;
	[SerializeField] private Text fullName;



	void OnEnable()
	{
		DataService.Instance.OnFetchedUser += initView;
		
	}

	void OnDisable() 
	{
		DataService.Instance.OnFetchedUser -= initView;
	}
	/// <summary>
	/// Initilization UI elements from DB
	/// </summary>
	void initView (User usr)
	{	
		fullName.text = usr.Email;
	}
	
}
