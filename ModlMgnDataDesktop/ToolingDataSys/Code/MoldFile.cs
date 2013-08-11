using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ToolingDataSys.Code
{
    public class MoldFile : IFileData
    {
        public List<Message> Insert(System.Data.DataTable dt)
        {
            List<Message> message = new List<Message>();
            using (SqlConnection conn = SQLHelper.GetConn())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlDataReader reader = null;
                try
                {
                    string q = @"if exists() begin if exists() begin if exists( ) begin    end end end";

                    List<ForeignKeyChecker> checkers = new List<ForeignKeyChecker>() {
                        new ForeignKeyChecker(){
                            CheckQuery="select * from Position where PositionNR=@posi",
                            CheckValueIndex=0,
                            CheckMessage="库位不存在"},
                              new ForeignKeyChecker(){
                            CheckQuery="select * from  Project where ProjectID=@pro",
                            CheckValueIndex=0,
                            CheckMessage="成本中心不存在"},
                                 new ForeignKeyChecker(){
                            CheckQuery="select * from MoldType where MoldTypeID=@type",
                            CheckValueIndex=0,
                            CheckMessage="模具型号不存在"}
                    };
                    string uniqQuery = "select * from Mold where MoldNR=@nr";

                    string insertQuery = @"insert into Mold(MoldNR,MoldTypeID,ProjectID,Name,State,MaxLendHour,ReleaseCycle,MaintainCycle,Producer,Weight,Material)
values(@nr,@type,@pro,@name,1,@max,@release,@main,@producer,@weight,@material);
insert into UniqStorage(UniqStorageId,UniqNR,PositionId,Quantity)
values(NEWID(),@nr,(select top 1 PositionID from Position where PositionNR=@posi),1);
  insert into StorageRecord(StorageRecordNR,PositionId,Destination,Date,Quantity,RecordType,TargetNR,OperatorId)
  values(@guid,(select PositionID from Position where PositionNR=@posi),@posi,@date,1,3,@nr,'DATA-ADMIN');
  insert into MoldLastRecord(MoldNR,StorageRecordNR) values(@nr,@guid);";

                    SqlCommand com = new SqlCommand(q, conn, tran);
                    SqlParameter nr = new SqlParameter("@nr", SqlDbType.VarChar);
                    SqlParameter type = new SqlParameter("@type", SqlDbType.VarChar);
                    SqlParameter pro = new SqlParameter("@pro", SqlDbType.VarChar);
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    SqlParameter max = new SqlParameter("@max", SqlDbType.Int);
                    SqlParameter release = new SqlParameter("@release", SqlDbType.Int);
                    SqlParameter main = new SqlParameter("@main", SqlDbType.Int);
                    SqlParameter producer = new SqlParameter("@producer", SqlDbType.VarChar);
                    SqlParameter weight = new SqlParameter("@weight", SqlDbType.Float);
                    SqlParameter material = new SqlParameter("@material", SqlDbType.VarChar);
                    SqlParameter posi = new SqlParameter("@posi", SqlDbType.VarChar);
                    SqlParameter guid = new SqlParameter("@guid", SqlDbType.UniqueIdentifier);
                    SqlParameter date = new SqlParameter("@date", SqlDbType.DateTime);
                    com.Parameters.Add(nr);
                    com.Parameters.Add(type);
                    com.Parameters.Add(pro);
                    com.Parameters.Add(name);
                    com.Parameters.Add(max);
                    com.Parameters.Add(release);
                    com.Parameters.Add(main);
                    com.Parameters.Add(producer);
                    com.Parameters.Add(weight);
                    com.Parameters.Add(material);
                    com.Parameters.Add(posi);
                    com.Parameters.Add(guid);
                    com.Parameters.Add(date);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            try
                            {
                                posi.Value = row[0];
                                nr.Value = row[1];
                                type.Value = row[4];
                                pro.Value = row[3];
                                name.Value = row[4];
                                max.Value = int.Parse(row[5].ToString().Trim());
                                release.Value = int.Parse(row[6].ToString().Trim());
                                main.Value = int.Parse(row[7].ToString().Trim());
                                producer.Value = row[8];
                                weight.Value = int.Parse(row[9].ToString().Trim());
                                material.Value = row[10];

                                guid.Value = Guid.NewGuid();
                                date.Value = DateTime.Now.ToString();
                                bool checkResult = true;
                                foreach (ForeignKeyChecker checker in checkers)
                                {
                                    com.CommandText = checker.CheckQuery;
                                    reader = com.ExecuteReader();
                                    if (!reader.HasRows)
                                    {
                                        checkResult = false;
                                        message.Add(new Message() { message = row[checker.CheckValueIndex] + checker.CheckMessage });
                                    } reader.Close();
                                }

                                if (checkResult)
                                {
                                    com.CommandText = uniqQuery;
                                    reader = com.ExecuteReader();
                                    bool exist = reader.HasRows;
                                    reader.Close();
                                    if (exist)
                                    {
                                        message.Add(new Message() { message = row[1] + "已经存在" });
                                    }
                                    else
                                    {
                                        com.CommandText = insertQuery;
                                        com.ExecuteNonQuery();
                                    }
                                }
                            }
                            catch (Exception Exception)
                            {
                                throw Exception;
                            }
                        }
                    }
                    tran.Commit();
                    conn.Close();

                }
                catch (Exception e)
                {
                    tran.Rollback();
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    message.Add(new Message() { message = "导入失败" + e.Message });
                }
                finally
                {
                    conn.Close();
                } return message;
            }
        }
    }
}



