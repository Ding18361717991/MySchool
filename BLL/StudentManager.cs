
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentManager
    {
        StudentService ss = new StudentService();

        public int GetCount()
        {
            return ss.GetCount();
        }

        public List<Student> GetList(int pageSize, int pageIndex)
        {
            return ss.GetList(pageSize,pageIndex);
        }

        public List<Student> GetAll()
        {
            return ss.GetAll();
        }

        public Student GetStudentById(int id)
        {
            return ss.GetStudentById(id);
        }

        public int Add(Student student)
        {
            return ss.Add(student);
        }

        public int Update(Student student)
        {
            return ss.Update(student);
        }

        public int Delete(int id)
        {
            return ss.Delete(id);
        }
    }
}
