using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS_PBO.App.Model.M_Customer
{
    internal class M_Registcustomer
    {
         [Key]
         public int id { get; set; }
         [Required]
         public string username { get; set; }
         [Required]
         public string password { get; set; }
         [Required]
         public string email { get; set; }
         [Required]
         public int nomer_hp { get; set; }
    }
}
