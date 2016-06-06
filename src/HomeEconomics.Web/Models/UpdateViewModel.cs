using HomeEconomics.Types;

namespace HomeEconomics.Web.Models
{
    public class UpdateViewModel<EntityType>
        where EntityType : IEntity
    {
        public EntityType Entity { get; set; }
    }
}