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
                //! MakeGame();
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

        // Give a short explanation of the quiz/game
        utils.CentreText("\n\n\nThis quiz was created for my DTS NCEA Assessment.\nI was originally going to make a much bigger game that had stuff like a story, boss fights, and ascii movement\nbut it was going to be too annoying to write all of the pesudocode and document all errors and debugging.\n\nThis is a really simple quiz program that reads questions from an external file.\n\n");
        
        // Show them a link to the GutHub repo even though they can't click on it
        Console.ForegroundColor = ConsoleColor.Blue;
        utils.CentreText("https://github.com/MaximilianMcC/ncea-assessment");
        Console.ResetColor();

        // Show a quick table that has all of the controlls
        utils.CentreText("\n\n╔════════════════════════════╗");
        utils.CentreText("║       Quiz Controlls       ║");
        utils.CentreText("╟──────────────╥─────────────╢");
        utils.CentreText("║ Move up      ║ up arrow    ║");
        utils.CentreText("║ Move down    ║ down arrow  ║");
        utils.CentreText("║ Select       ║ enter       ║");
        utils.CentreText("╚══════════════╩═════════════╝");


        // Go back to the menu
        utils.CentreText("\n\n\nPress any key to return to menu...");
        Console.ReadKey();
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
    }
}
