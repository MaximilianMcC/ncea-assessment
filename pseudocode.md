# Pseudocode
This is all of my pseudocode for the different classes/files

## Program.cs
```

Make a main method
    Change the output encoding to UTF-8
    Set the title to "NCEA DTS Assesment"
    Instanciate the Program class and call {program.Menu()}

Make a Menu method
    Instanciate the utils class
    Clear the screen and print a title
    Call {utils.ArrowMenu} and make a menu { "Play Quiz", "Create Quiz", "Remove Quiz", "About", "Exit" } to a int called {menuInput}
    Use a switch statement to check for what method they want to call from {menuInput}
    Call {Enviroment.Exit(0)} for the exit option

Make an About method
    Instanciate the utils class
    Clear the screen and print a title
    Call {utils.Line}
    Call {utils.CentreText} and say some stuff about the quiz
    Change the foreground color to blue and call {utils.CentreText} to write the GitHub link
    Use {utils.CentreText} to print a menu that shows the controlls
    Ask the user to press any key to return to menu with {utils.CentreText}
    When they press a key call the {Menu()} method

Make a PlayGame method
    Instanciate the utils class
    Get the json with {Root json = utils.GetJson()}
    Clear the screen
    Call {utils.Line}
    Get all of the quiz names and store them in a {string[]}
    Make a new {utils.ArrowMenu} to show all of the different quizzes
    Make a new integer called score and set it to 0
        Loop through all of the questions in the selected quiz
        Clear the screen
        Call {utils.Line}
        Use {utils.ArrowMenu} to show the questions and answers
        Check for if they gave the correct answer
        If they did then Set the foreground color to green and say that they are correct. Add 1 to the score variable
        If they didn't get it correct then set the foreground color to red and say incorrect
        Reset the color
        Say the total score
        Tell them to press any key to go to the next question
        Get key input
    Clear the screen
    Call {utils.Line}
    Get the questions length
    Use {utils.CentreText} to tell them that they finsshed the quiz
    If they got all correct then say
    If they got none correct then say
    Ask them to press any key to get back to menu
    When they press a key call {Menu}

Make a MakeGame method
    Instanciate the utils class
    Get the json with {Root json = utils.GetJson()}
    Clear the screen
    Get the quiz name as a string
    Make a new list of questions
    Make a new quiz
        while true loop
        Ask they if they want to add a question or finish the quiz
        If they choose to add a question clear the screen
            Ask them for the question name as a string
            Ask them for how many answer as an integer
            Make a new strng list called questionAnswers
            Use a for loop to get the answers and add them to the list
            Ask them for what the correct answer is in questionAnswer
            Take 1 from questionAnswer
            Add a new question to the questions list with all of the question data gatherd earlier
        If they chose to finish the quiz clear the screen
            Call {Root deserializedJson = utils.GetJson()}
            Add the quiz to the deserialized
            Call {utils.SetJson(deserializedJson)}
        If they chose to go back to menu call {Menu()}

Make a RemoveGame method
    Instanciate the utils class
    Get the json with {Root json = utils.GetJson()}
    Clear the screen
    Call {utils.Line}
    Get all of thw quiz names
    Call {utils.CentreText} to get the quiz they want to remove
    Call {utils.CentreText} to check for if they want to delete it
    if they do remove the quiz from the json
        Set the json to the new removed quiz
        Tell them using {utils.CentrText} that they removed it
    If they didnt then go back to menu
```

## JSON.cs
```
Make a Root class
    Make a list with type as Quiz getter and setter

Make a Quiz class
    Make a string getter and setter for name
    Make a list of QuestionObjects getter and setter

Make a QuestionObject class
    Make a string called question getter and setter
    Make a list of strings called answers getter and setter
    Make an int called answer getter and setter
```

## Utils.cs
```
import {System.Text.Json}

Make a CentreText method with parameters {string text}
Split the text by {"\n"} and store in a new string[] called lines
Loop through each line
    Set the console cursor position to {(Console.WindowWidth - line.Length) / 2, Console.CursorTop}
    Print the current line

Make a new Line method
    For to loop through {Console.WindowWidth}
        Print {"-"} to the console

Make a ArrowMenu method with the parameters {string[] items, string title = "", string cursor = "▶"}
    Make an integer called padding and set the value to 10
    If the title length is not even make it even by adding {" "} to the end
    Find the longest item in the items array
    Make a new variable called menuWidth and set it to {2 + (padding * 2) + longestItem}
    Make a new string called menuHeader and set it to {"╔"} loop over menuWidth and add {"═"} to menuHeader
    Add {"╗\n"} to menuHeader
    Check for if {title != ""} if it is then
        Make a new string called space with a value of ""
        Loop through {(menuWidth - title.Length) / 2} and add {" "} to space
        Make a new string called menuHeader and set it to {$"║{space}{title}{space}║\n╟"}
        Loop through menuWidth and add {"─"} to MenuHeader
        Add {"╢"} to menu header
    Call {CentreText(MenuHeader)}
    Make a new string called menuFooter and set it to {"╚"}
    Loop through menuWidth and add {"═"} to menuFooter
    Add {"╝"} to MenuFooter
    Make a new int called index and set it to 0
    Make a new ConsoleKeyInfo called input
    Make a new int called menuItemsStart and set it to {Console.CursorTop}
    do
        Set the console cursor position to {Console.CursorLeft, menuItemsStart}
        Check for if {index > items.Length - 1} and set index to 0
        Check else if {index < 0} set {index = items.Length - 1}
        Make a new string[] called menuItems and set the length to {items.Length}
        Loop through {items.Length}
            make a new string called space with a value of {""}
            Loop through {menuWidth - items[i].Length - 2} and add {" "} to space
            Check for if {i == index} then {CentreText($"║{cursor} {items[i]}{space}║")}
            else {CentreText($"║  {items[i]}{space}║")}
        Call {CentreText(menuFooter)}
        Set input to {Console.ReadKey(true)}
        If {input.Key == ConsoleKey.UpArrow} then {index--}
        Else if {input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.Tab} then {index++}
        End the do...while loop with {while (input.Key != ConsoleKey.Enter)}
    return index

Make a GetTextInput method with the parameters {string prompt}
    prin the prompt
    Set the foreground color to Yellow
    Make a new string called input and set it to {Console.ReadLine().Trim()}
    Reset the console color
    return input

Make a GetNumberInput method with the parameters {string prompt, string errorMessage = "Please use a number..."}
    Make a {while (true)} loop
        Check for {if (int.TryParse(GetTextInput(prompt), out int result))} then return result
        Else print errorMessage to the screen

Make a method called GetJson
    Make a new string called jsonFile with the value {@"./data.json"}
    {return JsonSerializer.Deserialize<Root>(File.ReadAllText(jsonFile), new JsonSerializerOptions {
			PropertyNameCaseInsensitive = true
	});}

Make a SetJson method with the parameters {Root json}
    Make a new string called jsonFile with the value {@"./data.json"}
    {		string serializedJson = JsonSerializer.Serialize(json, new JsonSerializerOptions {
			WriteIndented = true
	});}
    Write all text in serializedJson to the json file

```
