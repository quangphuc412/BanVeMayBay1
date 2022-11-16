﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class SanBayDAO : DBConnection
    {
        public SanBayDAO() : base() { }
        public bool ThemSB(SanBay sb)
        {
            const string sql = "ThemSanBay @MaSanBay, @TenSanBay, @ViTri";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@MaSanBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(sb.MaSanBay);
            sqlParameters[1] = new SqlParameter("@TenSanBay", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(sb.TenSanBay);
            sqlParameters[2] = new SqlParameter("@ViTri", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(sb.ViTri);

            return executeInsertQuery(sql, sqlParameters);
        }
        public bool XoaSB(String maSB)
        {
            const string sql = "XoaSanBay @MaSanBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaSanBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maSB);

            return executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public bool SuaSB(SanBay sb)
        {
            const string sql = "SuaSanBay @MaSanBay, @TenSanBay, @ViTri";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@MaSanBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(sb.MaSanBay);
            sqlParameters[1] = new SqlParameter("@TenSanBay", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(sb.TenSanBay);
            sqlParameters[2] = new SqlParameter("@ViTri", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(sb.ViTri);

            return executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XemSanBay";
            return executeDisplayQuery(sql);
        }
        public DataTable TimSanBay(string maSB)
        {
            const string query = "TimSanBay @MaSanBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaSanBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maSB);

            return executeSearchQuery(query, sqlParameters);
        }
    }
}
