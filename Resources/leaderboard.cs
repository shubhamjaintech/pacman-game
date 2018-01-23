using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class leaderboard : MonoBehaviour
{

    public Text username;
    public Text score;
    public void displayleaderboard()
    {
        string filePath = @"C:\Users\shubham\Documents\UnityProjects\pacman2d\Assets\Pacman-Game\Resources\users.xml";
        Hashtable ht = new Hashtable();
        XmlDocument xmlDoc = new XmlDocument();
        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);
            XmlNodeList playerlist = xmlDoc.GetElementsByTagName("details");
            foreach (XmlNode user in playerlist)
            {
                ht.Add(user.SelectSingleNode("username").InnerText, user.SelectSingleNode("score").InnerText);
            }

            // Get a collection of the keys.
            ICollection key = ht.Keys;

            foreach (string k in key)
            {
                Debug.Log(k + ": " + ht[k]);
                username.text += k+"\n";
                score.text += ht[k].ToString()+"\n";
            }
        }
        else
        {
            Debug.Log("File is not there");
        }

    }

    //public void dire() {

    //    Debug.LogWarning("i am working");
    //    foreach (string file in Directory.GetFileSystemEntries(@"D:\db\leaderboard\"))
    //     {
    //       String[]leaderboard= File.ReadAllLines(file);
    //        for (int i = 0; i < leaderboard.Length; i++)
    //        {
    //            print(leaderboard[i]);

    //        }

    //     }


    // string contents = File.ReadAllText(file);
    //Console.WriteLine(contents);

    //}
    //public void fetchdata() {

    //    int fileCount = Directory.GetFiles(@"D:\db\leaderboard").Length;
    //    Console.WriteLine(fileCount);

    //    Lines = System.IO.File.ReadAllLines(@"D:/db/leaderboard" + Username + ".txt");
    //    foreach (char c in Lines)
    //    {

    //    }


    //    }


}

