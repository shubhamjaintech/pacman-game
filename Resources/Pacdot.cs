using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class Pacdot : MonoBehaviour {
    public static int score=0;
    public static string setName;

    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "pacman")
        {
            PacmanMove reference = (PacmanMove)co.gameObject.GetComponent(typeof(PacmanMove));
            reference.IncreaseScore();
            Destroy(gameObject);

            Destroy(gameObject);
        //    score += 10;
        //    Debug.Log(score);
        }
     }


}
