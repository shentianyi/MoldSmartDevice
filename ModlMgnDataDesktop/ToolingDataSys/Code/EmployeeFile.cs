using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ToolingDataSys.Code
{
   public class EmployeeFile : IFileData
    {
       public List<Message> Insert(System.Data.DataTable dt)
       {
           string uniqString = "select * from Employee where EmployeeID=@emp";
           string insertString = "insert into Employee(EmployeeID,Name,Cate) values(@emp,@name,@cate)";

           SqlParameter[] parameters = new SqlParameter[] { 
             new SqlParameter("@emp", SqlDbType.VarChar),
              new SqlParameter("@name", SqlDbType.VarChar),
              new SqlParameter("@cate", SqlDbType.VarChar)
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


