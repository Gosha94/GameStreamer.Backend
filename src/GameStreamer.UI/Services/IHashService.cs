namespace GameStreamer.Services
{
    public interface IHashService
    {
        public Guid CalculateHashCodeFrom(string value);
    }
}
