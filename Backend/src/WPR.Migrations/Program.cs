using Microsoft.EntityFrameworkCore;
using WPR.Migrations;

if (args.FirstOrDefault() != "migrate") return;

Console.WriteLine("Build...");

var factory = new Factory();
var context = factory.CreateDbContext(args);

Console.WriteLine(@"Build succeed!");

context.Database.Migrate();

var migrations = context.Database.GetAppliedMigrations();

Console.WriteLine($"{DateTime.UtcNow} - Migrations successfully applied\nMigrations:\n{string.Join('\n', migrations)}");