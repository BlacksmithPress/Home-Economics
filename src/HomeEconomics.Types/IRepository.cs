using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEconomics.Types
{
    public interface IRepository<EntityType> where EntityType : IEntity
    {
        EntityType Create(EntityType entity);
        EntityType Retrieve(Guid id);
        IEnumerable<EntityType> RetrieveAll();
        EntityType Update(EntityType entity);
        void Delete(Guid id);
        void Clear();
    }
}
