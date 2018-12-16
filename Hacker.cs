using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    string[] level1Passwords = { "books", "pencil", "bookshelf", "aisle", "silence" };
    string[] level2Passwords = { "suspect", "handcuffs", "precinct", "interrogate", "guilty" };
    string[] level3Passwords = { "rocket", "spacestation", "space", "telescope" };


    //Game state
    int level = 1;
    string password;



    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    //Use this for initialization
    void Start()
    {
        ShowMainMenu();
        print("Hello" + "World");

    }

    void ShowMainMenu(string Greeting = "Hello there")
    {
        var greeting = "Hello there ";
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What do you want to hack?");
        Terminal.WriteLine("Press 1 for The Library");
        Terminal.WriteLine("Press 2 for the Police Station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection: ");
        currentScreen = Screen.MainMenu;

    }

    // this should only decide how or who to handle input, not actually do it
    void OnUserInput(string input)
    {

        if (input == "menu") // we can always go directly to main menu
        {
            ShowMainMenu();


        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);

        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void RunMainMenu(string input)
    {


        {
            bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
            if (isValidLevelNumber)
            {
                level = int.Parse(input);
                StartGame();
            }



            else if (input == "clear")
            {
                Terminal.ClearScreen();
            }
            else
            {
                Terminal.WriteLine("Please enter a valid selection");
            }
        }
    }


    void StartGame()
    {

        currentScreen = Screen.Password;
        switch (level)
        {

            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter password, Hint: " + password.Anagram());
        print(password);


    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            showWinScreen();
        }
        else
        {
            Terminal.WriteLine("Try again");
        }
    }


    void showWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        showLevelReward();
    }

    void showLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You are in");
                Terminal.WriteLine(@"
      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\      
`----------`-'----------'
");
                break;
            case 2:
                Terminal.WriteLine("Congrats");
                Terminal.WriteLine(@"
 __________  
 / '|   ()_________)
 \ '/    \ ~~~~~~~~ \
   \       \ ~~~~~~   \
   ==).      \__________\
  (__)       ()__________)
");

                break;
            case 3:
                Terminal.WriteLine("You hacked it");
                Terminal.WriteLine(@"
        |
       / \
      / _ \
     |.o '.|
     |'._.'|
     |     |
   ,'|  |  |`.
  /  |  |  |  \
  |,-'--|--'-.| 

");
                break;
        }
    }
}


