// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();


string secretValue = config["FirstSecretVariable"] ?? "";
string secretValue1 = config["FirstSecretVariable1"] ?? "";
string nonExistingValue = config["nonExistingVariable"] ?? throw new ArgumentNullException("Variable not found.");

Console.WriteLine($"FirstSecretVariable: {secretValue}");
Console.WriteLine($"FirstSecretVariable1: {secretValue1}");
Console.WriteLine($"Non-Existing Variable: {nonExistingValue}");