using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HomeEconomics.Types;

namespace HomeEconomics.Web
{
    public static class Extensions
    {
        public static SelectListItem ToSelectListItem(this IEntity entity)
        {
            return new SelectListItem
            {
                Text = entity.Name,
                Value = entity.Id.ToString(),
            };
        }
    }
}
