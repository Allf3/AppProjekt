using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Measurement : BaseClass
    {
        public DateTime Date { get; set; }
        public float Humidity { get; set; }
        public float Temperatur { get; set; }
    }
}
