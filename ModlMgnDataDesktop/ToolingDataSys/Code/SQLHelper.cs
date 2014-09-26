using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace ToolingDataSys.Code
{
    public class SQLHelper
    {
        private static SqlConnection conn = null;
        public static SqlConnection GetConn()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ToolingManDBConnectionString"].ToString());
            return conn;
        }

        public static List<Message> Insert(string uniqQuery, string insertQuery, DataTable dt, SqlParameter[] parameters, int uniqRowIndex, List<ForeignKeyChecker> foreignCheckers=null, string messageContent = "已经存在")
        {
            List<Message> message = new List<Message>();
            using (SqlConnection conn = SQLHelper.GetConn())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlCommand com  = new SqlCommand(uniqQuery, conn, tran);
                    foreach (SqlParameter par in parameters)
                    {
                        com.Parameters.Add(par);
                    }
                    SqlDataReader reader = null;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                parameters[i].Value = row[i];
                            }
                            bool checkResult = true;
                            if (foreignCheckers != null && foreignCheckers.Count > 0)
                            {
                                foreach (ForeignKeyChecker checker in foreignCheckers)
                                {
                                    com.CommandText = checker.CheckQuery;
                                    reader = com.ExecuteReader();
                                    if (!reader.HasRows)
                                    {
                                        checkResult = false;
                                        message.Add(new Message() { message = row[checker.CheckValueIndex] + checker.CheckMessage });
                                    }
                                    reader.Close();
                                }
                            }

                            if (checkResult)
                            {
                                if (uniqQuery != null)
                                {
                                    com.CommandText = uniqQuery;
                                    reader = com.ExecuteReader();
                                    bool exist = reader.HasRows;
                                    reader.Close();
                                    if (exist)
                                    {
                                        message.Add(new Message() { message = row[uniqRowIndex] + messageContent });
                                    }
                                    else
                                    {
                                        com.CommandText = insertQuery;
                                        com.ExecuteNonQuery();
                                        message.Add(new Message() { message = row[uniqRowIndex] + "导入成功" });
                                    }
                                }
                                else
                                {
                                    com.ExecuteNonQuery();
                                }
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
                }
                return message;
            }
        }
         

        public static List<Message> Update(string uniqQuery, string updateQuery, DataTable dt, SqlParameter[] parameters, int uniqRowIndex, List<ForeignKeyChecker> foreignCheckers=null, string messageContent = "不存在，请先导入")
        {
            List<Message> message = new List<Message>();
            using (SqlConnection conn = SQLHelper.GetConn())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlCommand com = null;
                    if (uniqQuery != null)
                        com = new SqlCommand(uniqQuery, conn, tran);
                    else
                        com = new SqlCommand(updateQuery, conn, tran);

                    foreach (SqlParameter par in parameters)
                    {
                        com.Parameters.Add(par);
                    }
                    SqlDataReader reader = null;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            com.CommandText = uniqQuery;
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                if (parameters[i].ParameterName == "@guid")
                                {
                                    parameters[i].Value = Guid.NewGuid();
                                }
                                else
                                {
                                    parameters[i].Value = row[i];
                                }
                            }
                            bool checkResult = true;
                            if (foreignCheckers != null && foreignCheckers.Count > 0)
                            {
                                foreach (ForeignKeyChecker checker in foreignCheckers)
                                {
                                    com.CommandText = checker.CheckQuery;
                                    reader = com.ExecuteReader();
                                    if (!reader.HasRows)
                                    {
                                        checkResult = false;
                                        message.Add(new Message() { message = row[checker.CheckValueIndex] + checker.CheckMessage });
                                    }
                                    reader.Close();
                                }
                            }
                            if (checkResult)
                            {
                                if (uniqQuery != null)
                                {
                                    reader = com.ExecuteReader();
                                    bool exist = reader.HasRows;
                                    reader.Close();
                                    if (exist)
                                    {
                                        com.CommandText = updateQuery;
                                        com.ExecuteNonQuery();
                                        message.Add(new Message() { message = row[uniqRowIndex] + "更新成功" });
                                    }
                                    else
                                    {
                                        message.Add(new Message() { message = row[uniqRowIndex] + messageContent });
                                    }
                                }
                                else
                                {
                                    com.ExecuteNonQuery();
                                }
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
                }
                return message;
            }
        }

        public static List<Message> Delete(string uniqQuery, string deleteQuery, DataTable dt, SqlParameter[] parameters, int uniqRowIndex, string messageContent = "不存在，请先导入")
        {
            List<Message> message = new List<Message>();
            using (SqlConnection conn = SQLHelper.GetConn())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlCommand com = null;
                    if (uniqQuery != null)
                        com = new SqlCommand(uniqQuery, conn, tran);
                    else
                        com = new SqlCommand(deleteQuery, conn, tran);

                    foreach (SqlParameter par in parameters)
                    {
                        com.Parameters.Add(par);
                    }
                    SqlDataReader reader = null;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            com.CommandText = uniqQuery;
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                parameters[i].Value = row[i];
                            }
                            if (uniqQuery != null)
                            {
                                reader = com.ExecuteReader();
                                bool exist = reader.HasRows;
                                reader.Close();
                                if (exist)
                                {
                                    com.CommandText = deleteQuery;
                                    com.ExecuteNonQuery();
                                    message.Add(new Message() { message = row[uniqRowIndex] + "删除成功" });
                                }
                                else
                                {
                                    message.Add(new Message() { message = row[uniqRowIndex] + messageContent });
                                }
                            }
                            else
                            {
                                com.ExecuteNonQuery();
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
                }
                return message;
            }
        }
    }
}
