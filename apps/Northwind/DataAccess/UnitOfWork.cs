using Entities;

namespace DataAccess
{
    public interface IUnitOfWork
    {
        void Save();
        OrderRepository OrderRepository { get; }
        Repository<Category> CategoryRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork, IEquatable<UnitOfWork>, IDisposable
    {
        private NorthwindContext context;
        private OrderRepository orderRepository;
        private Repository<Category> categoryRepository;

        public UnitOfWork(NorthwindContext context) =>
            this.context = context ?? throw new ArgumentNullException(nameof(context));

        public OrderRepository OrderRepository => orderRepository ?? new(context);
        public Repository<Category> CategoryRepository => categoryRepository ?? new(context);

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Operation unsuccesfull: {e.Message}", e);
            }
        }

        #region Disposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        public bool Equals(UnitOfWork other)
            => ReferenceEquals(this, other) && ReferenceEquals(context, other.context);

        public override bool Equals(object obj) => Equals(obj as UnitOfWork);

        public override int GetHashCode() => context.GetType().GetHashCode();
    }
}