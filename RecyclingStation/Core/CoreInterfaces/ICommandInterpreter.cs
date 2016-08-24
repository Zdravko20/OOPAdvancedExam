namespace RecyclingStation.Core.CoreInterfaces
{
    public interface ICommandInterpreter
    {
        string InterpretCommands(string[] data);
    }
}
