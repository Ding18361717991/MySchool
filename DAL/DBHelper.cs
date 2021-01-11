using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;

        /// <summary>
        /// 初始化并返回Command
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static SqlCommand PrepareCommand(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;
                cmd.Connection = new SqlConnection(connectionString);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                cmd.Connection.Open();
            }
            catch (Exception)
            {
                
                throw;
            }
            return cmd;
        }

        /// <summary>
        /// 执行返回int类型（增、删、改）
        /// </summary>
        /// <param name="cmdText">sql语句或存储过程名</param>
        /// <param name="cmdType">comman的类型</param>
        /// <param name="parameters">sql语句中的参数，或者存储中的输入参数、输出参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            SqlCommand cmd = PrepareCommand(cmdText,cmdType,parameters);
            int result = 0;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return result;
        }

        /// <summary>
        /// 执行返回Object类型（取单行单列的数据）
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            SqlCommand cmd = PrepareCommand(cmdText, cmdType, parameters);
            object result = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return result;
        }

        /// <summary>
        /// 执行返回DataReader类型
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            SqlCommand cmd = PrepareCommand(cmdText, cmdType, parameters);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);//在关闭读取器的时候自动关闭连接对象
            return reader;
        }
    }
}
