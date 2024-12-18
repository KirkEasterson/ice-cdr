﻿using System.Text.Json;
using ice_cdr.Query;
using ice_cdr.Types;

class Program
{
    static void Main(string[] args)
    {
        var arguments = ParseArguments(args);
        if (arguments.ContainsKey("--help"))
        {
            PrintHelp();
            return;
        }

        string input;
        if (arguments.TryGetValue("--input", out string? value))
        {
            input = File.ReadAllText(value);
        }
        else
        {
            input = DefaultData();
        }

        var callDetailRecords = JsonSerializer.Deserialize<List<CallDetailRecord>>(input);

        if (callDetailRecords == null)
        {
            return;
        }

        var topCallers = CallersWithMostCallsQuery.Execute(callDetailRecords);
        Console.WriteLine("Top 3 most active callers:");
        foreach (var caller in topCallers.Take(3))
        {
            Console.WriteLine($"{caller.Number}: {caller.CallCount} calls");
        }

        var topCaller = topCallers.First();
        var totalTopCallerDuration = TotalDurationToCallerQuery.Execute(callDetailRecords, topCaller.Number);
        Console.WriteLine($"Total Duration of Calls to {topCaller.Number}: {totalTopCallerDuration} seconds");

        var totalUniqueNumbers = TotalUniqueNumbersQuery.Execute(callDetailRecords);
        Console.WriteLine($"Total Unique Phone Numbers: {totalUniqueNumbers}");
    }

    static Dictionary<string, string> ParseArguments(string[] args)
    {
        var arguments = new Dictionary<string, string>();

        foreach (var arg in args)
        {
            string[] parts = arg.Split('=');
            if (parts.Length == 2)
            {
                arguments[parts[0]] = parts[1];
            }
        }

        return arguments;
    }

    private static string DefaultData()
    {
        return
            "[ { \"Caller\": \"12345678\", \"Receiver\": \"09876543\", \"StartTime\": \"2024-11-27T10:00:00Z\", \"Duration\": 120 }, " +
            "{ \"Caller\": \"12345678\", \"Receiver\": \"11223344\", \"StartTime\": \"2024-11-27T10:05:00Z\", \"Duration\": 60 }, " +
            "{ \"Caller\": \"09876543\", \"Receiver\": \"12345678\", \"StartTime\": \"2024-11-27T10:10:00Z\", \"Duration\": 180 }, " +
            "{ \"Caller\": \"11223344\", \"Receiver\": \"12345678\", \"StartTime\": \"2024-11-27T10:20:00Z\", \"Duration\": 30 }, " +
            "{ \"Caller\": \"12345678\", \"Receiver\": \"44556677\", \"StartTime\": \"2024-11-27T10:30:00Z\", \"Duration\": 90 } ]";
    }

    private static void PrintHelp()
    {
        Console.WriteLine("Help:");
        Console.WriteLine("------");
        Console.WriteLine("Usage: ice-cdr [options]");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  --help             Display this help message");
        Console.WriteLine("  --input=<file>     Specify input file");
    }
}
