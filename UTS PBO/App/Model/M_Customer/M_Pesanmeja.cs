using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS_PBO.App.Model.M_Customer
{
    internal class M_Pesanmeja
    {
        [Key]
        public int nomer_meja { get; set; }
        [Required]
        public int harga { get; set; }
        [Required]
        public DateTime tanggal { get; set; }
    }
}
