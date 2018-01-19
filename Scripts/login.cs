using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
	public GameObject username;
	public GameObject password;
    public GameObject displayloginmessage;
    private string Username;
	private string Email;
	private string Password;
	private string[] Lines;
	private string DecryptedPass;

    // Update is called once per frame
    void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (username.GetComponent<InputField> ().isFocused) {
				password.GetComponent<InputField> ().Select ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
            if (Username != "" && Password != "")
            {
                loginButton();
            
            }
        }
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }

	public void loginButton ()
	{
		bool UN = false;
		bool PW = false;
		//checking username
		if (Username != "") {
			if (System.IO.File.Exists (@"D:/db/" + Username + ".txt")) {
				UN = true;
				Lines = System.IO.File.ReadAllLines (@"D:/db/" + Username + ".txt");

			} else {

                displayloginmessage.GetComponent<Text>().text += "\n Username donot exist";
                this.displayloginmessage.GetComponent<Text>().enabled = true;

                Debug.LogWarning ("user name do not exist");
			}
		} else {
            displayloginmessage.GetComponent<Text>().text += "\n Username field empty";
            this.displayloginmessage.GetComponent<Text>().enabled = true;

            Debug.LogWarning ("user name field empty");
		}

		//checking password
		if (Password != "") {
			if (System.IO.File.Exists (@"D:/db/" + Username + ".txt")) {
				int i = 1;
				foreach (char c in Lines[2]) {
					i++;
					char Decrypted = (char)(c / i);
					DecryptedPass += Decrypted.ToString ();
				}
				if (Password == DecryptedPass) {
					PW = true;
				} else {
                    displayloginmessage.GetComponent<Text>().text += "\n Invalid Password";
                    this.displayloginmessage.GetComponent<Text>().enabled = true;

                    Debug.LogWarning ("Invalid Password");
				}
			} else {

                displayloginmessage.GetComponent<Text>().text += "\n Invalid Password";
                this.displayloginmessage.GetComponent<Text>().enabled = true;

                Debug.LogWarning ("Invalid Password");
			}
		} else {
            displayloginmessage.GetComponent<Text>().text += "\n Password Field Empty";
            this.displayloginmessage.GetComponent<Text>().enabled = true;

            Debug.LogWarning ("Password Field Empty");
		}

		if (UN == true && PW == true) {

			username.GetComponent<InputField> ().text = "";
			password.GetComponent<InputField> ().text = "";
            
             SceneManager.LoadScene("startmenu");

           print ("Login Successful");



        }
	}

	}
