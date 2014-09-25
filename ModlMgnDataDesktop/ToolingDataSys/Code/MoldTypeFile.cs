using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ToolingDataSys.Code
{
    public class MoldTypeFile : IFileData
    {
        public List<Message> Insert(System.Data.DataTable dt)
        {
            List<ForeignKeyChecker> checkers = new List<ForeignKeyChecker>() {
            new ForeignKeyChecker(){CheckQuery="select * from MoldCategory where MoldCateID=@cate",CheckValueIndex=2,CheckMessage="模具种类不存在"}};
            string uniqString = "select * from MoldType where MoldTypeID=@type";
            string insertString = "insert into MoldType(MoldTypeID,Name,MoldCateID) values(@type,@name,@cate)";

            SqlParameter[] parameters = new SqlParameter[] { 
             new SqlParameter("@type", SqlDbType.VarChar),
             new SqlParameter("@name", SqlDbType.VarChar),
             new SqlParameter("@cate", SqlDbType.VarChar)
            };
            return SQLHelper.Insert(checkers,uniqString, insertString, dt, parameters, 0);
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


