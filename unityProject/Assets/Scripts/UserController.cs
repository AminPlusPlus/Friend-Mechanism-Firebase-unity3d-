using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class UserController : MonoBehaviour
{
	#region  Singelton
    private static UserController _instance;
    public static UserController Instance { get { return _instance; } }
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }


        DontDestroyOnLoad(Instance);
    }
	#endregion

    public User User;

void OnEnable()
{
	//DataService.Instance.UserLive(User.Id,true);
}

void OnDisable()
{
	DataService.Instance.UserLive(User.Id,false);
}

}




