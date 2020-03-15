using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guide_Ex
{
   public class Sobrenome_Parente
    {

        public bool Parentes(string t)
        {

            List<string> Parent = new List<string>();

            string Pare = "FILHO,FILHA,NETO,NETA,SOBRINHO,SOBRINHA,JUNIOR";

            string[] Parente = Pare.Split(',');

            foreach (string i in Parente)
            {
                Parent.Add(i);
            }

            string a = Parent.FirstOrDefault(b => b.Equals(t.ToUpper()));

            if (string.IsNullOrEmpty(a))
                return false;

            return true;
        }

    }
}
