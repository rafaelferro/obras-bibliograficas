using System;
using System.Collections.Generic;

namespace Guide_Ex
{
    class Program
    {
        static void Main(string[] args)
        {

            int q = 0;
            List<string> nomes = new List<string>();
            List<string> NomesFormatados = new List<string>();

            Sobrenome_Complemento sb = new Sobrenome_Complemento();
            Sobrenome_Parente sp = new Sobrenome_Parente();

            Console.WriteLine("Entre com a quantidade de nomes a serem inseridos");
            q = Convert.ToInt32(Console.ReadLine());

            int conta = 1;
            while (q > 0)
            {

                nomes.Add(Recebe_nome(conta));
                conta++;
                q--;
            }


            foreach (string i in nomes)
            {

                string[] F = i.Split(' ');

                List<string> Formata = new List<string>();


                foreach (string b in F)
                {
                    Formata.Add(b);
                }

                if (Formata.Count == 1)
                {

                    string formatado = up(Formata[0]);
                    NomesFormatados.Add(formatado);
                }

                if (Formata.Count == 2)
                {

                    string formatado = up(Formata[1]) + ", " + FirstUper(Formata[0]);
                    NomesFormatados.Add(formatado);
                }

                int controle = Formata.Count - 1;
                if (Formata.Count >= 3)
                {

                    if (sb.complementos(Formata[1]))
                    {
                        if (controle - 1 == 1)
                        {
                            string formatado = up(Formata[2]) + ", " + FirstUper(Formata[0]) + " " + Formata[1].ToLower();
                            NomesFormatados.Add(formatado);
                        }
                        else if (controle - 1 > 1 && sp.Parentes(Formata[controle]))
                        {

                            string formatado = up(Formata[controle - 1]) + " " + up(Formata[controle]) + ", " + FirstUper(Formata[0]) + " " + Formata[1].ToLower();
                            NomesFormatados.Add(formatado);
                        }

                    }
                    else if (sp.Parentes(Formata[controle]) && !sb.complementos(Formata[controle - 1]))
                    {
                        string formatado = up(Formata[controle - 1]) + " " + up(Formata[controle]) + ", " + FirstUper(Formata[0]);
                        NomesFormatados.Add(formatado);

                    }
                }
            }

            foreach(string a in NomesFormatados)
            {
                Console.WriteLine(a);

            }

            Console.ReadKey();
        }

        public static string up(string u)
        {
            return u.ToUpper();
        }

        public static string FirstUper(string t)
        {

            var texto = t;
            var upper = char.ToUpper(texto[0]) + texto.Substring(1);

            return upper;

        }

        public static string Recebe_nome(int conta)
        {
            string a = "";
            Sobrenome_Complemento sb = new Sobrenome_Complemento();

            while (true)
            {
                Console.WriteLine("Entre com o " + conta + " nome");
                a = Console.ReadLine();

                if (a.Contains(" "))
                {
                    string[] b = a.Split(' ');
                    if (sb.complementos(b[1]) && b.Length <= 2)
                    {

                        Console.WriteLine("a palavra " + b[1] + " não é reconhecido como sobrenome");
                        continue;
                    }
                }
                break;
            }

            return a;
        }
    }
}
