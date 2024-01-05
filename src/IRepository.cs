using System;

namespace TeqBench.System.Data.NoSql.Repository
{
    /// <summary>
    /// Interface for base repository implementation.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void InitializeAsync();
    }
}
