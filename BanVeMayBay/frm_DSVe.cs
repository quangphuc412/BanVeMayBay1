using BUS;
using DTO;
using Guna.UI2.WinForms.Suite;
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
    public partial class frm_DSVe : Form
    {
        DanhSachVe dsv;
        public frm_DSVe()
        {
            InitializeComponent();
        }
        public void XemDanhSachVe()
        {
            DanhSachVeBUS dsvBUS = new DanhSachVeBUS();
            DataTable dt = new DataTable();
            dt = dsvBUS.HienThi();
            dgv_DSVe.DataSource = dt;
            dgv_DSVe.Columns[0].HeaderText = "Mã danh sách vé";
            dgv_DSVe.Columns[1].HeaderText = "Mã chuyến bay";
            dgv_DSVe.Columns[2].HeaderText = "Số lượng vé";
            dgv_DSVe.Columns[3].HeaderText = "Tình trạng vé";

            dgv_DSVe.AllowUserToAddRows = false;
            dgv_DSVe.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadComboBoxChuyenBay()
        {
            ChuyenBayBUS cbBUS = new ChuyenBayBUS();
            DataTable dt = new DataTable();
            dt = cbBUS.HienThi();
            cb_MaChuyenBay.DisplayMember = "MaChuyenBay";
            cb_MaChuyenBay.ValueMember = "MaChuyenBay";
            cb_MaChuyenBay.DataSource = dt;
        }
        private void frm_DSVe_Load(object sender, EventArgs e)
        {
            txt_MaVe.Enabled = false;
            XemDanhSachVe();
            LoadComboBoxChuyenBay();
            cb_MaChuyenBay.SelectedIndex = -1;
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool CheckNhapDSV()
        {
            if (txt_SoLuongVe.Text == "")
            {
                MessageBox.Show("Nhập số lượng vé!");
                txt_SoLuongVe.Focus();
                return false;
            }
            if (IsNumber(txt_SoLuongVe.Text) == false)
            {
                MessageBox.Show("Số lượng vé chỉ được nhập số nguyên!");
                txt_SoLuongVe.Focus();
                return false;
            }    
            if (txt_TinhTrang.Text == "")
            {
                MessageBox.Show("Nhập tình trạng vé!");
                txt_TinhTrang.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Reset()
        {
            txt_MaVe.Text = "";
            txt_SoLuongVe.ResetText();
            txt_TinhTrang.ResetText();
            txt_TimKiemMaVe.ResetText();
            cb_MaChuyenBay.Enabled = true;
        }
        private void dgv_DSVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_DSVe.Rows[e.RowIndex];

                txt_MaVe.Text = row.Cells[0].Value.ToString();
                cb_MaChuyenBay.Text = row.Cells[1].Value.ToString();
                txt_SoLuongVe.Text = row.Cells[2].Value.ToString();
                txt_TinhTrang.Text = row.Cells[3].Value.ToString();

                cb_MaChuyenBay.Enabled = false;
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            DanhSachVeBUS dsvBUS = new DanhSachVeBUS();
            if (CheckNhapDSV())
            {
                dsv = new DanhSachVe(txt_MaVe.Text, cb_MaChuyenBay.Text, txt_TinhTrang.Text, Convert.ToInt32(txt_SoLuongVe.Text));
                dsvBUS.ThemDSV(dsv);
                Reset();
                XemDanhSachVe();
            }
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DanhSachVeBUS dsvBUS = new DanhSachVeBUS();
            if (txt_MaVe.Text == "")
            {
                MessageBox.Show("Vui lòng chọn vé muốn xóa!");
            }
            else
            {
                dsvBUS.XoaDSV(txt_MaVe.Text);
                Reset();
                XemDanhSachVe();
            }
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            DanhSachVeBUS dsvBUS = new DanhSachVeBUS();
            if (txt_MaVe.Text == "")
            {
                MessageBox.Show("Chọn vé muốn sửa");
            }    
            else
            {
                dsv = new DanhSachVe(txt_MaVe.Text, cb_MaChuyenBay.Text, txt_TinhTrang.Text, Convert.ToInt32(txt_SoLuongVe.Text));
                dsvBUS.SuaDSV(dsv);
                Reset();
                XemDanhSachVe();
            }
        }
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (txt_TimKiemMaVe.Text == "")
            {
                MessageBox.Show("Nhập mã vé muốn tìm!");
                txt_TimKiemMaVe.Focus();
            }
            else
            {
                DanhSachVeBUS dsvBUS = new DanhSachVeBUS();
                DataTable dt = new DataTable();
                dt = dsvBUS.TimDSV(txt_TimKiemMaVe.Text);
                txt_TimKiemMaVe.ResetText();
                if (dt.Rows.Count > 0)
                {
                    dgv_DSVe.DataSource = dt;
                    dgv_DSVe.Columns[0].HeaderText = "Mã danh sách vé";
                    dgv_DSVe.Columns[1].HeaderText = "Mã chuyến bay";
                    dgv_DSVe.Columns[2].HeaderText = "Số lượng vé";
                    dgv_DSVe.Columns[3].HeaderText = "Tình trạng vé";

                    dgv_DSVe.AllowUserToAddRows = false;
                    dgv_DSVe.EditMode = DataGridViewEditMode.EditProgrammatically;
                    MessageBox.Show("Tìm vé thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy vé!");
                }
            }
        }
    }
}
