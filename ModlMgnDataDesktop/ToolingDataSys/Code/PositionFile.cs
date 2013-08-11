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

            SqlParameter[] parameters = new SqlParameter[] { 
            new SqlParameter("@pnr", SqlDbType.VarChar),
             new SqlParameter("@ca", SqlDbType.VarChar)
            };
            return SQLHelper.Insert(uniqString, insertString, dt, parameters, 0);
        }
    }
}
