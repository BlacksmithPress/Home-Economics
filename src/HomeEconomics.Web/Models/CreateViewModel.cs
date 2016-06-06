using HomeEconomics.Types;

namespace HomeEconomics.Web.Models
{
    public class CreateViewModel<EntityType>
        where EntityType : IEntity
    {
        public EntityType Entity { get; set; }
    }
}