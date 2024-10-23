using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;

namespace CarCompassAPI.Common
{
    public class BaseController : Controller
    {
        private ITPServiceUnitOfWork _tPServiceUnitOfWork;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public BaseController(IServiceUnitOfWork serviceUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            _serviceUnitOfWork._tPServiceUnitOfWork = tPServiceUnitOfWork;
        }
    }
}
