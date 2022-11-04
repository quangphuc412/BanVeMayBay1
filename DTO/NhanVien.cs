using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        private string manv, cmnd, tennv, gioitinh, sdt, diachi;
        private DateTime ngaysinh;
        public NhanVien() { }
        public NhanVien(string manv, string cmnd, string tennv, string gioitinh, DateTime ngaysinh, string sdt, string diachi)
        {
            this.MaNV = manv;
            this.CMND = cmnd;
            this.TenNV = tennv;
            this.GioiTinh = gioitinh;
            this.SDT = sdt;
            this.DiaChi = diachi;
            this.NgaySinh = ngaysinh;
        }
        public string MaNV { get => manv; set => manv = value; }
        public string CMND { get => cmnd; set => cmnd = value; }
        public string TenNV { get => tennv; set => tennv = value; }
        public string GioiTinh { get => gioitinh; set => gioitinh = value; }
        public string SDT { get => sdt; set => sdt = value; }
        public string DiaChi { get => diachi; set => diachi = value; }
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
    }
}
