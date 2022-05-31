using Ninject.Modules;
using Ninject.Web.Common;
using Storage;
using System;

namespace MVCApplication.NI
{
    public class NIConfig : NinjectModule
    {
        public override void Load()
        {
            //JSON
            Bind<IElementsDictionary<Record>>().To<PhonebookStorageJSON>().InTransientScope(); //по умолч
            //Bind<IElementsDictionary<Record>>().To<PhonebookStorageJSON>().InThreadScope();
            //Bind<IElementsDictionary<Record>>().To<PhonebookStorageJSON>().InRequestScope();

            //Database
            //Bind<IElementsDictionary<Record>>().To<PhonebookStorageEF>().InRequestScope();
        }
    }
}