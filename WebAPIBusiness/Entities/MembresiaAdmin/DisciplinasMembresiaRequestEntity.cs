using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.MembresiaAdmin
{
    public class DisciplinasMembresiaRequestEntity
    {
        public bool Selected { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public int Quantity { get; set; }
    }

}
