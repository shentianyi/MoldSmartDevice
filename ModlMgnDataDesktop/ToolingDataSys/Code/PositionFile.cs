using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ToolingDataSys.Code
{
    public class PositionFile : IFileData
    {
        public List<Message> Insert(System.Data.DataTable dt)
        {
            string uniqString = "select * from Position where PositionNR=@pnr";
            string insertString = "insert into position(PositionID,WarehouseNR,PositionNR,Capicity) values(newid(),'UNIQ-WARE-001',@pnr,@ca)";
            return SQLHelper.Insert(uniqString, insertString, dt, GetParams(), 0);
        }
        public List<Message> Update(DataTable dt)
        {
            string uniqString = "select * from Position where PositionNR=@pnr";
            string updateString = "update Position set  Capicity=@ca  where PositionNR=@pnr";
            return SQLHelper.Update(uniqString, updateString, dt, GetParams(), 0);
        }

        private SqlParameter[] GetParams()
        {
            return new SqlParameter[] { 
             new SqlParameter("@pnr", SqlDbType.VarChar),
             new SqlParameter("@ca", SqlDbType.VarChar)
            };
        }


        public List<Message> Delete(DataTable dt)
        {
            string uniqString = "select * from Position where PositionNR=@pnr";
            string deleteString = @"update UniqStorage set PositionId=(SELECT  PositionID  FROM  Position where PositionNR='NeoniMoldTransfer01')
                   where  PositionId=(SELECT  PositionID  FROM  Position where PositionNR=@pnr);
                   delete from Position where PositionNR=@pnr";
            return SQLHelper.Delete(uniqString, deleteString, dt, 
                new SqlParameter[] { 
                     new SqlParameter("@pnr", SqlDbType.VarChar)
            }, 0);
        }
    }
}
