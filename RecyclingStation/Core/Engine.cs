namespace RecyclingStation.Core
{
    using System;
    using CoreInterfaces;
    using IO.IOInterfaces;

    public class Engine : IRunnable
    {
        private const string EndCommand = "TimeToRecycle";

        private IInputWriter writer;
        private IInputReader reader;
        private ICommandInterpreter interpreter;

        public Engine(IInputWriter writer, IInputReader reader, ICommandInterpreter interpreter)
        {
            this.writer = writer;
            this.reader = reader;
            this.interpreter = interpreter;
        }

        public void Run()
        {
            string line = this.reader.ReadLine();
            while (line != EndCommand)
            {
                try
                {
                    string[] data = line.Split(new []{' ','|' }, StringSplitOptions.RemoveEmptyEntries);
                    string output = this.interpreter.InterpretCommands(data);
                    this.writer.WriteLine(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = this.reader.ReadLine();
            }
        }
    }
}
