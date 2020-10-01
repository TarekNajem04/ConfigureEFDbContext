using System;

namespace ConfigureEFDbContext.Common
{
    public abstract class DisposableObjectBase : IDisposableObject
    {
        protected event EventHandler DisposedEventHandler;

        protected DisposableObjectBase() => IsDisposed = false;

        ~DisposableObjectBase() => Dispose(false);

        //[NonSerialized]
        public bool IsDisposed { get; private set; }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            OnDisposed(EventArgs.Empty);
            IsDisposed = true;
            GC.SuppressFinalize(this);
        }

        protected void GuardNotDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        event EventHandler IDisposableObject.Disposed
        {
            add => DisposedEventHandler += value;
            remove => DisposedEventHandler -= value;
        }

        protected virtual void OnDisposed(EventArgs e) => DisposedEventHandler?.Invoke(this, e);
    }
}
