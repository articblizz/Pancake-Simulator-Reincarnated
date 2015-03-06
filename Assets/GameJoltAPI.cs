using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameJoltAPI : MonoBehaviour {

    public int gameID;
    public string privateKey;
    public string userName;
    public string userToken;

    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        GJAPI.Init(gameID, privateKey);
        //GJAPI.Users.Verify(userName, userToken);
        GJAPI.Users.VerifyCallback += OnVerifyUser;

    }

    void Start()
    {
        //GJAPIHelper.Users.GetFromWeb(GetUserInfo);
        GJAPIHelper.Users.GetFromWeb((n, t) =>
        {
            GJAPI.Users.Verify(n, t);
        });
        GJAPI.Users.Verify("lel?", "LEL!");

    }

    void GetUserInfo(string name, string token)
    {
        GJAPI.Users.Verify(name, token);
    }
    
    void OnEnable()
    {
        GJAPI.Users.VerifyCallback += OnVerifyUser;
    }

    void OnDisable()
    {
        GJAPI.Users.VerifyCallback -= OnVerifyUser;
    }

    void OnVerifyUser(bool success)
    {
        if (success)
        {
            GJAPIHelper.Users.ShowGreetingNotification();
        }
        else
        {
            Debug.Log("Um... Something went wrong.");
            GJHNotification not = new GJHNotification("Something went wrong with login :(");
            not.DisplayTime = 2f;
            
            GJHNotificationsManager.QueueNotification(not);
        }
    }

    public void ShowLeaders()
    {
        GJAPIHelper.Scores.ShowLeaderboards();
    }
}
