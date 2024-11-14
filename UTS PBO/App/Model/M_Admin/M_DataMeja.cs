using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS_PBO.App.Model.M_Admin
{
    internal class M_DataMeja
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int Nomor_meja { get; set; }
        [Required]
        public int Kapasitas { get; set; }
        [Required]
        public int Lantai { get; set; }
        [Required]
        public Enum Status { get; set; }


    }
}
