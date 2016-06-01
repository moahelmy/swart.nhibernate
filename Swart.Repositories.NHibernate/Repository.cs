using System;
using System.Linq;
using NHibernate.Linq;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.Repositories;

namespace Swart.Repositories.NHibernate
{
    public class Repository<TEntity, TKey>:RepositoryBase<TEntity, TKey> 
        where TKey : IComparable, IEquatable<TKey> where TEntity : class, IEntity<TKey>
    {        
        private readonly ISessionUnitOfWork _unitOfWork;

        public Repository(ISessionUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override IQueryable<TEntity> _List()
        {
            return _unitOfWork.Session.Query<TEntity>();
        }

        #region Basic
        public override TEntity Get(TKey id)
        {
            return _unitOfWork.Session.Get<TEntity>(id);
        }
        #endregion

        #region List

        protected override void AddEntity(TEntity entity)
        {
            _unitOfWork.Session.Save(entity);
        }

        protected override void DeleteEntity(TEntity entity)
        {
            _unitOfWork.Session.Delete(entity);
        }

        protected override void UpdateEntity(TEntity entity)
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
