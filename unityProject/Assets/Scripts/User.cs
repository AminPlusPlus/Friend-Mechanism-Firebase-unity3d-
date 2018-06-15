using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class User 
{
	public string Id { get; private set; }
	public string Email { get; private set; }
	public bool isLive { get; private set; }	

	public User (string id, Dictionary <string,object> data)
	{
		this.Id = id;
		this.Email = data["email"].ToString();
		this.isLive = (bool)data["isLive"];
	}

}
