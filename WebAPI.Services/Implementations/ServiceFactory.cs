using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services.Implementations
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>() where T : class
        {
            var service = _serviceProvider.GetService(typeof(T));
            return (T)service;
        }
    }
}
