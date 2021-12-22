using static System.Console;

namespace Sokoban.MenuViews;

public class Menu
{
    private int selectedIndex;
    private readonly string[] options;
    private readonly string prompt;

    public Menu(string prompt, string[] options)
    {
        this.prompt = prompt;
        this.options = options;
        selectedIndex = 0;
    }

    public int Run()
    {
        ConsoleKey keyPressed;
        do
        {
            Clear();
            DisplayOptions();
            var keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            switch (keyPressed)
            {
                case ConsoleKey.UpArrow:
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                        selectedIndex = options.Length - 1;
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                        selectedIndex = 0;
                    break;
                }
            }
        } while (keyPressed != ConsoleKey.Enter);

        return selectedIndex;
    }


    private void DisplayOptions()
    {
        WriteLine(prompt);
        for (var i = 0; i < options.Length; i++)
        {
            var currentOption = options[i];
            var prefix = "";

            if (i == selectedIndex)
            {
                prefix = ">>";
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.White;
            }
            else
            {
                prefix = "  ";
                ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
            }

            WriteLine($"{prefix} [ {currentOption} ]");
        }

        ResetColor();
    }
}