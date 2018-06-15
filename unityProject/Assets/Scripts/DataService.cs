using System.Collections;
using System.Collections.Generic;
using System;

public sealed class DataService 
{	

	//SINGELTON
	static readonly DataService _instance = new DataService();
	public static DataService Instance {get {return _instance;}}

	//REFERENCES
	private string refUser = "Users";
	public string RefUser { get {return refUser;}  }
	
}
