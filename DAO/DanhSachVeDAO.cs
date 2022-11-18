using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DanhSachVeDAO : DBConnection
    {
        public DanhSachVeDAO() : base() { }

        public void ThemDSV(DanhSachVe dsv)
        {
            const string sql = "ThemVeChuyenBay @MaChuyenBay, @SoLuongVe, @TinhTrangVe";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(dsv.Machuyenbay);
            sqlParameters[1] = new SqlParameter("@SoLuongVe", SqlDbType.Int);
            sqlParameters[1].Value = Convert.ToString(dsv.Soluongve);
            sqlParameters[2] = new SqlParameter("@TinhTrangVe", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(dsv.Tinhtrangve);

            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaDSV(String mave)
        {
            const string sql = "XoaVeChuyenBay @MaVe";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaVe", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(mave);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void SuaDSV(DanhSachVe dsv)
        {
            const string sql = "SuaVeChuyenBay @MaVe, @SoLuongVe, @TinhTrangVe";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@MaVe", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(dsv.Mave);
            sqlParameters[1] = new SqlParameter("@SoLuongVe", SqlDbType.Int);
            sqlParameters[1].Value = Convert.ToString(dsv.Soluongve);
            sqlParameters[2] = new SqlParameter("@TinhTrangVe", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(dsv.Tinhtrangve);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XemVeChuyenBay";
            return executeDisplayQuery(sql);
        }
        public DataTable TimDSV(String mave)
        {
            const string sql = "TimVeChuyenBay @MaVe";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaVe", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(mave);

            return executeSearchQuery(sql, sqlParameters);
        }
    }
}
