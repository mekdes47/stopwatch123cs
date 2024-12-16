using System;
using System.Timers; 

public class Stopwatch
{
    private System.Timers.Timer timer; 
    private int elapsedSeconds;

    // Events
    public event Action<string> OnStarted;
    public event Action<string> OnStopped;
    public event Action<string> OnReset;

    public Stopwatch()
    {
        timer = new System.Timers.Timer(1000); // Tick every 1 second
        timer.Elapsed += OnTick; // Attach Tick handler
    }

    public void Start()
    {
        if (!timer.Enabled)
        {
            timer.Start();
            OnStarted?.Invoke("Stopwatch started!");
        }
        else
        {
            Console.WriteLine("Stopwatch is already running.");
        }
    }

    public void Stop()
    {
        if (timer.Enabled)
        {
            timer.Stop();
            OnStopped?.Invoke($"Stopwatch stopped! Total elapsed time: {elapsedSeconds} seconds.");
        }
        else
        {
            Console.WriteLine("Stopwatch is not running.");
        }
    }

    public void Reset()
    {
        timer.Stop();
        elapsedSeconds = 0;
        OnReset?.Invoke("Stopwatch reset!");
    }

    private void OnTick(object sender, ElapsedEventArgs e)
    {
        elapsedSeconds++;
        Console.WriteLine($"Time Elapsed: {elapsedSeconds} seconds");
    }
}
