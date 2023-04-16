namespace GameStreamer.Domain.InternalProviders;

public interface IHashService
{
    public Guid CalculateHashCodeFrom(string value);
}
