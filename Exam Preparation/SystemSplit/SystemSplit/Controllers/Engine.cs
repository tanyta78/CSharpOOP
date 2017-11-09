using System;
using System.Linq;
using System.Text.RegularExpressions;

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
                    Regex rgx = new Regex(@"(\w+)\((.*)\)");
                    var args = rgx.Match(commandLine).Groups;
                    var command = args[1].Value;
                    var cmdArgs = args[2].Value.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

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
                            Console.WriteLine(this.systemBuilder.Analyze());
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(systemBuilder.SystemInfo());
                    isRunning = false;
                }
            }
        }
    }
}