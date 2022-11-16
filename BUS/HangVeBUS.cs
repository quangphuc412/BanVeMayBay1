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
    public class HangVeBUS
    {
        HangVeDAO hvDAO;
        public HangVeBUS()
        {
            hvDAO = new HangVeDAO();
        }
        public bool ThemHV(HangVe hv)
        {
            return hvDAO.ThemHV(hv);
        }
        public bool XoaHV(String MaHV)
        {
            return hvDAO.XoaHV(MaHV);
        }
        public bool SuaHV(HangVe hv)
        {
            return hvDAO.SuaHV(hv);
        }
        public DataTable HienThi()
        {
            return hvDAO.HienThi();
        }
        public DataTable TimHV(String MaHV)
        {
            return hvDAO.TimHV(MaHV);
        }
    }
}
