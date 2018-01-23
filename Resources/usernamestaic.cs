using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usernamestaic : MonoBehaviour {
    public static string username;

    
    public static string getsavedname
    {
        get
        {
            return username;
        }
        set
        {
            username = value;
        }
    }
}
