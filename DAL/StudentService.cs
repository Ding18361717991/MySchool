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
    public class StudentService
    {
        // 查询
        public List<Student> GetAll()
        {
            List<Student> list = new List<Student>();
            string sql = "select s.StudentNo,s.LoginPwd,s.StudentName,s.Sex,g.GradeName,s.Phone,Address,s.BornDate,s.Email from Student s join Grade g on g.GradeId = s.GradeId";
            SqlDataReader reader = DBHelper.ExecuteReader(sql, CommandType.Text);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student s = new Student();
                    s.StudentNo = int.Parse(reader["StudentNo"].ToString());
                    s.LoginPwd = reader["LoginPwd"].ToString();
                    s.StudentName = reader["StudentName"].ToString();
                    s.Sex = bool.Parse(reader["Sex"].ToString());
                    s.GradeName = reader["GradeName"].ToString();
                    s.Phone = reader["Phone"].ToString();
                    s.Address = reader["Address"].ToString();
                    s.BornDate = DateTime.Parse(reader["BornDate"].ToString());
                    s.Email = reader["Email"].ToString();

                    list.Add(s);
                }
            }
            reader.Close();
            return list;
        }

        // 根据id查询
        public Student GetStudentById(int id)
        {
            Student student = null;
            string sql = "select s.StudentNo,s.LoginPwd,s.StudentName,s.Sex,s.GradeId,s.Phone,s.BornDate,s.Address,s.Email from Student s join Grade g on g.GradeId = s.GradeId where StudentNo=@StudentNo";
            SqlDataReader reader = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter("@StudentNo", id));
            if (reader.Read())
            {
                student = new Student();
                student.StudentNo = int.Parse(reader["StudentNo"].ToString());
                student.LoginPwd = reader["LoginPwd"].ToString();
                student.StudentName = reader["StudentName"].ToString();
                student.Sex = bool.Parse(reader["Sex"].ToString());
                student.GradeName = reader["GradeId"].ToString();
                student.Phone = reader["Phone"].ToString();
                student.Address = reader["Address"].ToString();
                student.Email = reader["Email"].ToString();
                student.BornDate = DateTime.Parse(reader["BornDate"].ToString());
            }
            reader.Close();
            return student;
        }

        // 添加
        public int Add(Student student)
        {
            int result = 0;
            string sql = "insert into Student(LoginPwd,StudentName,Sex,GradeId,Phone,BornDate) values(@LoginPwd,@StudentName,@Sex,@GradeId,@Phone,@BornDate)";
            result = DBHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@LoginPwd", student.LoginPwd),
                new SqlParameter("@StudentName", student.StudentName),
                new SqlParameter("@Sex", student.Sex),
                new SqlParameter("@GradeId", student.GradeId),
                new SqlParameter("@Phone", student.Phone),
                new SqlParameter("@BornDate", student.BornDate));
            return result;
        }



        // 修改
        public int Update(Student student)
        {
            int result = 0;
            string sql = "update Student set LoginPwd = @LoginPwd,StudentName = @StudentName,Sex=@Sex,GradeId=@GradeId,Phone=@Phone,Address = @Address,BornDate = @BornDate,Email = @Email where StudentNo=@StudentNo";
            result = DBHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@LoginPwd", student.LoginPwd),
                new SqlParameter("@StudentName", student.StudentName),
                new SqlParameter("@Sex", student.Sex),
                new SqlParameter("@GradeId", student.GradeId),
                new SqlParameter("@Phone", student.Phone),
                new SqlParameter("@Address", student.Address),
                new SqlParameter("@BornDate", student.BornDate),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@StudentNo", student.StudentNo));
            return result;
        }


        // 删除
        public int Delete(int id)
        {
            string sql = "delete from Student where StudentNo = @StudentNo";
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@StudentNo", id));
        }

        public int GetCount()
        {
            string sql = "select count(1) from Student";
            int result = (int)DBHelper.ExecuteScalar(sql, CommandType.Text);


            return result;
        }

        public List<Student> GetList(int pageSize, int pageIndex)
        {

            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            string sql = @"select * from (select ROW_NUMBER()over(order by StudentNo asc) as StudentNo,LoginPwd,StudentName,Sex,g.GradeName,Phone,Address,BornDate,Email from Student join Grade g on g.GradeId = Student.GradeId ) Student where StudentNo between @start and @end";

            SqlParameter[] paras = {
                                    new SqlParameter("@start",start),
                                    new SqlParameter("@end",end)
                                   };
            List<Student> list = new List<Student>();
            SqlDataReader reader = DBHelper.ExecuteReader(sql, CommandType.Text, paras);
            {
                while (reader.Read())
                {
                    Student s = new Student();
                    s.StudentNo = int.Parse(reader["StudentNo"].ToString());
                    s.LoginPwd = reader["LoginPwd"].ToString();
                    s.StudentName = reader["StudentName"].ToString();
                    s.Sex = bool.Parse(reader["Sex"].ToString());
                    s.GradeName = reader["GradeName"].ToString();
                    s.Phone = reader["Phone"].ToString();
                    s.Address = reader["Address"].ToString();
                    s.BornDate = DateTime.Parse(reader["BornDate"].ToString());
                    s.Email = reader["Email"].ToString();

                    list.Add(s);
                }
            }

            return list;
            
        }

    }
}
