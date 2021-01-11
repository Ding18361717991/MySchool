using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GradeManager
    {
        GradeService gs = new GradeService();
        public List<Grade> Getll()
        {
            return gs.Getll();
        }
    }
}
