using FluentAssertions;
using Microsoft.Extensions.Time.Testing;

namespace Example.Tests;

public class UnitTest1
{
    private readonly FakeTimeProvider _timeProvider = new (DateTimeOffset.UnixEpoch);
    
    [Fact]
    public void Ctor_ShouldInitializeValue()
    {
        var sut = CreateSut();
        sut.Value.Should().BeEquivalentTo($"Initialized at: {DateTimeOffset.UnixEpoch:u}");
    }
    
    [Fact]
    public void GenerateString_ShouldUpdateValue()
    {
        _timeProvider.Advance(TimeSpan.FromDays(1000));
        
        var sut = CreateSut();
        sut.GenerateString();
        sut.Value.Should().BeEquivalentTo($"Generated at: {_timeProvider.GetUtcNow():u}");
    }
    
    // Private methods

    private Generator CreateSut() 
        => new(_timeProvider);
}