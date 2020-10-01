using System;

namespace ConfigureEFDbContext.Common
{
    /// <summary>
    ///  Implicit implementation for Dispose Pattern
    /// </summary>
    public abstract class DisposableObject : DisposableObjectBase
    {
        public event EventHandler Disposed
        {
            add => DisposedEventHandler += value;
            remove => DisposedEventHandler -= value;
        }
    }
}
