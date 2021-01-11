using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchool.Models
{
    public class Pager<T>
    {
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总数据条数
        /// </summary>
        public int DataCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 用于存放信息的集合
        /// </summary>n
        public List<T> InfoList { get; set; }

        public Pager() { }
        public Pager(int pageIndex, int pageSize, int dataCount, List<T> infoList)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.DataCount = dataCount;
            this.PageCount = dataCount / pageSize;//26/10  3页
            if (dataCount % pageSize != 0)
            {
                this.PageCount++;//+1
            }
            this.InfoList = infoList;
        }
    }
}