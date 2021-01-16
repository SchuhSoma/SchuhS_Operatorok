using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Operatorok
{
    class Operator
    {
        public int ELso_Operator;
        public string AritmetikaiValt;
        public int Masodik_Operator;
        
       
        public Operator(string sor)
        {
            var dbok = sor.Split(' ');
            this.ELso_Operator = int.Parse(dbok[0]);
            this.AritmetikaiValt = dbok[1];
            this.Masodik_Operator = int.Parse(dbok[2]);
           
        }
    }
}
