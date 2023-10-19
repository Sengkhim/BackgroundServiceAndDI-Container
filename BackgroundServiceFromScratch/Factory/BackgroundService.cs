namespace BackgroundServiceFromScratch.Factory;

public abstract class BackgroundService : IDisposable
{
    public bool isRunning { set; get; } 
    public Thread workerThread { set; get; } 
    public CancellationTokenSource cancellationTokenSource { set; get; }
    
    public void Start()
    {
        if (isRunning)
        {
            Console.WriteLine("Service is already running.");
            return;
        }
        isRunning = true;
        cancellationTokenSource = new CancellationTokenSource();
        workerThread = new Thread(() => BackgroundWorker(cancellationTokenSource.Token));
        workerThread.Start();
    }
    
    public void Start(Action action)
    {
        if (isRunning)
        {
            Console.WriteLine("Service is already running.");
            return;
        }
        isRunning = true;
        workerThread = new Thread(() => action?.Invoke());
        workerThread.Start();
    }
    
    public void Stop()
    {
        if (!isRunning)
        {
            Console.WriteLine("Service is not running.");
            return;
        }

        cancellationTokenSource.Cancel();
        isRunning = false;
        workerThread.Join(); // Wait for the thread to finish.
    }
    
    // Child classes must implement this method with their specific logic.
    protected abstract void Execute();
    
    private void BackgroundWorker(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Execute(); // Call the child class's implementation.

            // Simulate some work being done.
            Thread.Sleep(5000); // Sleep for 5 seconds.
        }
    }
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}