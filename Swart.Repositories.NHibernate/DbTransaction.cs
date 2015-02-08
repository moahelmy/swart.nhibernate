using NHibernate;

namespace Swart.Repositories.NHibernate
{
    public class DbTransaction:Swart.DomainDrivenDesign.Repositories.ITransaction
    {
        private readonly ITransaction _transaction;

        public DbTransaction(ITransaction transaction)
        {
            _transaction = transaction;
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
