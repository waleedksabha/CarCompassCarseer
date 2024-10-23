using Domain.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITPIntegrationService
    {
        Task<ResponseResult<GetAllMakesModel>> GetAllMakes(CommonRequest searchObj);
        Task<ResponseResult<TypesForMakeModel>> GetVehicleTypesForMakeId(CommonRequest searchObj);
        Task<ResponseResult<ModelsForMakeIdYearModel>> GetModelsForMakeIdYear(CommonRequest searchObj);
    }
}
