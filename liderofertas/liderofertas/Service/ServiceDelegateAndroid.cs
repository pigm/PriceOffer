using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppUtils;
using Newtonsoft.Json;

namespace liderofertas.Service
{
    public class ServiceDelegateAndroid
    {
        static ServiceDelegateAndroid instance = null;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ServiceDelegateAndroid Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceDelegateAndroid();
                return instance;
            }
        }

        private bool GetNetworkStatus()
        {
            return ValidationUtils.GetNetworkStatus();
        }

        public async Task<ServiceResult> GetProductosOfertasPasillos(string json)
        {
            ServiceResult result = new ServiceResult();
            if (GetNetworkStatus())
            {
                try
                {
                    string responseString = json;
                    if (!string.IsNullOrEmpty(responseString))
                    {
                        List<ZonaPasillo> zonaPasillo = JsonConvert.DeserializeObject<List<ZonaPasillo>>(responseString);
                        result.Success = true;
                        result.Response = zonaPasillo;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "";
                        result.Response = 999;
                    }
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                    result.Response = 999;
                }
            }
            else
            {
                result.Success = false;
                result.Response = 1000;
                result.Message = ConfigProperties.NOTCONNECTION;
            }
            return result;
        }
    }

    public class ServiceResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Apps.Common.Services.Result.ServiceResult"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public object Response { get; set; }

        /// <summary>
        /// Gets or sets the token response.
        /// </summary>
        /// <value>The token response.</value>
        public string TokenResponse { get; set; }
    }
}
