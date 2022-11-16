﻿using BUS;
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
    public partial class frm_DSHangVe : Form
    {
        HangVe hv;
        public frm_DSHangVe()
        {
            InitializeComponent();
        }
        public void XemHangVe()
        {
            HangVeBUS hvBUS = new HangVeBUS();
            DataTable dt = new DataTable();
            dt = hvBUS.HienThi();
            dgvDSHangVe.DataSource = dt;
            dgvDSHangVe.Columns[0].HeaderText = "Mã hạng vé";
            dgvDSHangVe.Columns[1].HeaderText = "Mã chuyến bay";
            dgvDSHangVe.Columns[2].HeaderText = "Khối lượng hành lý tối đa";
            dgvDSHangVe.Columns[3].HeaderText = "Đơn giá";

            dgvDSHangVe.AllowUserToAddRows = false;
            dgvDSHangVe.EditMode = DataGridViewEditMode.EditProgrammatically;
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
        public bool CheckNhapMB()
        {
            if (cb_TenHangVe.Text == "")
            {
                MessageBox.Show("Chọn loại hạng vé!");
                cb_TenHangVe.Focus();
                return false;
            }
            if (txt_MaChuyenBay.Text == "")
            {
                MessageBox.Show("Nhập mã chuyến bay!");
                txt_MaChuyenBay.Focus();
                return false;
            }
            if (txt_KhoiLuongHL.Text == "")
            {
                MessageBox.Show("Nhập khối lượng hành lý tối đa!");
                txt_KhoiLuongHL.Focus();
                return false;
            }
            if(IsNumber(txt_KhoiLuongHL.Text) == false)
            {
                MessageBox.Show("Khối lượng hành lý tối đa chỉ được nhập số nguyên!");
                txt_KhoiLuongHL.Focus();
                return false;
            }
            if (txt_DonGia.Text == "")
            {
                MessageBox.Show("Nhập đơn giá!");
                txt_DonGia.Focus();
                return false;
            }
            if (IsNumber(txt_DonGia.Text) != true)
            {
                MessageBox.Show("Đơn giá chỉ được nhập số nguyên!");
                txt_DonGia.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Reset()
        {
            txt_MaHangVe.ResetText();
            txt_MaHangVe.Enabled = true;
            txt_MaChuyenBay.ResetText();
            txt_KhoiLuongHL.ResetText();
            txt_DonGia.ResetText();
        }
        private void frm_DSHangVe_Load(object sender, EventArgs e)
        {
            XemHangVe();
        }
        private void dgvDSHangVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahangve;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDSHangVe.Rows[e.RowIndex];

                txt_MaHangVe.Text = row.Cells[0].Value.ToString();
                mahangve = txt_MaHangVe.Text;
                if(mahangve.Contains("HV01"))
                {
                    cb_TenHangVe.Text = "HV01";
                }    
                else
                {
                    cb_TenHangVe.Text = "HV02";
                }
                txt_MaChuyenBay.Text = row.Cells[1].Value.ToString();
                txt_KhoiLuongHL.Text = row.Cells[2].Value.ToString();
                txt_DonGia.Text = row.Cells[3].Value.ToString();
                                                                                                                                                                                                        
                txt_MaChuyenBay.Enabled = false;
                txt_MaHangVe.Enabled = false;
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            HangVeBUS hvBUS = new HangVeBUS();
            if (CheckNhapMB())
            {
                hv = new HangVe(txt_MaHangVe.Text, cb_TenHangVe.Text, txt_MaChuyenBay.Text, Convert.ToInt32(txt_KhoiLuongHL.Text), Convert.ToInt32(txt_DonGia.Text));
                if (hvBUS.ThemHV(hv))
                {
                    MessageBox.Show("Thêm hạng vé mới thành công!");
                }
                Reset();
                XemHangVe();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            HangVeBUS hvBUS = new HangVeBUS();
            if (txt_MaHangVe.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hạng vé muốn xóa!");
            }
            else
            {
                if (hvBUS.XoaHV(txt_MaHangVe.Text))
                {
                    MessageBox.Show("Xóa hạng vé thành công!");
                }
                Reset();
                XemHangVe();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            HangVeBUS hvBUS = new HangVeBUS();
            if (CheckNhapMB())
            {
                hv = new HangVe(txt_MaHangVe.Text, cb_TenHangVe.Text, txt_MaChuyenBay.Text, Convert.ToInt32(txt_KhoiLuongHL.Text), Convert.ToInt32(txt_DonGia.Text));
                if (hvBUS.SuaHV(hv))
                {
                    MessageBox.Show("Cập nhật hạng vé thành công!");
                }
                Reset();
                XemHangVe();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (txt_TimKiemMaHangVe.Text == "")
            {
                MessageBox.Show("Nhập mã hạng vé muốn tìm!");
                txt_TimKiemMaHangVe.Focus();
            }
            else
            {
                HangVeBUS hvBUS = new HangVeBUS();
                DataTable dt = new DataTable();
                dt = hvBUS.TimHV(txt_TimKiemMaHangVe.Text);
                txt_TimKiemMaHangVe.ResetText();
                if (dt.Rows.Count > 0)
                {
                    dgvDSHangVe.DataSource = dt;
                    dgvDSHangVe.Columns[0].HeaderText = "Mã hạng vé";
                    dgvDSHangVe.Columns[1].HeaderText = "Mã chuyến bay";
                    dgvDSHangVe.Columns[2].HeaderText = "Khối lượng hành lý tối đa";
                    dgvDSHangVe.Columns[3].HeaderText = "Đơn giá";

                    dgvDSHangVe.AllowUserToAddRows = false;
                    dgvDSHangVe.EditMode = DataGridViewEditMode.EditProgrammatically;
                    MessageBox.Show("Tìm hạng vé thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hạng vé!");
                }
            }
        } 
    }
}
