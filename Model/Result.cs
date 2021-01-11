using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Result
    {
        public int ResultId { get; set; }
        public int StudentNo { get; set; }
        public int SubjectNo { get; set; }
        public decimal StudentResult { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
