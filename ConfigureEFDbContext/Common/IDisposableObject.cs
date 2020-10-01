using System;

namespace ConfigureEFDbContext.Common
{
    public interface IDisposableObject : IDisposable
    {
        event EventHandler Disposed;

        bool IsDisposed { get; }
    }
}
