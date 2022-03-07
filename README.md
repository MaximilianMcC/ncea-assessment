![Long bay college logo](https://www.longbaycollege.com/wp-content/uploads/2020/09/Long_Bay_College_Logo_Tag2-1024x141.png)

# DTS NCEA Assessment - 91883
I will be using this `md` file to keep track of what I have done each day. It will have pseudocode, debugging, and program ideas. All of the quiz data will be in a JSON file.

---
## TODO
1. [x] Make `Utils` and `Program` class.
1. [x] Load questions from the JSON.
1. [ ] Create questions and save in the JSON
1. [ ] Write Pseudocode 
1. [ ] Refactor all code before exporting to exe

---

## Version 1
### Can't remember date
- Started creation on project.
- I made `CentreText` method, and started to work on the `ArrowMenu` method.

### Can't remember date
- Made `JSON`, `Menus`, `utils`, `game` classes

### 4/3/2021
- Deleted version 1 and started again from scratch. Everything got really complicated for no reason. I also decided to make the new game in a different style because it was going to take too long to write the pseudocode and log every single little error and change.
---
## Version 2
### 4/3/2021
- Created project
- Made `Program`, `Game`, and `Utils` classes.
- Improved `CentreText` method to allow multiple lines using the `\n` escape sequence
- Started to work on improved `ArrowMenu` method that would be in the centre

### 5/3/2021
- Made a successful working `ArrowMenu` function in the centre of the screen.
- Made main menu for the game
- Created `./data.json` file and wrote some test questions
- Relearnt how to use `Newtonsoft.Json` Library. Made a way to deserialize `./data.json` and created `Json.cs` which stores the outline of the json in two classes. `Root`, and `Questions`.
- Created the main game in a method called `PlayGame`. It would loop through all questions in the JSON file then print them out using the `ArrowMenu` method.

### 6/3/2021
- Removed `Game` class because it was unneeded. Moved everything into `Program` class instead.
- Made a `Line` function that would create a simple line across the screen.
- Made an `About` method that just gave some info about the game and the ncea stuff.
- Switched encoding to `UTF-8` so that I can use emojis and special characters. (Need to use a terminal such as WT to run now)
- Learnt the basics of how to use GitHub and uploaded all current code.
- Fixed stuff like spelling amd grammar in the code😳

### 7/3/2021
- Added a link to the GitHub, and a simple controls menu in the `About` method.
- Decided to switch to `System.Text.Json` instead of `Newtonsoft.Json`. Started to remove old JSON code and add new STJ code.
