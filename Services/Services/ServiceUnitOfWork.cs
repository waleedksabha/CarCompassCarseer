using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        public ITPServiceUnitOfWork _tPServiceUnitOfWork { get; set; }
        public Lazy<ICarService> CarService { get; set; }

        public ServiceUnitOfWork()
        {
            CarService = new Lazy<ICarService>(() => new CarService(_tPServiceUnitOfWork));

        }

        public void Dispose()
        { 
        }
    }
}
