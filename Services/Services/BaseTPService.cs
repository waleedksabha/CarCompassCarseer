using Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BaseTPService
    {
        protected readonly HttpClient client;

        public BaseTPService(HttpClient client)
        {
            this.client = client;
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Add("Accept", "application/json;profile=PascalCase;charset=utf-8");
            this.client.DefaultRequestHeaders.TransferEncodingChunked = false;
        }

        #region GetFrom
        public async Task<T> GetFrom<T>(string baseAddress, string url)
        {
            string request = baseAddress + url;


            var obj = Activator.CreateInstance(typeof(T));
            try
            {
                WriteLog("Start : " + Environment.NewLine + request); 
                var urirequest = new Uri(request);
                try
                { 
                    using (HttpResponseMessage response = await client.GetAsync(urirequest).ConfigureAwait(false))
                    { 
                        if (response.IsSuccessStatusCode)
                        { 
                            using (HttpContent content = response.Content)
                            {
                                string result = await content.ReadAsStringAsync();
                                obj = JsonConvert.DeserializeObject<T>(result);
                                WriteLog("End Result : " + Environment.NewLine + result);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog(request + "  " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                WriteLog(request + "  " + ex.Message);
            } 
            return (T)obj;
        }
        #endregion         

        #region WriteLog 
        public void WriteLog(params string[] strLogs)
        {
            try
            {
                string strPath = SharedSettings.LogPath;
                if (strLogs[0].Contains("[SUBFOLDER]"))
                    strPath += strLogs[0].Replace("[SUBFOLDER]", "");

                string[] arrPaths = new string[] { strPath };
                int[][] FileCount = null;

                FileCount = new int[1][];
                for (int i = 0; i < 1; i++)
                {
                    FileCount[i] = new int[1];
                }

                int Index = 0;
                int RegionIndex = 0;
                string strLog;

                StringBuilder Bldr = new StringBuilder();
                int _index = 0;
                if (strLogs[0].Contains("[SUBFOLDER]"))
                    _index = 1;
                for (int i = _index; i < strLogs.Length; i++)
                    Bldr.Append(strLogs[i]);
                strLog = Bldr.ToString();

                string RegionPath = arrPaths[Index];
                string fname = DateTime.Now.ToString("yyyy-MM-dd");

                if (!Directory.Exists(arrPaths[Index]))
                    Directory.CreateDirectory(arrPaths[Index]);

                if (!Directory.Exists(RegionPath))
                    Directory.CreateDirectory(RegionPath);

                if (!System.IO.File.Exists(RegionPath + fname + "_000.log"))
                    FileCount[RegionIndex][Index] = 0;

                string fileName = RegionPath + fname + "_" + FileCount[RegionIndex][Index].ToString("000") + ".log";
                System.IO.FileInfo info = new System.IO.FileInfo(fileName);

                while (info.Exists && info.Length > 1024 * 1024 * 2)
                {
                    FileCount[RegionIndex][Index]++;
                    fileName = RegionPath + fname + "_" + FileCount[RegionIndex][Index].ToString("000") + ".log";
                    info = new FileInfo(fileName);
                }

                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(">>" + DateTime.Now.ToLongTimeString() + "\t:" + strLog);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            { 
            }
        }
        #endregion
    }
}
