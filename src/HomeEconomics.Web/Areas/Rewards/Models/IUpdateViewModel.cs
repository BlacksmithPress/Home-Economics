using HomeEconomics.Types;

namespace HomeEconomics.Web.Areas.Rewards.Models
{
    public interface IUpdateViewModel<EntityType>
        where EntityType : IEntity
    {
        EntityType Entity { get; set; }
    }
}