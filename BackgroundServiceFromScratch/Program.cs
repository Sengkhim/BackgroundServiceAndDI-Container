using BackgroundServiceFromScratch.BackgroundServices;
using BackgroundServiceFromScratch.Controller;
using BackgroundServiceFromScratch.Implement;
using BackgroundServiceFromScratch.Service;
using DependencyInjection.Implement;

var backgroundService = new QueueBackgroundService();
var cancellationTokenSource = new CancellationTokenSource().Token;
var services = new ServiceCollection();
//Register service container
services.AddScoped<IUserService, UserService>();
//Build all service registered
var serviceProvider = services.BuildServiceProvider();
//Get service
var userService = serviceProvider.GetService(typeof(IUserService));

//Start background service
backgroundService.Start(() =>
{
     while (!cancellationTokenSource.IsCancellationRequested)
     {
         var controller = new UserController(userService as IUserService);
         var users = controller.GetAllUser();
         foreach (var user in users)
             Console.WriteLine($"Id > {user.Id}, Name > {user.Name}, Address > {user.Address}");
         Console.WriteLine("------------------------------------------------");
         Thread.Sleep(5000); 
     }
});

Console.WriteLine("Press Enter to stop the service.");
Console.ReadLine();
backgroundService.Stop();