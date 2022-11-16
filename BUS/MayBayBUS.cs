using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class MayBayBUS
    {
        MayBayDAO mbDAO;
        public MayBayBUS()
        {
            mbDAO = new MayBayDAO();
        }
        public bool ThemMB(MayBay mb)
        {
            return mbDAO.ThemMB(mb);
        }
        public bool XoaMB(String MaMB)
        {
            return mbDAO.XoaMB(MaMB);
        }
        public bool SuaMB(MayBay mb)
        {
            return mbDAO.SuaMB(mb);
        }
        public DataTable HienThi()
        {
            return mbDAO.HienThi();
        }
        public DataTable TimMB(String MaMB)
        {
            return mbDAO.TimMB(MaMB);
        }
    }
}
