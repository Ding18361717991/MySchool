using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GradeService
    {
        public List<Grade> Getll()
        {
            List<Grade> list = new List<Grade>();
            string sql = "select * from Grade";
            SqlDataReader reader = DBHelper.ExecuteReader(sql,CommandType.Text);
            while (reader.Read())
            {
                Grade g = new Grade();
                g.GradeId = int.Parse(reader["GradeId"].ToString());
                g.GradeName = reader["GradeName"].ToString();
                list.Add(g);
            }
            reader.Close();
            return list;
        }
        
    }
}
