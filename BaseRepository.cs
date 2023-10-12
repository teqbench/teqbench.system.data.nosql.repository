using System.Threading.Tasks;

namespace TeqBench.System.Data.NoSql.Repository
{
    /// <summary>
    /// Base implementation for a repository. Override the appropriate methods to create DB if does not exist,
    /// create collection if does not exist (might not need to implement as in case of MongoDB...collection will be created upon
    /// first reference if does not exist), as well as methods to dispose of managed/unmanaged objects.
    /// </summary>
    public abstract class BaseRepository : IRepository
    {
        #region Member Variables
        // Flag: Has Dispose already been called?
        protected bool _disposed = false;
        #endregion

        #region Constructors
        public BaseRepository()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public virtual async void InitializeAsync()
        {
            // Cannot have async operations in contructor, so create an async init routine to ecapsulate 
            // async operations to be done right have instance is created. 
            await this.CreateDatabaseIfDoesNotExistAsync();
            await this.CreateCollectionIfDoesNotExistAsync();
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Creates the database if does not exist asynchronously.
        /// </summary>
        protected virtual async Task CreateDatabaseIfDoesNotExistAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Creates the document collection if does not exist asynchronously.
        /// </summary>
        protected virtual async Task CreateCollectionIfDoesNotExistAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Disposes of managed objects; called from Dispose method. 
        /// </summary>
        protected virtual void DisposeOfManagedObjects()
        {
        }

        /// <summary>
        /// Disposes/frees un-managed objects (i.e.  like pointers, etc.); called from Dispose method. 
        /// </summary>
        protected virtual void DisposeOfUnManagedObjects()
        {
        }
        #endregion

        #region Public Methods - IDisposable
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <remarks>
        /// Need a destructor(finalizer) only if you have unmanaged resources in your class. And if you add a destructor, you should suppress 
        /// Finalization in the Dispose (see commented out call in this method), otherwise it will cause your objects resides in memory for two garbage cycles
        /// </remarks>
        public void Dispose()
        {
            Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, should call GC.SupressFinalize to 
            // take this object off the finalization queue 
            // and prevent finalization code for this object 
            // from executing a second time.
            //GC.SuppressFinalize(this);
        }
        #endregion

        #region Protected Methods - IDisposable
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            // If already dispose of this instance, just return.
            if (this._disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free any other managed objects here.
                //
                this.DisposeOfManagedObjects();
            }

            // Free any unmanaged objects here, like pointers, etc.
            //
            this.DisposeOfUnManagedObjects();

            // Set flag that this instance has been disposed of.
            this._disposed = true;
        }
        #endregion
    }
}
