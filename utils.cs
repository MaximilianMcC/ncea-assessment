using System.Text.Json;

public class Utils {
	
	// Put text in the centre of the screen
	public void CentreText(string text)
	{
		// Split the string into lines then loop through them and put them in the centre
		string[] lines = text.Split("\n");
		foreach (string line in lines)
		{
			Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
			Console.WriteLine(line);
		}

	}

	// Make a line accross the screen
	public void Line()
	{
		// Generate the line
		for (int i = 0; i < Console.WindowWidth; i++)
		{
			Console.Write("─");
		}
		Console.WriteLine();
	}

	// Make a menu that can be navigated using the arrow keys
	public int ArrowMenu(string[] items, string title = "")
	{
		int padding = 10;

		// Make the title in the centre
		//! Don't know if this is actually doing anything
		Console.WriteLine(title.Length);
		if (title.Length % 2 == 0) title += " ";
        Console.WriteLine(title.Length);

        // Get the longest item
        int longestItem = title.Length;
		foreach (string item in items)
		{
			if (item.Length > longestItem) longestItem = item.Length;
		}

		// Get the menu width and make it even
		int menuWidth = 2 + (padding * 2) + longestItem;

		// Make the top part of the menu
		string menuHeader = "╔";
		for (int i = 0; i < menuWidth; i++) menuHeader += "═";
		menuHeader += "╗\n";

		// Check if they want to add a title then add it
		if (title != "")
		{
			string space = "";
			for (int i = 0; i < (menuWidth - title.Length) / 2; i++) space += " ";

			menuHeader += $"║{space}{title}{space}║\n╟";
			for (int i = 0; i < menuWidth; i++) menuHeader += "─";
			menuHeader += "╢";
		}

		// Print the menu header
		CentreText(menuHeader);


		// Make the bottom part of the menu (added at bottom of do while loop)
		string menuFooter = "╚";
		for (int i = 0; i < menuWidth; i++) menuFooter += "═";
		menuFooter += "╝";

		int index = 0;
		ConsoleKeyInfo input;
		int menuItemsStart = Console.CursorTop;

		// Main menu loop
		do
		{
			// Set the cursor postion so that we don't get lots of different menus
			Console.SetCursorPosition(Console.CursorLeft, menuItemsStart);

			// Check for if the index is out of bounds
			if (index > items.Length - 1) index = 0;
			else if (index < 0) index = items.Length - 1;

			// Write all of the menu items
			string[] menuItems = new string[items.Length];
			for (int i = 0; i < items.Length; i++)
			{
				string space = "";
				for (int j = 0; j < menuWidth - items[i].Length - 2; j++) space += " ";

				// Check if the current item is selected
				//TODO: Try and get a better way to make the menu items as a string like the rest of the menu
				if (i == index)
				{
					CentreText($"║> {items[i]}{space}║");
				}
				else
				{
					CentreText($"║  {items[i]}{space}║");
				}
			}

			// Show the footer
			//TODO: Try to make a way to only print footer once
			CentreText(menuFooter);

			// Get user input and check for what option they chose
			input = Console.ReadKey(true);

			if (input.Key == ConsoleKey.UpArrow) index--;
			else if (input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.Tab) index++;

		}
		while (input.Key != ConsoleKey.Enter);

		return index;
	}

	// Get input with colord text
	public string GetTextInput(string prompt)
	{
        Console.Write(prompt);
        Console.ForegroundColor = ConsoleColor.Yellow;
        string input = Console.ReadLine().Trim();
        Console.ResetColor();
		
		return input;
	}

	// Get number input with colord text
	public int GetNumberInput(string prompt, string errorMessage = "Please use a number...")
	{
		while (true)
		{
            if (int.TryParse(GetTextInput(prompt), out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
		}
	}

	// Quickly deserialize json
	public Root GetJson()
	{
		string jsonFile = @"./data.json";
		// Give them the json
		return JsonSerializer.Deserialize<Root>(File.ReadAllText(jsonFile), new JsonSerializerOptions {
			PropertyNameCaseInsensitive = true
		});
	}

    // Quickly serialize json
    public void SetJson(Root json)
    {
        string jsonFile = @"./data.json";
		string serializedJson = JsonSerializer.Serialize(json, new JsonSerializerOptions {
			WriteIndented = true //TODO: Figure out how I can make it 4 spaces/tab
		});
		File.WriteAllText(jsonFile, serializedJson);
    }
}
