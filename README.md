![Long bay college logo](https://www.longbaycollege.com/wp-content/uploads/2020/09/Long_Bay_College_Logo_Tag2-1024x141.png)

# DTS NCEA Assessment - 91883
I will be using this GitHub repo to keep track of what I have done each day. It will have pseudocode, debugging, and program ideas. I have made the program in C#. You can download and run the code [Here](https://github.com/MaximilianMcC/ncea-assessment/releases/tag/FinishedProgram)


**What is the purpose of your quiz and what is it?**
My quiz has been made so that other people can create, share, and play quizzes that they create with the program. This means that you can use the same program, but get different quizzes. All of the questions are stored in an external `JSON` file so that people who know how to write json can add their own questions in there. There is also a more user-friendly quiz genrator inside the program.


---
## TODO
1. [x] Load questions from the JSON.
1. [x] Create questions and save in the JSON
1. [x] Remove questions from the JSON
1. [x] Write Pseudocode 
1. [ ] Refactor all code before exporting to exe

---

## Version 1
### Can't remember date
- Started creation on project.
- I made `CentreText` method, and started to work on the `ArrowMenu` method.

### Can't remember date
- Made `JSON`, `Menus`, `utils`, `game` classes

### 4/3/2022
- Deleted version 1 and started again from scratch. Everything got really complicated for no reason. I also decided to make the new game in a different style because it was going to take too long to write the pseudocode and log every single little error and change.
---
## Version 2

### 4/3/2022
- Created project
- Made `Program`, `Game`, and `Utils` classes.
- Improved `CentreText` method to allow multiple lines using the `\n` escape sequence
- Started to work on improved `ArrowMenu` method that would be in the centre

### 5/3/2022
- Made a successful working `ArrowMenu` function in the centre of the screen.
- Made main menu for the game
- Created `./data.json` file and wrote some test questions
- Relearnt how to use `Newtonsoft.Json` Library. Made a way to deserialize `./data.json` and created `Json.cs` which stores the outline of the json in two classes. `Root`, and `Questions`.
- Created the main game in a method called `PlayGame`. It would loop through all questions in the JSON file then print them out using the `ArrowMenu` method.

### 6/3/2022
- Removed `Game` class because it was unneeded. Moved everything into `Program` class instead.
- Made a `Line` function that would create a simple line across the screen.
- Made an `About` method that just gave some info about the game and the ncea stuff.
- Switched encoding to `UTF-8` so that I can use emojis and special characters. (Need to use a terminal such as WT to run now)
- Learnt the basics of how to use GitHub and uploaded all current code.
- Fixed stuff like spelling and grammar in the code😳

### 7/3/2022
- Added a link to the GitHub, and a simple controls menu in the `About` method.
- Decided to switch to `System.Text.Json` (stj) because it is faster, and seems like a more modern way to handle JSON.
- Removed all newtonsoft code

### 8/3/2022
- Started to learn about `System.Text.JSon` in another test program.

### 9/3/2022
- Added a new method called `GetJson` into the `Utils` class that gives the Deserialized JSON quicker so I don't need to write it every time.
- Remade the entire `PlayGame` method. You can now select a quiz and play through it. After you finish a question it will wait for you to press a key then pass you onto the next question.
- Started working on the `MakeGame` method so that people can make their own quiz.
- Made `SetJson` function that quickly serializes the JSON back into the file.
- Removed a random `WriteLine` that printed the `index` from the `ArrowMenu` method.
- Started to tes the `MakeGame` method.
- Added the ability to use the `tab` key to cycle through `ArrowMenu`.

### 16/3/2022
- Made a quick prototype of the `MakeGame` function, then started to rewrite it.
- Added a `GetTextInput` method that gets quick console input.
- Added a `GetNumberInput` function that lets you get quick console input returned as an integer.
- Started to make a `CentreInput` method that will let you type something in the middle of the screen. Might remove.
- Made a `RemoveGame` method that lets the user remove a quiz that they have made or don't like.
- Added `ClearLine` function to clear a single line from the console instead of the entire console.

### 17/3/2022
- Added an optional parameter to have a custom "cursor" icon in the `ArrowMenu` method. Needed to change where the title parameter was declared.
- Finished the `RemoveGame` method.
- Removed `ClearLine` method because it wasn't being used.
- Started to improve `CentreInput` method, but thinking of removing it because there isn't really any point and it looks really strange.

### 23/3/2022
- Added a small part that tells you a custom message if you get all of the questions correct, or if you got none of the questions correct.

### 24/3/2022
- Created `pseudocode.md` so that I can start writing pseudocode.
- Started to write pseudocode for `Program.cs`

### 26/3/2022
- Added background music that loops
- Removed the background music because it didn't suit the style of the game

### 30/3/2022
- Remade the pseudocode file because I was making it too complicated for no reason
- Removed the `CentreInput` method because it wasn't used
- Found everywhere where `json.ToArray().Length` was used and changed it to `json.Count`
- Finished the `Program.cs` pseudocode
- Started the `JSON.cs` pseudocode
- Finished the `JSON.cs` pseudocode
- Started `Utils.cs` pseudocode
- Removed the feature to print half a line in `Utils.Line` because it's never used
- Finised the `Utils.cs` pseudocode

### 31/3/2022
- Added error testing

### 1/4/2022
- Deleted all code and started to remake in Scratch🤣🤣🤣
- Changed `utils.Line` to make a new line after and have better character
- Game now checks for if there is a valid `data.json` file in current directory
- Switched order of removing quiz
- Removed the feature to check for if there is valid json file.
- Made it so that you can't delete a quiz if there is only one
- Removed ability to have a custom cursor on `ArrowMenu()` menu because it was messing with the spacing

### 6/4/2022
- Removed all emojis as they only really work if you are using Windows Terminal and its not default installed on the school computers because they are still on Windows 10

---

## Debug and testing stuff
| **Error** | **Problem** | **Fix** |
|---|---|---|
| `;` expected | Forgot to add a semicolon | Added the semicolon |
| Cannot implicitly convert type `List<T>` to `string[]` | Tried to use a List as a String | Used `.ToArray()` |
| IndexOutOfRange | I accadentally added to the array instead of removing | Chaneged the `+` to a `-` |
| `;` expected | Forgot to add a semicolon | Added the semicolon |
| `i` does not exist in the current context | Used `i` instead of `index` | Switched `i` for `index`
| Can not convert type `char` to `string` | Used single quotes instead of double quotes | Used double quotes |
| Menu input in `ArrowMenu` is backwards | Down arrow makes the menu go up, and up arrow make sit go down | Switched what each key does |
| `data.json` is being used by another process | Another process is trying to use the JSON file | Removed un used `File.Create()`

---

## C# Programming Conventions
I have followed C# programming conventions in this program. Here are the conventions that I followed:
- Naming conventions
- Commenting conventions
- Layout conventions
- Knowing when to use data types
- Using the new opperator

Here are some examples of the conventions:
Naming conventions
```cs
// Print text in the centre of the screen
public void CentreText(string text)
```
```cs
int longestItem = title.Length;
```
```cs
Utils utils = new Utils();
```
```cs
List<string> questionAnswers = new List<string>();
```
```cs
int menuInput = utils.ArrowMenu(new[] { "Play Quiz", "Create Quiz", "Remove Quiz", "About", "Exit" }, "Please Select an option");
```

---

## C# Error testingi
| **Enterd data** | **Expected output** | **Output** | **Correct** |
|---|---|---|---|
| `"test"` | `"Please use a number"` will be returned | `"Please use a number"` | ✅
| `ConsoleKey.DownArrow` | Menu index will increase | Menu index decreased | ❌
| `ConsoleKey.UpArrow` | Menu index will decrease | Menu index increased | ❌
| `ConsoleKey.DownArrow` | Menu index will decrease | Menu index increased | ✅
| `ConsoleKey.UpArrow` | Menu index will increase | Menu index decreased | ✅
| `ConsoleKey.Enter` | Index should be returned | Index is too high | ❌
| `ConsoleKey.Enter` | Index should be returned | Correct index | ✅
| `12` | `12` will be returned | `12` | ✅
| `"Test"` | `"test"` will be returned | `"test"` | ✅
