![Long bay college logo](https://www.longbaycollege.com/wp-content/uploads/2020/09/Long_Bay_College_Logo_Tag2-1024x141.png)

# DTS NCEA Assessment - 91883
I will be using this GitHub repo to keep track of what I have done each day. It will have pseudocode, debugging, and program ideas. I have made the program in C#. **important:** You ___*need*___ to use a terminal that supports UTF-8. Don't use cmd and instead use something like [Windows Terminal](https://www.microsoft.com/en-nz/p/windows-terminal/9n0dx20hk701?activetab=pivot:overviewtab)
<br><br>
**What is the purpose of your quiz?**
<br>
My quiz program allows people to create and share quizes that they have made. It uses an external JSON file to do it so people can easily share different quizes.
<br>
**What style of quiz are you doing?**
<br>
My quiz is designed for people any age, as long as they can read the questions. It has been designed so that you can easiy answer the questions, and see the results.

---
## TODO
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
- Fixed stuff like spelling amd grammar in the code😳

### 7/3/2022
- Added a link to the GitHub, and a simple controls menu in the `About` method.
- Decided to switch to `System.Text.Json` (stj) because it is faster, and seems like a more modern way to handle JSON.
- Removed all newtonsoft code

### 8/3/2022
- Started to learn about `System.Text.JSon`.

### 9/3/2022
- Added a new method called `GetJson` into the `Utils` class that gives the Deserialized JSON quicker so I don't need to write it every time.
- Remade the entire `PlayGame` method. You can now select a quiz and play through it. After you finish a question it will wait for you to press a key then pass you onto the next question.
- Started working on the `MakeGame` method so that people can make their own quiz.
- Made `SetJson` function that quickly serializes the JSON back into the file.
- Removed a random `WriteLine` that printed the `index` from the `ArrowMenu` method.
- Started to tes the `MakeGame` method
- Added the ability to use the `tab` key to cycle through `ArrowMenu`
