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
    public class TuyenBayBUS
    {
        private TuyenBayDAO tbDAO;
        public TuyenBayBUS()
        {
            tbDAO = new TuyenBayDAO();
        }
        public bool ThemTB(TuyenBay tb)
        {
            return tbDAO.ThemTB(tb);
        }
        public bool XoaTB(String MaTB)
        {
            return tbDAO.XoaTB(MaTB);
        }
        public DataTable HienThi()
        {
            return tbDAO.HienThi();
        }
        public DataTable TimTB(String MaTB)
        {
            return tbDAO.TimTB(MaTB);
        }
    }
}
