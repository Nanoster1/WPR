using Microsoft.EntityFrameworkCore;
using WPR.Migrations;

if (args.FirstOrDefault() != "migrate") return;

Console.WriteLine(@"Build...");

var factory = new Factory();
var context = factory.CreateDbContext(args);

Console.WriteLine(@"Build succeed!");

context.Database.Migrate();

Console.WriteLine($@"{DateTime.UtcNow} - Migrations successfully applied");