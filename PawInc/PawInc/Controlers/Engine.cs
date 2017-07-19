using System;

namespace PawInc.Controlers
{
    public class Engine
    {
        private CenterBuilder centerBuilder;

        public Engine()
        {
            this.centerBuilder = new CenterBuilder();
        }

        public void Start()
        {
            var commandLine = Console.ReadLine();

            while (commandLine != "Paw Paw Pawah")
            {
                var commands = commandLine.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "RegisterAdoptionCenter":
                        this.centerBuilder.RegisterAdoptionCenter(commands[1]);
                        break;

                    case "RegisterCleansingCenter":
                        this.centerBuilder.RegisterCleansingCenter(commands[1]);
                        break;

                    case "RegisterDog":
                        this.centerBuilder.RegisterDog(commands[1], int.Parse(commands[2]), int.Parse(commands[3]),
                            commands[4]);
                        break;

                    case "RegisterCat":
                        this.centerBuilder.RegisterCat(commands[1], int.Parse(commands[2]), int.Parse(commands[3]),
                            commands[4]);
                        break;

                    case "SendForCleansing":
                        this.centerBuilder.SendForCleansing(commands[1], commands[2]);
                        break;

                    case "Cleanse":
                        this.centerBuilder.Cleanse(commands[1]);
                        break;

                    case "Adopt":
                        this.centerBuilder.Adopt(commands[1]);
                        break;
                }

                commandLine = Console.ReadLine();
            }

            Console.WriteLine(centerBuilder.ToString());
        }
    }
}