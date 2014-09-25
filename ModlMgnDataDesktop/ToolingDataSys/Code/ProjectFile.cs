using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ToolingDataSys.Code
{
    public class ProjectFile : IFileData
    {
        public List<Message> Insert(System.Data.DataTable dt)
        {
            string uniqString = "select * from  Project where ProjectID=@pro";
            string insertString = "insert into Project(ProjectID,Name) values(@pro,@name)";

            SqlParameter[] parameters = new SqlParameter[] { 
             new SqlParameter("@pro", SqlDbType.VarChar),
             new SqlParameter("@name", SqlDbType.VarChar)
            };
            return SQLHelper.Insert(uniqString, insertString, dt, parameters, 0);
        }
        public List<Message> Update(DataTable dt)
        {
            throw new NotImplementedException();
        }


        public List<Message> Delete(DataTable dt)
        {
            throw new NotImplementedException();
        }
    }
}


