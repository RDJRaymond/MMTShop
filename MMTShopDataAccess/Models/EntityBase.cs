using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShopDataAccess.EntityModels
{
    public abstract class EntityBase<TEntity> : IEquatable<TEntity> where TEntity : EntityBase<TEntity>, new()
    {
        public int Id { get; set; }
        public abstract bool Equals(TEntity other);
        public abstract override int GetHashCode();
    }
}
