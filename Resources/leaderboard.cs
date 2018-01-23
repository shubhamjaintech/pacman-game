using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class leaderboard : MonoBehaviour
{

    public Text username;
    public Text score;
    void Start() {
       displayleaderboard();
    }
    public void displayleaderboard()
    {
        string filePath=@"C:\Users\shubham\Documents\UnityProjects\pacman2d\Assets\Pacman-Game\Resources\db\users.xml";
        //string filePath = Application.dataPath + @"/Pacman-Game/Resources/db/users.xml";
        //Hashtable ht = new Hashtable();

        List<User> list = new List<User>();
        XmlDocument xmlDoc = new XmlDocument();
        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);
            XmlNodeList playerlist = xmlDoc.GetElementsByTagName("details");
            foreach (XmlNode user in playerlist)
            {
                list.Add(new User(int.Parse(user.SelectSingleNode("score").InnerText), user.SelectSingleNode("username").InnerText ));
            }

            // Get a collection of the keys.
            //ICollection key = ht.Keys;
            list.Sort((x, y) => y.score.CompareTo(x.score));
            foreach (User listnode in list )
            {
                //Debug.Log(k + ": " + ht[k]);
                username.text += listnode.username+ "\n";
                score.text += ""+listnode.score+ "\n";
            }

            //sorting hashtable accoring to value
            //Dictionary<string,int>dt= HashtableToDictionary<string,int>(ht);
            //IEnumerable<Dictionary<string,int>>d =ht.Cast<Dictionary<string,int>>().ToList();
            
            //var items = from pair in dt
            //        orderby pair.Value descending
            //        select pair;

            // Display results.
            //foreach (KeyValuePair<string, int> pair in items)
            //{   
            //    Debug.Log( pair.Key+pair.Value);
            //}

            
        }
        
        else
        {
            Debug.Log("File is not there");
        }

    }
    //public static Dictionary<K, V> HashtableToDictionary<K, V>(Hashtable table)
    //{
    //    return table
    //      .Cast<DictionaryEntry>()
    //      .ToDictionary(kvp => (K)kvp.Key, kvp => (V)kvp.Value);
    //}
    public void closegame() {
        Debug.Log("closed");
        //it will close the game in the final build and not in editor
        SceneManager.LoadScene("endscreen");
        Application.Quit();
    }
    //public static void sortLeaderboard(int score)
    //{


    //    string filePath = Application.dataPath + @"/Pacman-Game/Resources/db/users.xml";;

    //    XmlDocument xmlDoc = new XmlDocument();
    //    if (File.Exists(filePath))
    //    {
    //        xmlDoc.Load(filePath);
    //        XmlNodeList usersList = xmlDoc.GetElementsByTagName("details");
    //        foreach (XmlNode user in usersList)
    //        {
    //            if (user.SelectSingleNode("username").InnerText == usernamestaic.getsavedname)
    //            {
    //                if (int.Parse(user.SelectSingleNode("score").InnerText.ToString()) < score)
    //                {
    //                    Debug.Log("score added");
    //                    user.SelectSingleNode("score").InnerText = score.ToString();
    //                    xmlDoc.Save(filePath);
    //                }
    //                return;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("File does not exists");
    //    }
    //}

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

