using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadnyGrid
{
    class KalendarzDat
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string Opis { get; set; }

        public KalendarzDat(int ID,DateTime Data,string Opis )
        {
            this.ID = ID;
            this.Data = Data;
            this.Opis = Opis;
        }

       

    }

   
}
