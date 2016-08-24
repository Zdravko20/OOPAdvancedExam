namespace RecyclingStation.IO
{
    using System;
    using IOInterfaces;

    public class ConsoleWriter : IInputWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
