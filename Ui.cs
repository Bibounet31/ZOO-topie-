using System;
using System.Threading;

static class UI
{
    // colors
    public const string Reset      = "\x1b[0m";
    public const string Bold       = "\x1b[1m";
    public const string Dim        = "\x1b[2m";
    public const string Italic     = "\x1b[3m";

    public const string DarkGreen  = "\x1b[38;5;22m";
    public const string Green      = "\x1b[38;5;34m";
    public const string LightGreen = "\x1b[38;5;82m";
    public const string Lime       = "\x1b[38;5;154m";
    public const string Brown      = "\x1b[38;5;130m";
    public const string Tan        = "\x1b[38;5;179m";

    public const string Yellow     = "\x1b[38;5;220m";
    public const string Orange     = "\x1b[38;5;208m";
    public const string White      = "\x1b[38;5;255m";
    public const string Gray       = "\x1b[38;5;244m";
    public const string DarkGray   = "\x1b[38;5;238m";
    public const string Red        = "\x1b[38;5;196m";

    public const string BgDarkGreen = "\x1b[48;5;22m";
    public const string BgBrown     = "\x1b[48;5;94m";

    // ascii logo
    static readonly string[] Logo =
    {
        @" ____  ____  ____ _____ ____  ____  _  _____",
        @"/_   \/  _ \/  _ Y__ __Y  _ \/  __\/ \/  __/",
        @" /   /| / \|| / \| / \ | / \||  \/|| ||  \" ,
        @"/   /_| \_/|| \_/| | | | \_/||  __/| ||  /_",
        @"\____/\____/\____/ \_/ \____/\_/   \_/\____\",
    };

    // prints text letter by letter, change delayMs to go faster or slower
    public static void TypeWrite(string text, int delayMs = 18, string color = "")
    {
        if (color != "") Console.Write(color);
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMs);
        }
        if (color != "") Console.Write(Reset);
    }

    // same but adds a new line at the end
    public static void TypeWriteLine(string text, int delayMs = 18, string color = "")
        => TypeWrite(text + "\n", delayMs, color);

    // normal write but with color
    public static void Write(string text, string color = "")
        => Console.Write(color + text + (color != "" ? Reset : ""));

    // normal writeline but with color
    public static void WriteLine(string text, string color = "")
        => Console.WriteLine(color + text + (color != "" ? Reset : ""));

    // shows the logo with a gradient 
    public static void PrintLogo()
    {
        string[] colors = { DarkGreen, Green, LightGreen, Lime, LightGreen };
        for (int i = 0; i < Logo.Length; i++)
        {
            Console.WriteLine(colors[i] + Bold + Logo[i] + Reset);
            Thread.Sleep(55);
        }
    }

    // horizontal line
    public static void Rule(char ch = '─', int width = 48, string color = "")
    {
        color = color != "" ? color : DarkGray;
        WriteLine(new string(ch, width), color);
    }

    // thicker line used under the logo
    public static void HeavyRule()
    {
        WriteLine(new string('▓', 3) + new string('░', 42) + new string('▓', 3), DarkGreen);
    }

    // title for each menu screen
    public static void Banner(string title)
    {
        Console.WriteLine();
        Rule('─', 48, DarkGray);
        Write("  ", "");
        Write("▌ ", Green + Bold);
        TypeWriteLine(title.ToUpper(), 11, White + Bold);
        Rule('─', 48, DarkGray);
        Console.WriteLine();
    }

    // one menu option, number + label
    public static void Option(string number, string label, string emoji = "")
    {
        string suffix = emoji != "" ? $"  {Dim}{emoji}{Reset}" : "";
        Write($"    {DarkGray}({Reset}{Gray}{number}{Reset}{DarkGray}){Reset}  ", "");
        TypeWriteLine(label + suffix, 9, White);
    }

    // asks the player to type something
    public static string? Prompt(string label = "›")
    {
        Console.WriteLine();
        Write($"  {Green}{label}{Reset}  ", "");
        return Console.ReadLine();
    }

    // little spinning animation while loading
    public static void Loading(string message = "Chargement", int steps = 10)
    {
        char[] spinner = { '⠋', '⠙', '⠸', '⠴', '⠦', '⠇' };
        Console.WriteLine();
        Write($"  {Gray}{message}  ", "");
        for (int i = 0; i < steps; i++)
        {
            Write($"{Green}{spinner[i % spinner.Length]}{Reset}");
            Thread.Sleep(80);
            Console.Write("\b");
        }
        WriteLine($"{LightGreen}done{Reset}");
        Thread.Sleep(160);
    }

    // shows an error message in red
    public static void Error(string message)
    {
        Console.WriteLine();
        WriteLine($"  {Red}✕{Reset}  {Orange}{message}{Reset}");
    }

    // waits for the player to press enter
    public static void Pause()
    {
        Console.WriteLine();
        WriteLine($"  {DarkGray}— entrée pour continuer —{Reset}");
        Console.ReadLine();
    }

    // shows a success message in green
    public static void Success(string message)
    {
        Console.WriteLine();
        Write($"  {LightGreen}✓{Reset}  ", "");
        TypeWriteLine(message, 13, Tan);
    }

    // small text shown under the logo
    public static void Subtitle(string text)
    {
        Write("  ", "");
        TypeWriteLine(text, 10, Dim + Tan + Italic);
        Console.WriteLine();
    }
}