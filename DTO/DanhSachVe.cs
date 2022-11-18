using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhSachVe
    {
        private string mave, machuyenbay, tinhtrangve;
        private int soluongve;
        public DanhSachVe() { }
        public DanhSachVe(string mave, string machuyenbay, string tinhtrangve, int soluongve)
        {
            this.Mave = mave;
            this.Machuyenbay = machuyenbay;
            this.Tinhtrangve = tinhtrangve;
            this.Soluongve = soluongve;
        }

        public string Mave { get => mave; set => mave = value; }
        public string Machuyenbay { get => machuyenbay; set => machuyenbay = value; }
        public string Tinhtrangve { get => tinhtrangve; set => tinhtrangve = value; }
        public int Soluongve { get => soluongve; set => soluongve = value; }
    }
}
