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
    public class SanBayBUS
    {
        private SanBayDAO sbDAO;
        public SanBayBUS()
        {
            sbDAO = new SanBayDAO();
        }
        public bool ThemSB(SanBay sb)
        {
            return sbDAO.ThemSB(sb);
        }
        public bool XoaSB(String MaSB)
        {
            return sbDAO.XoaSB(MaSB);
        }
        public bool SuaSB(SanBay sb)
        {
            return sbDAO.SuaSB(sb);
        }
        public DataTable HienThi()
        {
            return sbDAO.HienThi();
        }
        public DataTable TimSB(String MaSB)
        {
            return sbDAO.TimSanBay(MaSB);
        }
    }
}
