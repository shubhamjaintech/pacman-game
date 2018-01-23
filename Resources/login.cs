using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using System.Xml.Linq;
using System.Xml;
using System.IO;

public class login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public GameObject displayloginmessage;
    //public static string logindataun;
    private string Username;
    private string Password;


    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Username != "" && Password != "")
            {
                
                loginButton();

            }
        }
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }

    public void loginButton()
    {
        
        string filePath = @"C:\Users\shubham\Documents\UnityProjects\pacman2d\Assets\Pacman-Game\Resources\users.xml";
        XmlDocument xmlDoc = new XmlDocument();
        if (File.Exists(filePath))
        {
            Debug.Log("File exists");
            xmlDoc.Load(filePath);
            XmlNodeList usersList = xmlDoc.GetElementsByTagName("details");
            foreach (XmlNode user in usersList)
            {
                if (user.SelectSingleNode("username").InnerText == Username)
                {
                    if (user.SelectSingleNode("password").InnerText == Password)
                    {
                        Debug.Log("user found");
                        //storing login credentials
                        usernamestaic.getsavedname= username.GetComponent<InputField>().text;

                        username.GetComponent<InputField>().text = "";
                        password.GetComponent<InputField>().text = "";
                        print("HI");
                        SceneManager.LoadScene("gamemv");
                        print("Login Successful");

           //             return true;
                    }
                }
            }
        }
        else
        {
            Debug.Log("File does not exists");
        }
        //return false;
    }
    //public void loginButton()
    // {
    //reading data from xml
    //ItemContainer ic = ItemContainer.Load(path);
    //foreach (Item item in ic.Items)
    //{
    //    print(item.password);
    //}

    //bool UN = false;
    //bool PW = false;
    ////checking username

    //       if (Username != "") {
    //           foreach (Item item in ic.Items)
    //           {
    //               if (item.name == Username) {
    //                   UN = true;
    //                   // Debug.LogWarning("user name found");

    //                   break;
    //               }

    //           }
    //           if(UN==false)
    //               {
    //               displayloginmessage.GetComponent<Text>().text += "\n Username donot exist";
    //               this.displayloginmessage.GetComponent<Text>().enabled = true;
    //               Debug.LogWarning("user name do not exist");

    //           }
    //       }
    //       else {
    //           displayloginmessage.GetComponent<Text>().text += "\n Username field empty";
    //           this.displayloginmessage.GetComponent<Text>().enabled = true;

    //           Debug.LogWarning("user name field empty");
    //       }

    //       //checking password
    //       if (Password != "") {
    //           foreach (Item item in ic.Items)
    //           {
    //               if (item.name == Username)
    //               { 
    //                   if (item.password==Password) {
    //                       PW = true;
    //                       break;
    //                   }

    //               }
    //           }
    //           if (PW == false)
    //           {
    //               displayloginmessage.GetComponent<Text>().text += "\n Invalid Password";
    //               this.displayloginmessage.GetComponent<Text>().enabled = true;
    //               Debug.LogWarning("Invalid Password");
    //            }
    //       }
    //       else {
    //           displayloginmessage.GetComponent<Text>().text += "\n Password Field Empty";
    //           this.displayloginmessage.GetComponent<Text>().enabled = true;

    //           Debug.LogWarning("Password Field Empty");
    //       } 

    //	if (UN == true && PW == true) {
    //           //storing login credentials
    //           this.logindataun = username.GetComponent<InputField>().text;
    //           username.GetComponent<InputField> ().text = "";
    //		password.GetComponent<InputField> ().text = "";
    //           print("HI");
    //           SceneManager.LoadScene("startmenu");
    //          print ("Login Successful");
    //       }
    //}

}
