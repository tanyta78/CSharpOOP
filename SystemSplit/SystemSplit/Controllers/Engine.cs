using System;
using System.Linq;

namespace SystemSplit.Controllers
{
    public class Engine
    {
        private SystemBuilder systemBuilder;
        private bool isRunning;

        public Engine()
        {
            this.systemBuilder = new SystemBuilder();
            isRunning = true;
        }

        public void Start()
        {
            while (isRunning)
            {
                var commandLine = Console.ReadLine();
                if (commandLine.Contains('('))
                {
                    var command = commandLine.Split('(')[0];
                    var cmdArgs = commandLine.Split('(')[0].Split(new[] { ')' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToString().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    switch (command)
                    {
                        case "RegisterPowerHardware":
                            this.systemBuilder.RegisterPowerHardware(cmdArgs[0], int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                            break;

                        case "RegisterHeavyHardware":
                            this.systemBuilder.RegisterHeavyHardware(cmdArgs[0], int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                            break;

                        case "RegisterExpressSoftware":
                            this.systemBuilder.RegisterExpressSoftware(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), int.Parse(cmdArgs[3]));
                            break;

                        case "RegisterLightSoftware":
                            this.systemBuilder.RegisterLigthSoftware(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), int.Parse(cmdArgs[3]));
                            break;

                        case "ReleaseSoftwareComponent":
                            this.systemBuilder.ReleaseSoftwareComponent(cmdArgs[0], cmdArgs[1]);
                            break;

                        case "Analyze":
                            this.systemBuilder.Analyze();
                            break;
                    }
                }
                else
                {
                    systemBuilder.SystemInfo();
                    isRunning = false;
                }
            }
        }
    }
}