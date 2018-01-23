using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class register : MonoBehaviour {

	public GameObject username;
	public GameObject email;
	public GameObject password;
	public GameObject confpassword;
    public GameObject registermessage;
    public GameObject displayregistermessage;


    private string Username;
	private string Email;
	private string Password;
	private string Confpassword;
	private string form;
    private bool EmailValid=false;
		private string[] Characters = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
			"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
		"0","1","2","3","4","5","6","7","8","9","-","_"};



	// Use this for initialization
	void Start () {
        


    }

    public void registerButton(){
		bool UN = false;
		bool EM = false;
		bool PW = false;
		bool CPW = false;

		//checking same username exist or not
		if (Username != "") {
			if (!System.IO.File.Exists (@"D:/db/" + Username + ".txt")) {
				UN = true;
			} else {

                displayregistermessage.GetComponent<Text>().text += "\n Username already exists";
                this.displayregistermessage.GetComponent<Text>().enabled = true;

                Debug.LogWarning ("Username already exists");
			}
		} 
		else {

            displayregistermessage.GetComponent<Text>().text += "\n Username field empty";
            this.displayregistermessage.GetComponent<Text>().enabled = true;
            Debug.LogWarning ("Username field empty");
		}
	
		//checking email valid or not
		if (Email != "") {
			emailValidation();
			if (EmailValid) {
				if (Email.Contains ("@")) {
					if (Email.Contains (".")) {
						EM = true;
					} else {

                        displayregistermessage.GetComponent<Text>().text += "\n Incorrect Email";
                        this.displayregistermessage.GetComponent<Text>().enabled = true;
                        Debug.LogWarning ("Incorrect Email");
					}

				} else {

                    displayregistermessage.GetComponent<Text>().text += "\n Incorrect Email";
                    this.displayregistermessage.GetComponent<Text>().enabled = true;

                    Debug.LogWarning ("Incorrect Email");
				}
			} else {

                displayregistermessage.GetComponent<Text>().text += "\n Incorrect Email";
                this.displayregistermessage.GetComponent<Text>().enabled = true;

                Debug.LogWarning ("Incorrect Email");
			}
		} 
		else {

            displayregistermessage.GetComponent<Text>().text += "\n Email Field Empty";
            this.displayregistermessage.GetComponent<Text>().enabled = true;

            Debug.LogWarning ("Email field empty");
		}

		//checking password valid or not(password length etc)

		if (Password != "") {
			if (Password.Length > 6) {
				PW = true;
			} else {

                displayregistermessage.GetComponent<Text>().text += "\n Password Length should be greater than 6 characters";
    this.displayregistermessage.GetComponent<Text>().enabled = true;
        
                Debug.LogWarning ("Password Length should be greater than 6 characters");
			}
		} else {

            displayregistermessage.GetComponent<Text>().text += "\n Password Field empty";
            this.displayregistermessage.GetComponent<Text>().enabled = true;

            Debug.LogWarning ("Password Field empty");
		}

		//checking confpassword equal to password or not
		if (Confpassword != "") {
			if (Confpassword == Password) {
				CPW = true;
			} else {

                displayregistermessage.GetComponent<Text>().text += "\n Password Donot Match";
                this.displayregistermessage.GetComponent<Text>().enabled = true;

                Debug.LogWarning ("Passwords Donot Match");
			}
		} else {

            displayregistermessage.GetComponent<Text>().text += "\n Conf Password Field Empty";
            this.displayregistermessage.GetComponent<Text>().enabled = true;
            Debug.LogWarning ("Conf Password Field Empty");
		}

		//encrypting the password

		if (UN == true && EM == true && PW == true && CPW == true) {
			bool Clear = true;
			int i = 1;


			foreach (char c in Password){
				if(Clear){
					Password="";
					Clear=false;
				}

				i++;
				char Encrypted=(char)(c*i);
				Password+=Encrypted.ToString();
			}

			form=(Username+Environment.NewLine+Email+Environment.NewLine+Password);

			System.IO.File.WriteAllText(@"D:/db/" + Username + ".txt",form);
			username.GetComponent<InputField> ().text="";
			email.GetComponent<InputField> ().text="";
			password.GetComponent<InputField> ().text="";
			confpassword.GetComponent<InputField> ().text="";
            this.registermessage.GetComponent<Text>().enabled = true;

			print ("registeration success"); 
		}
	}
	void emailValidation(){
		bool SW = false;
		bool EW = false;
		for (int i = 0; i < Characters.Length; i++) {
			if(Email.StartsWith(Characters[i])){
				SW=true;
			}
		}
				for (int i = 0; i < Characters.Length; i++) {
			if(Email.EndsWith(Characters[i])){
						EW=true;
					}
						}
		if (SW == true && EW == true) {
			EmailValid = true;
		} else {
			EmailValid = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	//traversing from one inputbox to other
		if(Input.GetKeyDown(KeyCode.Tab)){
			if (username.GetComponent<InputField> ().isFocused) {
				email.GetComponent<InputField> ().Select ();
			}
			if (email.GetComponent<InputField> ().isFocused) {
				password.GetComponent<InputField> ().Select ();
			}	
			if (password.GetComponent<InputField> ().isFocused) {
				confpassword.GetComponent<InputField> ().Select ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (Username != "" && Email != "" && Password != "" && Confpassword != "") {
				registerButton ();
			}
		}
		Username = username.GetComponent<InputField> ().text;
		Email=email.GetComponent<InputField> ().text;
		Password=password.GetComponent<InputField> ().text;
		Confpassword=confpassword.GetComponent<InputField> ().text;
	}
	}



	
	
	

