using Timer = System.Timers.Timer;

namespace OneSecondAlarmTimer;

public class CustomTimer
{

    private readonly Timer _timer;
    private int _elapsedSeconds;
    public event Action<int> Tick;

    public CustomTimer(int interval = 1000)
    {
        _timer = new Timer(interval);
    }

    protected void OnTicking(int seconds)
    {
        Tick?.Invoke(seconds);
    }
    
    public void Start()
    {
        _timer.Elapsed += (_, args) =>
        {
            _elapsedSeconds++;
            OnTicking(_elapsedSeconds);
        };
        
        _timer.Start();
    }
    
    public void Stop()
    {
        _timer.Stop();
    }
    
    ~CustomTimer()
    {
        _timer.Stop();
        _timer.Dispose();
    }
}