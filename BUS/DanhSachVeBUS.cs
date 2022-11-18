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
    public class DanhSachVeBUS
    {
        DanhSachVeDAO dsvDAO;
        public DanhSachVeBUS()
        {
            dsvDAO = new DanhSachVeDAO();
        }
        public void ThemDSV(DanhSachVe dsv)
        {
            dsvDAO.ThemDSV(dsv);
        }
        public void XoaDSV(String Mave)
        {
            dsvDAO.XoaDSV(Mave);
        }
        public void SuaDSV(DanhSachVe dsv)
        {
            dsvDAO.SuaDSV(dsv);
        }
        public DataTable HienThi()
        {
            return dsvDAO.HienThi();
        }
        public DataTable TimDSV(String Mave)
        {
            return dsvDAO.TimDSV(Mave);
        }
    }
}
