using CarCompassAPI.Common;
using Domain.Common;
using Domain.Interfaces;
using Domain.Models;
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

        [HttpPost("GetAllMakes")]
        public async Task<ResponseResult<GetAllMakesModel>> GetAllMakes(CommonRequest searchObj)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.CarService.Value.GetAllMakes(searchObj);
            }
        }

        [HttpPost("GetVehicleTypesForMakeId")]
        public async Task<ResponseResult<TypesForMakeModel>> GetVehicleTypesForMakeId(CommonRequest searchObj)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.CarService.Value.GetVehicleTypesForMakeId(searchObj);
            }
        }

        [HttpPost("GetModelsForMakeIdYear")]
        public async Task<ResponseResult<ModelsForMakeIdYearModel>> GetModelsForMakeIdYear(CommonRequest searchObj)
        {
            using (_serviceUnitOfWork)
            {
                return await _serviceUnitOfWork.CarService.Value.GetModelsForMakeIdYear(searchObj);
            }
        }
    }
}
