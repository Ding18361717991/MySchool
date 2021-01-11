using BLL;
using Model;
using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySchool.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //public ActionResult Index()
        //{

        //}

        //public ActionResult ListT(int page=1) {
        //    var pageSize = 5;
        //    //这里查询学生总数
        //    var studentsCount;
        //    var pagesCount = studentsCount / pageSize + (studentsCount % pageSize == 0 ? 0 : 1);
        //    //这里查询从pageSize*(page-1)到pageSize*page条数据
        //    var students;
        //    ViewBag.pagesCount = pagesCount;
        //    return View(students);
        //}
        public ActionResult List(int pageSize = 5, int pageIndex = 1)
        {
            List<Student> list = new StudentManager().GetList(pageSize,pageIndex);
            Pager<Student> pager = GetPager(pageSize, pageIndex);
            ViewBag.pager = pager;
            return View(list);

        }

        // 根据id删除
        public ActionResult del(int id)
        {
            int result = new StudentManager().Delete(id);
            if (result > 0)
            {
                string js = "<script>alert('删除成功！');location.href='/Home/Index';</script>";
                return Content(js);
            }
            else
            {
                string js = "<script>alert('删除失败！');location.href='/Home/Index';</script>";
                return Content(js);
            }
        }

        // Grade 下拉列表
        public void Bind()
        {
            var slist = new GradeManager().Getll();
            SelectList sslist = new SelectList(slist, "GradeId", "GradeName");
            ViewBag.sslist = sslist;
        }


        public ActionResult Update(int id)
        {
            Bind();
            Student s = new StudentManager().GetStudentById(id);
            return View(s);
        }



        [HttpPost]
        public ActionResult Update(Student student)
        {
            int result = new StudentManager().Update(student);
            if (result > 0)
            {
                string js = "<script>alert('修改成功！');location.href='/Home/Index';</script>";
                return Content(js);
            }
            else
            {
                string js = "<script>alert('修改失败！');location.href='/Home/Index';</script>";
                return Content(js);
            }
        }
        StudentManager s = new StudentManager();

        public Pager<Student> GetPager(int pageSize,int PageIndex)
        {
            int dataCount = s.GetCount();
            List<Student> list = s.GetList(pageSize,PageIndex);

            Pager<Student> pager = new Pager<Student>(PageIndex,pageSize,dataCount,list);

            return pager;
        }
    }
}
