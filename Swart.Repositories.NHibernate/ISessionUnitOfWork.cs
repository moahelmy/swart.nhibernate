using NHibernate;
using Swart.DomainDrivenDesign.Repositories;

namespace Swart.Repositories.NHibernate
{
    public interface ISessionUnitOfWork:IUnitOfWork
    {
        ISession Session { get; }
    }
}
