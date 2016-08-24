namespace RecyclingStation
{
    using Controllers;
    using Core;
    using Core.Factories;
    using IO;
    using WasteDisposal;

    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            var garbageFactory = new GarbageFactory();
            var strategyHolder = new StrategyHolder();
            var recyclingStation = new RecyclingStation();
            var recyclingStationController = new RecyclingStationController(garbageFactory, strategyHolder, recyclingStation);
            var commandInterpreter = new CommandInterpreter(recyclingStationController);
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var engine = new Engine(writer, reader, commandInterpreter);

            engine.Run();
            
        }
    }
}
