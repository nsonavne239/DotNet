
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddleLayer;
using Unity;
using InterfaceCustomer;

namespace FactoryCustomer
{
    public static class Factory // Design Pattern : Simple Factiry
    {
        private static IUnityContainer custs = null;
        //private static Dictionary<string, CustomerBase> custDict = new Dictionary<string, CustomerBase>();
        public static ICustomer Create(string typeCust)
        {
            //Design pattern : Lazy loading
            //if (custDict.Count== 0)
            //{
            //    custDict.Add("Customer",new Customer());
            //    custDict.Add("Lead", new Lead());
            //}

            if (custs == null)
            {
                custs = new UnityContainer();
                custs.RegisterType<CustomerBase, Customer>("Customer");
                custs.RegisterType<CustomerBase, Lead>("Lead");

            }

            //Design pattern : RIP (Replace if with polymorphism)
            //return custDict[typeCust];
            return custs.Resolve <CustomerBase>(typeCust);
               
        }
    }
}
