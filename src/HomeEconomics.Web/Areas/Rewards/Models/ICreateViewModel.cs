using HomeEconomics.Types;

namespace HomeEconomics.Web.Areas.Rewards.Models
{
    public interface ICreateViewModel<EntityType>
        where EntityType : IEntity
    {
        EntityType Entity { get; set; }
    }
}