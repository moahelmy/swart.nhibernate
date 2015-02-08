using System;
using System.Linq;
using NHibernate.Linq;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.Repositories;

namespace Swart.Repositories.NHibernate
{
    public class Repository<TEntity, TKey>:RepositoryBase<TEntity, TKey> 
        where TKey : IComparable where TEntity : class, IEntity<TKey>
    {        
        private readonly ISessionUnitOfWork _unitOfWork;

        public Repository(ISessionUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Basic
        public override IQueryable<TEntity> List()
        {
            return _unitOfWork.Session.Query<TEntity>();
        }

        public override TEntity Get(TKey id)
        {
            return _unitOfWork.Session.Get<TEntity>(id);
        }
        #endregion

        #region List
        public override void Add(TEntity entity)
        {
            _unitOfWork.Session.Save(entity);
        }

        public override void Delete(TEntity entity)
        {
            _unitOfWork.Session.Delete(entity);
        }

        public override void Update(TEntity entity)
        {
            _unitOfWork.Session.Update(entity);            
        }
        #endregion

        #region Disposal
        public override void Dispose()
        {
            _unitOfWork.Dispose();
        }
        #endregion
    }
}
