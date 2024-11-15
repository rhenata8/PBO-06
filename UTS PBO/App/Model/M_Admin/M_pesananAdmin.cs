using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS_PBO.App.Model.M_Admin
{
    internal class M_pesananAdmin
    {
          [Key]
          public int id { get; set; }
          [Required]
          public string nama { get; set; }
          [Required]
          public string makanan { get; set; }
          [Required]
          public string minuman { get; set; }
          [Required]
          public int nomer_meja { get; set; }
          [Required]
          public int harga { get; set; }
    }
}
