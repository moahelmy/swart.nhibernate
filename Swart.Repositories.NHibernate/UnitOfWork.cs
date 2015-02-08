using System.Collections.Generic;
using NHibernate;
using Swart.DomainDrivenDesign.Repositories;
using ITransaction = Swart.DomainDrivenDesign.Repositories.ITransaction;

namespace Swart.Repositories.NHibernate
{
    public class UnitOfWork:ISessionUnitOfWork,ISqlCommand
    {
        private readonly ISession _session;

        public UnitOfWork(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Never;            
        }

        public void Dispose()
        {
            _session.Dispose();
        }

        public ITransaction BeginTransaction()
        {
            return new DbTransaction(_session.BeginTransaction());
        }

        public void SaveChanges()
        {
            _session.Flush();
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public ISession Session { get { return _session; } }
    }
}
