using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apps.Common.Models.Modelo;
using Apps.Common.Services.Result;
using Apps.Common.Utils.Utilitarios;
using Newtonsoft.Json;

namespace Apps.Common.Services.Delegate
{
    /// <summary>
    /// Service delegate.
    /// </summary>
    public class ServiceDelegate
    {
        static ServiceDelegate instance = null;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ServiceDelegate Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceDelegate();
                return instance;
            }
        }

        #region WEB_API_PRODUCTOS_OFERTAS
        /// <summary>
        /// Gets the productos ofertas.
        /// </summary>
        /// <returns>The productos ofertas.</returns>
        /// <param name="json">Json.</param>
        public async Task<ServiceResult> GetProductosOfertas(string json)
        {
            ServiceResult result = new ServiceResult();
            if (GetNetworkStatus())
            {
                try
                {
                    string responseString = json;
                    if (!string.IsNullOrEmpty(responseString))
                    {
                        List<ProductosOfertasModel> productosOfertas = JsonConvert.DeserializeObject<List<ProductosOfertasModel>>(responseString);
                        result.Success = true;
                        result.Response = productosOfertas;
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
        #endregion

        #region WEB_API_PRODUCTOS_OFERTAS_UNICAS
        /// <summary>
        /// Gets the productos ofertas.
        /// </summary>
        /// <returns>The productos ofertas.</returns>
        /// <param name="json">Json.</param>
        public async Task<ServiceResult> GetProductosOfertasUnicas(string json)
        {
            ServiceResult result = new ServiceResult();
            if (GetNetworkStatus())
            {
                try
                {
                    string responseString = json;
                    if (!string.IsNullOrEmpty(responseString))
                    {
                        List<ProductosOfertasUnicasModel> productosOfertasUnicas = JsonConvert.DeserializeObject<List<ProductosOfertasUnicasModel>>(responseString);
                        result.Success = true;
                        result.Response = productosOfertasUnicas;
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
        #endregion

        #region WEB_API_PRODUCTOS_OFERTAS_PASILLOS
        /// <summary>
        /// Gets the productos ofertas.
        /// </summary>
        /// <returns>The productos ofertas.</returns>
        /// <param name="json">Json.</param>
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
        #endregion



        #region validation_network
        /// <summary>
        /// Gets the network status.
        /// </summary>
        /// <returns><c>true</c>, if network status was gotten, <c>false</c> otherwise.</returns>
        private bool GetNetworkStatus()
        {
            return ValidationUtils.GetNetworkStatus();
        }
        #endregion
    }
}
