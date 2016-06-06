using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEconomics.Types
{
    public interface IRepository<EntityType> where EntityType : IEntity
    {
        IEnumerable<EntityType> Documents { get; }
        EntityType Create(EntityType entity);
        EntityType Retrieve(Guid id);
        EntityType Update(EntityType entity);
        void Delete(Guid id);
        void Clear();
    }
}
