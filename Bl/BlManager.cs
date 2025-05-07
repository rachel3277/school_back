using Bl.Api;
using Dal;
using Dal.Api;
using Bl.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bl
{
    public class BlManager : IBl

    {
        public IBlEvent events { get; }
        public IBlParent parents { get; }
        public IBlStudent students { get; }
        public IBlRegistration registration { get; }
        public IBlClass Class { get; }

        public BlManager()
        {
            //IDal dal = new DalManager();
            //events = new BlEventService(dal);
            //students = new BlStudentService(dal);
            //parents = new BlParentService(dal);
            //registration = new BlRegistrationService(dal);

            ServiceCollection services = new ServiceCollection();
            
            services.AddSingleton<IDal,DalManager>();
            services.AddSingleton<IBlClass, BlClassService>();
            services.AddSingleton<IBlParent,BlParentService>();
            services.AddSingleton<IBlStudent,BlStudentService>();
            services.AddSingleton<IBlEvent,BlEventService>();
            services.AddSingleton<IBlRegistration,BlRegistrationService>();


            ServiceProvider serviceProvider = services.BuildServiceProvider();

            Class = serviceProvider.GetRequiredService<IBlClass>();
            events = serviceProvider.GetRequiredService<IBlEvent>();
            parents = serviceProvider.GetRequiredService<IBlParent>();
            registration = serviceProvider.GetRequiredService<IBlRegistration>();
            students = serviceProvider.GetRequiredService<IBlStudent>();
         


        }
    }
}