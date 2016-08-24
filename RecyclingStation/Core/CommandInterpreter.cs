namespace RecyclingStation.Core
{
    using System;
    using Constants;
    using Controllers;
    using CoreInterfaces;

    public class CommandInterpreter : ICommandInterpreter
    {
        private RecyclingStationController controller;

        public CommandInterpreter(RecyclingStationController controller)
        {
            this.controller = controller;
        }

        public virtual string InterpretCommands(string[] data)
        {
            string output = string.Empty;

            switch (data[0])
            {
                case "ProcessGarbage":
                    output = this.controller.ProcessGarbage(data);
                    break;
                case "Status":
                    output = this.controller.RecylingStation.PrintRecyclingStationData();
                    break;
                case "ChangeManagementRequirement":
                    output = this.controller.ChangeManagementRequirement(data);
                    break;
                default:
                    throw new InvalidOperationException(ConstantMessages.NoSuchCommand);
            }

            return output;
        }
    }
}
