using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IServiceUnitOfWork : IDisposable
    {
        public ITPServiceUnitOfWork _tPServiceUnitOfWork { get; set; }
        public Lazy<ICarService> CarService { get; set; }

    }
}
