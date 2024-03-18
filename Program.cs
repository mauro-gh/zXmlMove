using zXmlMove;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args == null || args.Length != 2 )
        {
            Console.WriteLine("Parametri:");
            Console.WriteLine("FileTXT CartellaXMLdestinazione");
            Console.WriteLine("Es: dotnet zXmlMove.dll input2023.txt 2023xml");
            return;
        }

        int totArgs = args.Length;
        Console.WriteLine($"Totale parametri: {totArgs}");

        Engine eng = new Engine();
        eng.FileElenco = args[0];
        eng.XmlMoveFolder = args[1];

        Console.WriteLine($"FileTXT: {eng.FileElenco}");
        Console.WriteLine($"CartellaXMLdestinazione: {eng.XmlMoveFolder}");

        eng.XmlMove();
    }
}