using Calculator;
using Microsoft.Extensions.Configuration;


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


var bootstrapper = new Bootstrapper(configuration);

var calculatorApp = bootstrapper.Initialize();

calculatorApp.Run();
