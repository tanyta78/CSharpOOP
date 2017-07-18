using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;
    private bool isRunning;

    public Engine()
    {
        this.draftManager = new DraftManager();
        isRunning = true;
    }

    public void Start()
    {
        while (isRunning)
        {
            var cmdArgs = Console.ReadLine().Split(' ').ToList();
            var command = cmdArgs[0];
            cmdArgs = cmdArgs.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(this.draftManager.RegisterHarvester(cmdArgs));
                    break;

                case "RegisterProvider":
                    Console.WriteLine(this.draftManager.RegisterProvider(cmdArgs));
                    break;

                case "Day":
                    Console.WriteLine(this.draftManager.Day());
                    break;

                case "Mode":
                    Console.WriteLine(this.draftManager.Mode(cmdArgs));
                    break;

                case "Check":
                    Console.WriteLine(this.draftManager.Check(cmdArgs));
                    break;

                case "Shutdown":
                    isRunning = false;
                    Console.WriteLine(this.draftManager.ShutDown());
                    break;
            }
        }
    }
}