using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Autofac.Integration.Mvc;
using HomeEconomics.Data.Entities.Rewards;

namespace HomeEconomics.Web.Areas.Rewards.Models.Binders
{
    [ModelBinderType(typeof(AssignmentCreateViewModel))]
    public class AssignmentCreateViewModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var model = bindingContext.Model as AssignmentCreateViewModel;
            return true;
        }
    }
}
