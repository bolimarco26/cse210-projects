Reference reference = new Reference("Proverbs", 3, 5, 6);

Scripture scripture = new Scripture(
    reference,
    "Trust in the Lord with all thine heart and lean not unto thine own understanding in all thy ways acknowledge him and he shall direct thy paths"
);

Console.Clear();
Console.WriteLine(scripture.GetDisplayText());

while (!scripture.IsCompletelyHidden())
{
    Console.WriteLine();
    Console.Write("Press Enter to continue or type 'quit' to finish: ");

    string input = Console.ReadLine();

    if (input.ToLower() == "quit")
    {
        break;
    }

    scripture.HideRandomWords(3);

    Console.Clear();
    Console.WriteLine(scripture.GetDisplayText());
}