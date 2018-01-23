using UnityEngine;
using System.Collections;
using System;
using System.Xml;
using System.IO;
using UnityEngine.SceneManagement;

public class GhostMove : MonoBehaviour
{
    //public static string setName;
    public Transform[] waypoints;
    int cur = 0;
    public float speed = 0.3f;

    void FixedUpdate()
    {
        // Waypoint not reached yet? then move closer
        bool k = Math.Round(transform.position.x) != Math.Round(waypoints[cur].position.x) || Math.Round(transform.position.y) != Math.Round(waypoints[cur].position.y);
        if (k)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else cur = (cur + 1) % waypoints.Length;
        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "pacman")
        {
            PacmanMove reference = (PacmanMove)obj.gameObject.GetComponent(typeof(PacmanMove));
            int score = reference.GetScore();
            WriteScore(score);
            //destroying pacman
            Destroy(obj.gameObject);
            SceneManager.LoadScene("leaderboard");

            }


    }

    public static void WriteScore(int score)
    {
        string filePath = @"C:\Users\shubham\Documents\UnityProjects\pacman2d\Assets\Pacman-Game\Resources\users.xml";

        XmlDocument xmlDoc = new XmlDocument();
        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);
            XmlNodeList usersList = xmlDoc.GetElementsByTagName("details");
            foreach (XmlNode user in usersList)
            {
                if (user.SelectSingleNode("username").InnerText == usernamestaic.getsavedname)
                {
                    if (int.Parse(user.SelectSingleNode("score").InnerText.ToString()) < score)
                    {
                        Debug.Log("score added");
                        user.SelectSingleNode("score").InnerText = score.ToString();
                        xmlDoc.Save(filePath);
                    }
                    return;
                }
            }
        }
        else
        {
            Debug.Log("File does not exists");
        }
    }
}
