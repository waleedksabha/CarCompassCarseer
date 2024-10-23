using Domain.Common;
using Domain.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TPIntegrationService : BaseTPService, ITPIntegrationService
    {
        public TPIntegrationService(HttpClient client) : base(client)
        {
        }

        #region Get All Makes TP
        public async Task<ResponseResult<GetAllMakesModel>> GetAllMakes(CommonRequest searchObj)
        {
            string URL = $"getallmakes?format={searchObj.format}";
            var result = await GetFrom<ResponseResult<GetAllMakesModel>>(SharedSettings.CommonUrl, URL);
            return result;
        }
        #endregion

        #region Get Vehicle Types For Make Id TP
        public async Task<ResponseResult<TypesForMakeModel>> GetVehicleTypesForMakeId(CommonRequest searchObj)
        { 
            string URL = $"GetVehicleTypesForMakeId/{searchObj.makeId}/?format={searchObj.format}";
            var result = await GetFrom<ResponseResult<TypesForMakeModel>>(SharedSettings.CommonUrl, URL);
            return result;
        }
        #endregion

        #region Get Models For Make Id Year TP
        public async Task<ResponseResult<ModelsForMakeIdYearModel>> GetModelsForMakeIdYear(CommonRequest searchObj)
        {
            string URL = $"GetModelsForMakeIdYear/makeId/{searchObj.makeId}/modelyear/{searchObj.modelyear}?format={searchObj.format}";
            var result = await GetFrom<ResponseResult<ModelsForMakeIdYearModel>>(SharedSettings.CommonUrl, URL);
            return result;
        }
        #endregion
    }
}
