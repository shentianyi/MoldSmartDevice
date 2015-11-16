using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary.Data;
using ClassLibrary.Repository.Implement;
using ClassLibrary.Repository.Interface;
using ToolingWCF.Utilities;

namespace ToolingWCF
{
    /// <summary>
    /// RestService
    /// </summary>
    public class RestService : IRestService
    {
        /// <summary>
        /// set mold cut
        /// </summary>
        /// <param name="moldNr"></param>
        /// <param name="currentCut"></param>
        /// <param name="totalCut"></param>
        /// <returns></returns>
        public string SetMoldCut(string moldNr, string currentCut, string totalCut)
        {
            Mold mold = null;
            try
            {
                using (IUnitOfWork unitwork = MSSqlHelper.DataContext())
                {
                    IMoldRepository moldRep = new MoldRepository(unitwork);
                    mold = moldRep.GetById(moldNr);
                    if (mold != null)
                    {
                        // update mold state 
                        mold.CurrentCuttimes = int.Parse(currentCut);
                        mold.Cuttedtimes = int.Parse(totalCut);
                    }
                    unitwork.Submit();
                }
            }
            catch (Exception ex)
            {
                LogUtil.log.Error(ex.ToString());
            }
            return moldNr;
        }
    }
}
