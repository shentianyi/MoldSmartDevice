using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ToolingDataSys.Code
{
    public class MoldFile : IFileData, IMoldFile
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
                    string q = @"if exists() begin if exists() begin if exists( ) begin  end end end";

                    List<ForeignKeyChecker> checkers = new List<ForeignKeyChecker>() {
                        new ForeignKeyChecker(){
                            CheckQuery="select * from Position where PositionNR=@posi",
                            CheckValueIndex=0,
                            CheckMessage="库位不存在"},
                              new ForeignKeyChecker(){
                            CheckQuery="select * from  Project where ProjectID=@pro",
                            CheckValueIndex=3,
                            CheckMessage="成本中心不存在"},
                                 new ForeignKeyChecker(){
                            CheckQuery="select * from MoldType where MoldTypeID=@type",
                            CheckValueIndex=2,
                            CheckMessage="模具型号不存在"}
                    };
                    string uniqQuery = "select * from Mold where MoldNR=@nr";

                    string insertQuery = @"insert into Mold(MoldNR,MoldTypeID,ProjectID,Name,State,MaxCuttimes,CurrentCuttimes,MaxLendHour,ReleaseCycle,MaintainCycle,Producer,Weight,Material)
values(@nr,@type,@pro,@name,1,@maxCut,0,@max,@release,@main,@producer,@weight,@material);
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
                    SqlParameter maxCut = new SqlParameter("@maxCut", SqlDbType.BigInt);
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
                    com.Parameters.Add(maxCut);
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
                                type.Value = row[2];
                                pro.Value = row[3];
                                name.Value = row[4];
                                maxCut.Value = int.Parse(row[5].ToString().Trim());
                                max.Value = int.Parse(row[6].ToString().Trim());
                                release.Value = int.Parse(row[7].ToString().Trim());
                                main.Value = int.Parse(row[8].ToString().Trim());
                                producer.Value = row[9];
                                weight.Value = int.Parse(row[10].ToString().Trim());
                                material.Value = row[11];

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



        public List<Message> Update(DataTable dt)
        {
            string uniqString = "select * from Mold where MoldNr=@nr";
            string updateString = @"update Mold set MoldTypeID=@type,ProjectID=@pro,Name=@name,MaxCuttimes=@maxCut,MaxLendHour=@max,ReleaseCycle=@release,MaintainCycle=@main,
            Producer=@producer,Weight=@weight,Material=@material where MoldNr=@nr";
            return SQLHelper.Update(uniqString, updateString, dt, GetParams(), 0);
        }

        private SqlParameter[] GetParams()
        {
            return new SqlParameter[] { 
               new SqlParameter("@nr", SqlDbType.VarChar),
               new SqlParameter("@type", SqlDbType.VarChar),
               new SqlParameter("@pro", SqlDbType.VarChar),
               new SqlParameter("@name", SqlDbType.VarChar),
               new SqlParameter("@maxCut", SqlDbType.BigInt),
               new SqlParameter("@max", SqlDbType.Int),
               new SqlParameter("@release", SqlDbType.Int),
               new SqlParameter("@main", SqlDbType.Int),
               new SqlParameter("@producer", SqlDbType.VarChar),
               new SqlParameter("@weight", SqlDbType.Float),
               new SqlParameter("@material", SqlDbType.VarChar)
            };
        }


        public List<Message> Delete(DataTable dt)
        {
            string uniqString = "select * from Mold where MoldNr=@nr";
            string deleteString = @"delete from UniqStorage where UniqNR=@nr;
                   delete from MoldLastRecord where MoldNr=@nr;
                   delete from Report where MoldID=@nr;
                   delete from Mold where MoldNr=@nr";
            return SQLHelper.Delete(uniqString, deleteString, dt,
                new SqlParameter[] { 
                     new SqlParameter("@nr", SqlDbType.VarChar)
            }, 0);
        }

        public List<Message> TransPosition(DataTable dt)
        {
            List<ForeignKeyChecker> checkers = new List<ForeignKeyChecker>() {
            new ForeignKeyChecker(){CheckQuery="select * from Position where PositionNR=@posi",CheckValueIndex=1,CheckMessage="新库位不存在，请先导入库位"}};

            string uniqString = "select * from Mold where MoldNr=@nr";
            string updateString = @"update UniqStorage set PositionId =(SELECT  PositionID  FROM  Position where PositionNR='LeoniMoldTransfer01')
where PositionId in (SELECT PositionID  FROM  Position where PositionNR=@posi);
update UniqStorage set PositionId =(SELECT  top 1  PositionID  FROM  Position where PositionNR=@posi)
where UniqNR=@nr;
if (select [State] from Mold where MoldNR=@nr)=1
begin 
 insert into StorageRecord(StorageRecordNR,PositionId,Destination,[Date],Quantity,RecordType,TargetNR,OperatorId)
 values(@guid,(select top 1 PositionID from Position where PositionNR=@posi),@posi,GETDATE(),1,5,@nr,'DATA-ADMIN');
 update MoldLastRecord set StorageRecordNR=@guid where MoldNR=@nr;
end";
            SqlParameter guid = new SqlParameter("@guid", SqlDbType.UniqueIdentifier);
           
            return SQLHelper.Update(uniqString, updateString, dt, new SqlParameter[] { 
                     new SqlParameter("@nr", SqlDbType.VarChar),
                      new SqlParameter("@posi", SqlDbType.VarChar),
                      new SqlParameter("@guid", SqlDbType.UniqueIdentifier)
            }, 0);
        }
    }
}



