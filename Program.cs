public class Program {

	public static void Main(string[] args)
	{

		// General stuff
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.Title = "NCEA DTS Assessment";

		// Start the game
        Program program = new Program();
        program.Menu();
	}

	void Menu()
	{
		Utils utils = new Utils();

        // Title
		Console.Clear();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\n\n");
        utils.CentreText(" ██████╗  █████╗ ███╗   ███╗███████╗");
        utils.CentreText("██╔════╝ ██╔══██╗████╗ ████║██╔════╝");
        utils.CentreText("██║  ██╗ ███████║██╔████╔██║█████╗  ");
        utils.CentreText("██║  ╚██╗██╔══██║██║╚██╔╝██║██╔══╝  ");
        utils.CentreText("╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗");
        utils.CentreText(" ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝");
        utils.CentreText("Max McCarthy\n\n\n");
        Console.ResetColor();

        // Game start Menu
        int menuInput = utils.ArrowMenu("Please Select an option", new[] { "Play Quiz", "Create Quiz", "About", "Exit" });
        switch (menuInput)
        {
            case 0:
                // Play game
				PlayGame();
                break;

            case 1:
                // Make game
                MakeGame();
                break;

            case 2:
                // Load
                About();
                break;

            case 3:
                // About
                About();
				break;
            
            case 4:
                // Exit
                Environment.Exit(0);
                break;
        }
	}

    void About()
    {
        Utils utils = new Utils();
        Console.Clear();
        utils.Line();

        utils.CentreText("This quiz was made for my DTS Assessment. This was originally going to be a massive gam but it would have been too much work to write stuff like pseudocode.\nThe quiz reads questions and answers from an external JSON file. The entire program is OOP and uses multiple classes and methods.\n\n\nPress any key to return to menu...");
        Menu();
    }

	void PlayGame()
	{
        // Basic setup
		Utils utils = new Utils();

        // Get the JSON
        Root json = utils.GetJson();
        int score = 0;

        // print all of the questions
        foreach (Quesions question in json.Questions)
        {
            // Reset everything
            Console.Clear();
            utils.Line();
            Console.WriteLine("\n\n");

            // Show the question in the arrow menu
            int answer = utils.ArrowMenu(question.Question, question.Answers.ToArray());
            if (answer == question.Answer)
            {
                // Correct answer
                score++;

                Console.ForegroundColor = ConsoleColor.Green;
                utils.CentreText("Correct! score: " + score);
                Console.ResetColor();
            }
            else
            {
                // Wrong answer
                Console.ForegroundColor = ConsoleColor.Red;
                utils.CentreText("Wrong! score: " + score);
                Console.ResetColor();
            }

            // Tell them that they can continue
            utils.CentreText("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        // Say that all of the questons have ended
        Console.Clear();
        utils.Line();
        Console.WriteLine("\n\n");
        utils.CentreText("You Have finished the quiz! Select and option below");

        int returnAnswer = utils.ArrowMenu(items:new[] {"Back to menu", "Exit"});
        if (returnAnswer == 0)
        {
            Menu();
        }
        else
        {
            utils.CentreText("\n\nThanks for playing. Your total score was: " + score);
            utils.CentreText("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
	}

    void MakeGame()
    {
        
    }
}