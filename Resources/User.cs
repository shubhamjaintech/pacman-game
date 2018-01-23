using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {

    public int score;
   public string username;
    //string pswd;
    public User(int score,string username)
    {
        this.score = score;
        this.username = username;
            //this.pswd = pswd;
    }
	// Use this for initialization
}
