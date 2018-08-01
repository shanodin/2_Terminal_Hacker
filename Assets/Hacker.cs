using UnityEngine;

public class Hacker : MonoBehaviour {
    
    // game configuration data
    private string[] level1Passwords = { "criminal", "anarch", "shaper", "sunny", "adam", "apex" };
    private string[] level2Passwords = { "jinteki", "haas bioroid", "weyland", "nbn" };

    // game state
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
        Terminal.WriteLine("Press 1 for Runner");
        Terminal.WriteLine("Press 2 for Corp");
        Terminal.WriteLine("Enter your selection: ");
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007") // easter egg
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

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("The password is an anagram of..." + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
    }

    void PasswordGuess(string input)
    {
        if (level == 1 && input == password)
        {
            DisplayWinScreen();
        }
        else if (level == 2 && input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You're a true Net Runner. All runners deserve cake:");
                Terminal.WriteLine(@"
  ___()___
 (        )
(__________)
 \        /
  \______/

                ");
                Terminal.WriteLine("Type menu to play again");
                break;
            case 2:
                Terminal.WriteLine("You really are a corporate shill. Light up:");
                Terminal.WriteLine(@"

                   (  )/  
                    )(/
 ________________  ( /)
()__)____________)))))  

                ");
                Terminal.WriteLine("Type menu to play again");
                break;
            default:
                Terminal.WriteLine("cheat, you didn't win");
                Debug.LogError("How did they get here?");
                break;
        }
    }
}
