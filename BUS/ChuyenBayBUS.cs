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
    public class ChuyenBayBUS
    {
        ChuyenBayDAO cbDAO;
        public ChuyenBayBUS()
        {
            cbDAO = new ChuyenBayDAO();
        }
        public bool ThemCB(ChuyenBay cb)
        {
            return cbDAO.ThemCB(cb);
        }
        public bool XoaCB(String MaCB)
        {
            return cbDAO.XoaCB(MaCB);
        }
        public bool SuaCB(ChuyenBay cb)
        {
            return cbDAO.SuaCB(cb);
        }
        public DataTable HienThi()
        {
            return cbDAO.HienThi();
        }
        public DataTable TimCB(String MaCB)
        {
            return cbDAO.TimCB(MaCB);
        }
    }
}
