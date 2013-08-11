using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ToolingDataSys.Code
{
   public class MoldCateFile:IFileData
    {
        public List<Message> Insert(System.Data.DataTable dt)
        {
            string uniqString = "select * from  MoldCategory where MoldCateID=@cateId";
            string insertString = "insert into MoldCategory(MoldCateID,Name) values(@cateId,@name)";

            SqlParameter[] parameters = new SqlParameter[] { 
             new SqlParameter("@cateId", SqlDbType.VarChar),
             new SqlParameter("@name", SqlDbType.VarChar)
            };
            return SQLHelper.Insert(uniqString, insertString, dt, parameters, 0);
            
        }
    }
}
