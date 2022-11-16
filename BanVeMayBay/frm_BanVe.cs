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
    public partial class frm_BanVe : Form
    {
        public frm_BanVe()
        {
            InitializeComponent();
        }

        private void frm_BanVe_Load(object sender, EventArgs e)
        {
            txt_MaPhieuDatCho.Enabled = false;
        }
    }
}
