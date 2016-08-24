namespace RecyclingStation.IO
{
    using System;
    using IOInterfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
