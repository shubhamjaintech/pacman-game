using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    public GameObject LeaderBoard;
 
    public void Playbutton()
    {
        SceneManager.LoadScene("gamemv");
    }
    public void Lbbutton () {
        SceneManager.LoadScene("leaderboard");
    }
    //public void Exitbutton()
    //{
    //    Application.
    //}

    // Update is called once per frame
    void Update () {
		
	}
}
