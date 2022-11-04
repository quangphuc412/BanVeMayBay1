using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frm_NhanVien : Form
    {
        NhanVien nv;
        public frm_NhanVien()
        {
            InitializeComponent();
        }
        public void XemNhanVien()
        {
            NhanVienBUS nvBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = nvBUS.HienThi();
            dgvNV.DataSource = dt;
            dgvNV.Columns[0].HeaderText = "Mã nhân viên";
            dgvNV.Columns[1].HeaderText = "CMND";
            dgvNV.Columns[2].HeaderText = "Tên nhân viên";
            dgvNV.Columns[3].HeaderText = "Giới tính";
            dgvNV.Columns[4].HeaderText = "Ngày sinh";
            dgvNV.Columns[5].HeaderText = "Số điện thoại";
            dgvNV.Columns[6].HeaderText = "Địa chỉ";

            dgvNV.Columns[0].Width = 150;
            dgvNV.Columns[1].Width = 150;
            dgvNV.Columns[2].Width = 250;
            dgvNV.Columns[3].Width = 100;
            dgvNV.Columns[4].Width = 150;
            dgvNV.Columns[5].Width = 150;
            dgvNV.Columns[6].Width = 250;
            dgvNV.AllowUserToAddRows = false;
            dgvNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            XemNhanVien();
        }
        private void dgvNV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvNV.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txt_MaNV.Text = row.Cells[0].Value.ToString();
                txt_CMND.Text = row.Cells[1].Value.ToString();
                txt_TenNV.Text = row.Cells[2].Value.ToString();
                cb_GioiTinh.Text = row.Cells[3].Value.ToString();
                dtp_NgaySinh.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
                txt_SDT.Text = row.Cells[5].Value.ToString();
                txt_DiaChi.Text = row.Cells[6].Value.ToString();

                //Không cho phép sửa trường MaNV
                txt_MaNV.Enabled = false;
            }
        }
        public bool CheckNhapNV()
        {
            if (txt_MaNV.Text == "")
            {
                MessageBox.Show("Nhập mã nhân viên!");
                txt_MaNV.Focus();
                return false;
            }
            if (txt_CMND.Text == "")
            {
                MessageBox.Show("Nhập số chứng minh nhân dân!");
                txt_CMND.Focus();
                return false;
            }
            if (txt_TenNV.Text == "")
            {
                MessageBox.Show("Nhập tên nhân viên!");
                txt_TenNV.Focus();
                return false;
            }
            if (cb_GioiTinh.Text == "")
            {
                MessageBox.Show("Nhập giới tính nhân viên!");
                cb_GioiTinh.Focus();
                return false;
            }
            if (txt_SDT.Text == "")
            {
                MessageBox.Show("Nhập số điện thoại nhân viên!");
                txt_SDT.Focus();
                return false;
            }
            if (txt_DiaChi.Text == "")
            {
                MessageBox.Show("Nhập địa chỉ nhân viên!");
                txt_DiaChi.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Reset()
        {
            txt_MaNV.ResetText();
            txt_MaNV.Enabled = true;
            txt_CMND.ResetText();
            txt_TenNV.ResetText();
            cb_GioiTinh.ResetText();
            dtp_NgaySinh.ResetText();
            txt_SDT.ResetText();
            txt_DiaChi.ResetText();
            txt_MaNV.Focus();
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            nv = new NhanVien(txt_MaNV.Text, txt_CMND.Text, txt_TenNV.Text, cb_GioiTinh.Text, dtp_NgaySinh.Value, txt_SDT.Text, txt_DiaChi.Text);
            NhanVienBUS nvBUS = new NhanVienBUS();
            if (CheckNhapNV())
            {
                nvBUS.ThemNV(nv);
                MessageBox.Show("Thêm nhân viên mới thành công!");
                Reset();
                XemNhanVien();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            NhanVienBUS nvBUS = new NhanVienBUS();
            if (txt_MaNV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn xóa!");
            }
            else
            {
                nvBUS.XoaNV(txt_MaNV.Text);
                MessageBox.Show("Xóa nhân viên thành công!");
                Reset();
                XemNhanVien();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            nv = new NhanVien(txt_MaNV.Text, txt_CMND.Text, txt_TenNV.Text, cb_GioiTinh.Text, dtp_NgaySinh.Value, txt_SDT.Text, txt_DiaChi.Text);
            NhanVienBUS nvBUS = new NhanVienBUS();
            if (txt_MaNV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn sửa!");
            }
            else
            {
                nvBUS.SuaNV(nv);
                MessageBox.Show("Cập nhật nhân viên thành công!");
                Reset();
                XemNhanVien();
            }
        }

        
    }
}
