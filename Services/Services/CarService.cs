using Domain.Common;
using Domain.Interfaces;
using Domain.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CarService : ICarService
    {
        private ITPServiceUnitOfWork _tPServiceUnitOfWork;
        public CarService(ITPServiceUnitOfWork tPServiceUnitOfWork) 
        {
            _tPServiceUnitOfWork = tPServiceUnitOfWork;
        }

        #region GetAllMakes
        public async Task<ResponseResult<GetAllMakesModel>> GetAllMakes(CommonRequest searchObj)
        {
            try
            {
                var result = await _tPServiceUnitOfWork.TPIntegrationService.Value.GetAllMakes(searchObj);
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseResult<GetAllMakesModel>() { Count = 0, Message = "Error While Getting Data (GetAllMakes) " + Environment.NewLine + " Exception Message : " + ex.Message, Results = null, SearchCriteria = null };
            }
        }
        #endregion

        #region GetVehicleTypesForMakeId
        public async Task<ResponseResult<TypesForMakeModel>> GetVehicleTypesForMakeId(CommonRequest searchObj)
        {
            try
            {
                var result = await _tPServiceUnitOfWork.TPIntegrationService.Value.GetVehicleTypesForMakeId(searchObj);
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseResult<TypesForMakeModel>() { Count = 0, Message = "Error While Getting Data (GetVehicleTypesForMakeId) " + Environment.NewLine + " Exception Message : " + ex.Message, Results = null, SearchCriteria = null };
            }
        }
        #endregion

        #region GetVehicleTypesForMakeId
        public async Task<ResponseResult<ModelsForMakeIdYearModel>> GetModelsForMakeIdYear(CommonRequest searchObj)
        {
            try
            {
                var result = await _tPServiceUnitOfWork.TPIntegrationService.Value.GetModelsForMakeIdYear(searchObj);
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseResult<ModelsForMakeIdYearModel>() { Count = 0, Message = "Error While Getting Data (GetModelsForMakeIdYear) " + Environment.NewLine + " Exception Message : " + ex.Message, Results = null, SearchCriteria = null };
            }
        }
        #endregion

    }
}
