using System;
using System.Threading;

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

            case 4:
                // About
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
        Root json = utils.GetJson();
        Console.Clear();
        utils.Line();

        // Ask the user to select a quiz
        string[] quizNames = new string[json.Quiz.ToArray().Length];
        for (int i = 0; i < quizNames.Length; i++) quizNames[i] = json.Quiz[i].Name;
        int quizSelect = utils.ArrowMenu("Select a quiz", quizNames);
        
        int score = 0;

        // Loop through all of the questions in the quiz
        foreach (QuestionObject question in json.Quiz[quizSelect].Questions)
        {
            // Put the questions and answers in a arrow menu
            Console.Clear();
            utils.Line();

            int answer = utils.ArrowMenu(question.Question, question.Answers.ToArray());

            // Check for if they gave the correct answer
            if (answer == question.Answer)
            {
                // Correct
                Console.ForegroundColor = ConsoleColor.Green;
                utils.CentreText("\n\nCorrect!");
                score++;
            }
            else
            {
                // Incorrect
                Console.ForegroundColor = ConsoleColor.Red;
                utils.CentreText("\n\nIncorrect!");
            }

            // Reset the color, give them their total score then wait a few seconds
            Console.ResetColor();
            utils.CentreText("Total score: " + score);
            utils.CentreText("\n\nPress any key to go onto the next question...");
            Console.ReadKey();
        }

        // When they have finished a quiz then bring them back to the menu
        Console.Clear();
        utils.Line();
        utils.CentreText($"You completed the quiz🤯🥳\nFinal score: {score}/{json.Quiz[quizSelect].Questions.ToArray().Length}");
        utils.CentreText("\n\nPress any key to go back to the main menu...");
        Console.ReadKey();
        Menu();
    }

    // Let the user create a quiz
    void MakeGame()
    {
        // Basic setup
        Utils utils = new Utils();
        Root json = utils.GetJson();


        // Ask the user for a quiz name
        Console.Write("What is the name of the quiz? ");
        string quizName = Console.ReadLine().ToString().Trim();

        // Ask them to enter a question, or answers
        int choice = utils.ArrowMenu("Please select an option", new[] { "Add question", "Back to menu" });
        if (choice == 0)
        {
            // Make initial variables
            string questionName;
            List<string> answers = new List<string>();
            int answer = 0;

            // Ask for the question and answers
            Console.Write("question name: ");
            questionName = Console.ReadLine().ToString().Trim();
            
            // Ask for how many answers
            while (true)
            {
                Console.Write("How many answers do you want? ");
                if (int.TryParse(Console.ReadLine(), out int numberOfAnswers))
                {
                    // Get all of the answers
                    for (int i = 0; i < numberOfAnswers; i++)
                    {
                        Console.Write($"Answer for question {i++}: ");
                        answers.Append(Console.ReadLine().Trim());
                    }

                    // get the correct answer
                    Console.WriteLine("\n\nSelect the correct answer");
                    for (int i = 0; i < answers.Count; i++)
                    {
                        Console.WriteLine($"{i++}) {answers[i]}");
                    }
                    while (true)
                    {
                        Console.Write("Correct answer: ");
                        if (int.TryParse(Console.ReadLine(), out answer))
                        {
                            answer -= 1;
                            Console.WriteLine("You have set the correct answer to " + answers[answer]);
                            break;
                        }
                    }
                }
                break;
            }

            // Create the question and add it to the quiz
            QuestionObject question = new QuestionObject()
            {
                Question = questionName,
                Answers = answers,
                Answer = answer
            };



            // Add it to the quiz
        }

    }
}
