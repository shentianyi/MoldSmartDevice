using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using ClassLibrary.Data;

namespace ToolingWCF
{
    /// <summary>
    /// Rest Service
    /// </summary>
    [ServiceContract]    
    public interface IRestService
    {
        /// <summary>
        /// set mole cut
        /// </summary>
        /// <param name="moldNr"></param>
        /// <param name="currentCut"></param>
        /// <param name="totalCut"></param>
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "set_cut/{moldNr}/{currentCut}/{totalCut}")]
        [OperationContractAttribute(Name = "SetCut")]
        string SetMoldCut(string moldNr, string currentCut, string totalCut);
    }
}
