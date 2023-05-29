using GameStreamer.Domain.Repositories;

namespace GameStreamer.Infrastructure.Storage.Repositories;

public class GameStreamRepository : IGameStreamRepository
{

    #region Dispose

    private bool disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                //_gameStreamerContext.Dispose();
            }
        }
        disposed = true;
    }

    #endregion

}