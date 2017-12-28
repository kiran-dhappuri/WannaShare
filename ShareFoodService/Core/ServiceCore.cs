using MessageHelper.SMS;
using Ninject;
using ShareFoodService.Context;
using ShareFoodService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareFoodService.Core
{
    public class ServiceCore
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.Bind<ISharedFoodContext>().To<ShareFoodContext>();
            kernel.Bind<IShareFoodService>().To<FoodService>();
            kernel.Bind<ISMSService>().To<SMSService>();
        }
    }
}
