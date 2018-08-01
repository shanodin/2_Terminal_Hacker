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

    // Use this for initialization
	void Start ()
	{
        ShowMainMenu();
	}

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hey");
        Terminal.WriteLine("Solve an anagram");
        Terminal.WriteLine("Press 1 for Easy");
        Terminal.WriteLine("Press 2 for Medium");
        Terminal.WriteLine("Press 3 for Hard");
        Terminal.WriteLine("Enter your selection: ");
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
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
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

     void StartGame() { 
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter a password");
         currentScreen = Screen.Password;
     }
}
