using System;
using System.Collections.Generic;

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
        int menuInput = utils.ArrowMenu(new[] { "Play Quiz", "Create Quiz", "Remove Quiz", "About", "Exit" }, "Please Select an option");
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
                // Remove
                RemoveGame();
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
        utils.CentreText("║ Next item    ║ tab         ║");
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
        string[] quizNames = new string[json.Quiz.Count];
        for (int i = 0; i < quizNames.Length; i++) quizNames[i] = json.Quiz[i].Name;
        int quizSelect = utils.ArrowMenu(quizNames, "Select a quiz");
        
        int score = 0;

        // Loop through all of the questions in the quiz
        foreach (QuestionObject question in json.Quiz[quizSelect].Questions)
        {
            // Put the questions and answers in a arrow menu
            Console.Clear();
            utils.Line();

            int answer = utils.ArrowMenu(question.Answers.ToArray(), question.Question);

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
            utils.CentreText("\n\nPress any key to proceed...");
            Console.ReadKey();
        }

        // When they have finished a quiz then display a message
        Console.Clear();
        utils.Line();
        int questionsLength = json.Quiz[quizSelect].Questions.Count;

        utils.CentreText($"You completed the quiz🤯🥳\nFinal score: {score}/{questionsLength}");
        if (score <= 0) utils.CentreText("You got no questions correct😂");
        else if (score >= questionsLength) utils.CentreText("You got all correct😤👍");

        // Bring them back to the menu
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
        Console.Clear();
        
        // Ask them for the quiz name and make the quiz
        string quizName = Console.ReadLine().Trim();
        List<QuestionObject> questions = new List<QuestionObject>();
        Quiz quiz = new Quiz() { Name = quizName, Questions = questions } ;

        while (true)
        {
            // Ask them what they want to do
            int selection = utils.ArrowMenu(new[] { "Add question", "Finish quiz", "Back to menu" }, "Select an option");
            if (selection == 0)
            {
                Console.Clear();
                
                // Ask them for what the question is and how many answers
                string questionName = utils.GetTextInput("Question name: ");
                int answersLength = utils.GetNumberInput("How many answers? ");

                // Ask them what all of the answers are
                List<string> questionAnswers = new List<string>();
                for (int i = 0; i < answersLength; i++)
                {
                    questionAnswers.Add(utils.GetTextInput($"Answer {i + 1}) "));
                }

                // Ask them for what the answer is
                int questionAnswer = utils.GetNumberInput("Answer number: ");
                questionAnswer--;

                // Create and add the question to the quiz
                questions.Add(new QuestionObject() {
                    Question = questionName,
                    Answers = questionAnswers,
                    Answer = questionAnswer
                });
            }
            else if (selection == 1)
            {
                Console.Clear();

                // Generate a new quiz with the questions
                Root deserializedJson = utils.GetJson();
                deserializedJson.Quiz.Add(quiz);
                utils.SetJson(deserializedJson);
            }
            else if (selection == 2)
            {
                // Go back to the menu
                Menu();
            }

        }

    }

    void RemoveGame()
    {
        // Basic setup
        Utils utils = new Utils();
        Root deserializedJson = utils.GetJson();

        Console.Clear();
        utils.Line();

        // Ask the user to select a quiz
        string[] quizNames = new string[deserializedJson.Quiz.Count];
        for (int i = 0; i < quizNames.Length; i++) quizNames[i] = deserializedJson.Quiz[i].Name;
        int quizSelect = utils.ArrowMenu(quizNames, "Select a quiz to remove", "🗑");

        // Ask them if they are sure they want to delete it
        int wantToDelete = utils.ArrowMenu(new[] { "Delete quiz", "Cancel" }, $"Are you sure you want to delete '{deserializedJson.Quiz[quizSelect]}'?");
        if (wantToDelete == 0)
        {
            // Remove the quiz
            deserializedJson.Quiz.Remove(deserializedJson.Quiz[quizSelect]);
            utils.SetJson(deserializedJson);
            
            // Tell them that they removed it
            utils.CentreText("\n\nThe quiz has successfully been removed.\nPress any key to return to menu...");
            Console.ReadKey();
            Menu();
        }     
        else
        {
            // Put them back to the menu
            Menu();
        }
    }
}
