using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guide_Ex
{
    public class Sobrenome_Complemento
    {

        public bool complementos(string t)
        {

            List<string> complement = new List<string>();

            string compl = "da,de,do,das,dos";

            string [] complemento = compl.Split(',');

            foreach(string i in complemento)
            {
                complement.Add(i);
            }

            string a = complement.FirstOrDefault(b => b.Equals(t.ToLower()));

            if (string.IsNullOrEmpty(a))
                return false;

            return true;
        }


    }
}
