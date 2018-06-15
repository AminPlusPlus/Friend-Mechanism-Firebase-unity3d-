using System.Collections;
using System.Collections.Generic;
using System;
using Firebase.Database;
public sealed class DataService
{

    //SINGELTON
    static readonly DataService _instance = new DataService();
    public static DataService Instance { get { return _instance; } }

    //REFERENCES
    public DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

    //Database key paths

    private const string userPath = "Users";
    private const string requestFriend = "RequestFriend";

    /// <summary>
    /// Create to Database base on id User Content data
    /// </summary>
    /// <param name="id"></param>
    /// <param name="data"></param>
    public void CreateUser(string id, Dictionary<string, object> data)
    {
        reference.Child(userPath).Child(id).SetValueAsync(data).ContinueWith(task =>
        {

            if (!task.IsCompleted)
            {
                //Handle Error
                UnityEngine.Debug.Log(task.Exception.Message);
            }
        });
    }

    /// <summary>
    /// Fetching User Data according ID from firebase database
    /// </summary>
    /// <param name="id"></param>
    public void FetchUserData(string id)
    {
        reference.Child(userPath).Child(id).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle Error
                UnityEngine.Debug.Log(task.Exception.Message);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Casting Snapshot to Dictionary
                Dictionary<string, object> data = snapshot.Value as Dictionary<string, object>;

                // new model User
                User usr = new User(snapshot.Key, data);
                //Setting User
                UserController.Instance.User = usr;

                UnityEngine.Debug.Log(data["email"] + "  " + data["isLive"] + " " + snapshot.Key);
            }
        });
    }

	/// <summary>
	/// When user out/In of app/game Database IsLive key , going to change
	/// </summary>
	/// <param name="isLive"></param>
    public void UserLive(string id,bool isLive)
    {
        reference.Child(userPath).Child(id).Child("isLive").SetValueAsync(isLive)
            .ContinueWith(task =>
            {
                if (!task.IsCompleted)
                {
                    //Handle Error
                    UnityEngine.Debug.Log(task.Exception.Message);
                }
            });
    }





}
