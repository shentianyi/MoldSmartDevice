using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ToolingDataSys.Code
{
   public class WorkstationFile : IFileData
    {
        public List<Message> Insert(System.Data.DataTable dt)
        {
            string uniqString = "select * from Workstation where WorkstationID=@id";
            string insertString = " insert into Workstation(WorkstationID,WorkstationType,Name,MaxMoldCount,CurrentMoldCount) values(@id,0,@name,@max,0)";

            SqlParameter[] parameters = new SqlParameter[] { 
             new SqlParameter("@id", SqlDbType.VarChar),
             new SqlParameter("@name", SqlDbType.VarChar),
             new SqlParameter("@max", SqlDbType.VarChar)
            };
            return SQLHelper.Insert(uniqString, insertString, dt, parameters, 0);
        }
    }
}



