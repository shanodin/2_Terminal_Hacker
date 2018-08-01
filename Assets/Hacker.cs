using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    
    // game statw

    private int level;
    enum Screen
    {
        MainMenu,
        Password,
        Win
    };
    private Screen currentScreen;
    private string password;

    // Use this for initialization
	void Start ()
	{
        ShowMainMenu();
	}

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Solve an anagram");
        Terminal.WriteLine("Press 1 for Easy");
        Terminal.WriteLine("Press 2 for Medium");
        Terminal.WriteLine("Enter your selection: ");
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = "otters";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "foxes";
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Choose a level, Mr Bond");
        }
        else
        {
            Terminal.WriteLine("Select a valid level");
        }
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go to the menu using this input
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.Password)
        {
            PasswordGuess(input);
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

     void StartGame()
     { 
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter a password");
        currentScreen = Screen.Password;
     }

    void PasswordGuess(string input)
    {
        if (level == 1 && input == password)
        {
            Terminal.WriteLine("Nice guess, let's play");
        }
        else if (level == 2 && input == password)
        {
            Terminal.WriteLine("Nice guess, let's play");
        }
        else
        {
            Terminal.WriteLine("Guess again");
        }
    }
}
