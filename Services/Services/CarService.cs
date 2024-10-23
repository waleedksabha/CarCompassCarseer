using Domain.Common;
using Domain.Interfaces;
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

        public async Task<ResponseResult<dynamic>> GetAllMakes(string format)
        {
            try
            {
                var ss =await _tPServiceUnitOfWork.TPIntegrationService.Value.GetAllMakes(format);
                return ss;
            }
            catch (Exception ex)
            {
                return new ResponseResult<dynamic>() { Count = 0, Message = "Error While Getting Data " + Environment.NewLine + " Exception Message : " + ex.Message, Results = null, SearchCriteria = null };
            }
        }
    }
}
