using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;

namespace DAO
{
    public class NhanVienDAO : DBConnection
    {
        public NhanVienDAO() : base() { }
        public void ThemNV(NhanVien nv)
        {
            const string sql = "insert into NHANVIEN(MaNV, CMND, TenNV, GioiTinh, NgaySinh, SDT, DiaChi) values(@MaNV, @CMND, @TenNV, @GioiTinh, @NgaySinh, @SDT, @DiaChi)";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@MaNV", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(nv.MaNV);
            sqlParameters[1] = new SqlParameter("@CMND", SqlDbType.Char);
            sqlParameters[1].Value = Convert.ToString(nv.CMND);
            sqlParameters[2] = new SqlParameter("@TenNV", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(nv.TenNV);
            sqlParameters[3] = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(nv.GioiTinh);
            sqlParameters[4] = new SqlParameter("@NgaySinh", SqlDbType.Date);
            sqlParameters[4].Value = Convert.ToString(nv.NgaySinh);
            sqlParameters[5] = new SqlParameter("@SDT", SqlDbType.Char);
            sqlParameters[5].Value = Convert.ToString(nv.SDT);
            sqlParameters[6] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(nv.DiaChi);
            
            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaNV(String maNV)
        {
            const string sql = "delete from NHANVIEN where MaNV = @MaNV";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaNV", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(maNV);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void SuaNV(NhanVien nv)
        {
            const string sql = "update NHANVIEN set CMND = @CMND, TenNV = @TenNV, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, SDT = @SDT, DiaChi = @DiaChi where MaNV = @MaNV";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@MaNV", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(nv.MaNV);
            sqlParameters[1] = new SqlParameter("@CMND", SqlDbType.Char);
            sqlParameters[1].Value = Convert.ToString(nv.CMND);
            sqlParameters[2] = new SqlParameter("@TenNV", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(nv.TenNV);
            sqlParameters[3] = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(nv.GioiTinh);
            sqlParameters[4] = new SqlParameter("@NgaySinh", SqlDbType.Date);
            sqlParameters[4].Value = Convert.ToString(nv.NgaySinh);
            sqlParameters[5] = new SqlParameter("@SDT", SqlDbType.Char);
            sqlParameters[5].Value = Convert.ToString(nv.SDT);
            sqlParameters[6] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(nv.DiaChi);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from NHANVIEN";
            return executeDisplayQuery(sql);
        }
    }
}