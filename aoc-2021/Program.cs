class Program 
{
    static void Main(string[] args) 
    {
        DayOne.DoStuff();
        // Console.WriteLine("Give me a number: ");
        // int myNumber = int.Parse(Console.ReadLine());

        // Console.WriteLine("Give me another number to add to it: ");
        // int addNumber = int.Parse(Console.ReadLine());
        
        // Console.WriteLine(GiveMyNumberBackPlus(myNumber, addNumber));
    }
    static int GiveMyNumberBackPlus(int someInt, int anotherInt) 
    {
        return someInt + anotherInt;
    }
    static void TextThings()
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("I am a big fat jelly bean");
        Console.WriteLine("your mama said I was big enough - pluto");

        // whatever I want because it's a comment
        Console.Write("Tell me your favorite color: ");

        string? favColor;
        favColor = Console.ReadLine();

        Console.WriteLine("Your favorite color is " + favColor + "... what a boss!");

        Console.Write("Now... Tell me your favorite number: ");

        int favNumber;
        try
        {
            favNumber = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("You suck bro... that's not a number!");
            return;
        };

        Console.WriteLine("Your favorite number is " + favNumber.ToString() + " ... GigaChad!");

        Console.WriteLine("I can count to " + favNumber.ToString() + "... watch me!");

        int i = 1;

        while (i <= favNumber)
        {
            Console.WriteLine(i);
            i++;
        }

        Console.WriteLine("See?  I told you so.");

        // this is a comment
    }
}