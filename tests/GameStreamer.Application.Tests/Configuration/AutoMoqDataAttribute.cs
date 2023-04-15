using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace GameStreamer.Application.Tests.Configuration;

internal class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute()
    : base(new Fixture().Customize(new AutoMoqCustomization()))
    { }
}