using CarCompassAPI.Common;
using Domain.Common;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CarCompassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : BaseController
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        private readonly ITPServiceUnitOfWork _tPServiceUnitOfWork;


        public VehicleController(IServiceUnitOfWork serviceUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork) : base(serviceUnitOfWork, tPServiceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;

        }

        [HttpGet("GetAllMakes")]
        public async Task<IResponseResult<dynamic>> GetAllMakes(string format)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.CarService.Value.GetAllMakes(format);
            }
        }
    }
}
