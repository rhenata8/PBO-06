using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS_PBO.App.Model.M_Admin
{
    internal class PesananAdmin
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int nomor_meja { get; set; }
        [Required]
        public DateTime tanggal { get; set; }
        [Required]
        public string nama_customer { get; set; }
        [Required]
        public string makanan { get; set; }
        [Required]
        public string minuman { get; set; }
        [Required]
        public int harga { get; set; }
        [Required]
        public string status  { get; set; }
    }
}
