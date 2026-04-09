using Calculator;
using Microsoft.Extensions.Configuration;


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();





var bootstrapper = new Bootstrapper(configuration);

// CR: Conventions: use var (everywhere)
var calculatorApp = bootstrapper.Initialize();

calculatorApp.Run();

// CR: Naming: Project names should be pascal case. (First word starts with capital letter, and every other word as well)
// CR: Naming: Project names are not clear. and do not follow a clear convention
