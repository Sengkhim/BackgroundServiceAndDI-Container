using BackgroundServiceFromScratch.Factory;

namespace BackgroundServiceFromScratch.BackgroundServices;

public class QueueBackgroundService : BackgroundService
{
    protected override void Execute()
    {
        var time = DateTime.Now.Hour;
        var counter =  time + time;
        Console.WriteLine("Child service logic is running... " + counter);
    }
}