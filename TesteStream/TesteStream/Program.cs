using System;

namespace TesteStream
{
    class Program
    {
        static void Main(string[] args)
        {
            StringStream stream = new StringStream("aAbBABacfe");
            char result = ReadStream.firstChar(stream);
            Console.WriteLine("Resultado: " + result);
            Console.ReadKey();
        }
    }
}