namespace Example;

public class Generator
{
    private readonly TimeProvider _timeProvider;
    
    public string Value { get; private set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Generator"/> class
    /// </summary>
    public Generator(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
        Value = "Initialized at: " + _timeProvider.GetLocalNow().ToString("u");
    }

    public void GenerateString()
        => Value = "Generated at: " + _timeProvider.GetLocalNow().ToString("u");
}
