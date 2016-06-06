using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Autofac.Integration.Mvc;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Web.Areas.Rewards.Models;
using HomeEconomics.Web.Models;

namespace HomeEconomics.Web.Areas.People.Models.Binders
{

    [ModelBinderType(typeof(PersonCreateViewModel))]
    [ModelBinderType(typeof(CreateViewModel<Person>))]
    public class PersonCreateViewModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var model = bindingContext.Model as PersonCreateViewModel;
            return true;
        }
    }
}
