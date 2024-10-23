using Domain.Common;
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
        public async Task<ResponseResult<dynamic>> GetAllMakes(string format)
        {
            var URL = "getallmakes?format=" + format;
            var result = await GetFrom<ResponseResult<dynamic>>(SharedSettings.GetAllMakesUrl, URL);
            return result;

        }
        #endregion
    }
}
