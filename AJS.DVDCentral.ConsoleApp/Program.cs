﻿using AJS.DVDCentral.ConsoleApp;

internal static class Program
{

    private static string DrawMenu()
    {
        Console.WriteLine("Which operation do you wish to perform?");
        Console.WriteLine("Connect to a channel (c)");
        Console.WriteLine("Send a message to the channel (s)");
        Console.WriteLine("Exit (x)");

        string operation = Console.ReadLine();
        return operation;
    }

    private static void Main(string[] args)
    {
        string user = "Austin";
        //string hubAddress = "https://fvtcdp.azurewebsites.net/GameHub";
        string hubAddress = "https://localhost:7029/BingoHub";


        string operation = DrawMenu();

        var signalRConnection = new SignalRConnection(hubAddress);

        while (operation != "x")
        {
            switch(operation)
            {
                case "c":
                    signalRConnection.ConnectToChannel(user);
                    break;
                case "s":
                    break;
                case "x":
                    break;
            }
            operation = DrawMenu();
        }
    }
}