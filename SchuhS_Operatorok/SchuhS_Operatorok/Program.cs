using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchuhS_Operatorok
{
    class Program
    {
        static List<Operator> OperatorList;
        static List<string> MuveletList;
        static Dictionary<string, int> Statisztika;
        static string BekertMuvelet;
       
        static List<string> Muvelet;
        static void Main(string[] args)
        {
            Muvelet = new List<string>() { "+", "-", "*", "/", "div", "mod" };
            Feladat1Beolvasas(); Console.WriteLine("\n-------------------------------------------\n");
            Feladat2BeolvasottSorokSzama(); Console.WriteLine("\n-------------------------------------------\n");
            Feladat3ModSzam(); Console.WriteLine("\n-------------------------------------------\n");
            Feladat410elOszthato(); Console.WriteLine("\n-------------------------------------------\n");
            Feladat5Statisztika(); Console.WriteLine("\n-------------------------------------------\n");
            Feladat67(); Console.WriteLine("\n-------------------------------------------\n");
            Feladat8(); Console.WriteLine("\n-------------------------------------------\n");
            Console.ReadKey();
        }

        private static void Feladat8()
        {
            Console.WriteLine("8.Feladat: Kiíratás");
            var sw = new StreamWriter(@"eredmenyek.txt", false, Encoding.UTF8);
            double Eredmeny2 = 0;
            
            foreach (var o in OperatorList)
            {
                string Beolvasas2 = (o.ELso_Operator).ToString() + " " + o.AritmetikaiValt + " " + o.Masodik_Operator.ToString();
                if (Muvelet.Contains(o.AritmetikaiValt) && !Beolvasas2.Contains("div 0"))
                {
                    if (o.AritmetikaiValt == "+")
                    {
                        Eredmeny2 = o.ELso_Operator + o.Masodik_Operator;
                    }
                    if (o.AritmetikaiValt == "-")
                    {
                        Eredmeny2 = o.ELso_Operator - o.Masodik_Operator;
                    }
                    if (o.AritmetikaiValt == "*")
                    {
                        Eredmeny2 = o.ELso_Operator * o.Masodik_Operator;
                    }
                    if (o.AritmetikaiValt == "/")
                    {
                        Eredmeny2 = o.ELso_Operator / o.Masodik_Operator;
                    }
                    if (o.AritmetikaiValt == "mod")
                    {
                        Eredmeny2 = (double)o.ELso_Operator % (double)o.Masodik_Operator;
                    }
                    if (o.AritmetikaiValt == "div")
                    {
                        Eredmeny2 = (double)o.ELso_Operator / (double)o.Masodik_Operator;
                    }
                    Console.WriteLine("\t\t{0} = {1}", Beolvasas2, Eredmeny2);
                    sw.WriteLine("{0} = {1}", Beolvasas2, Eredmeny2);

                }
                if (Beolvasas2.Contains("div 0"))
                {
                    Console.WriteLine("\t\t{0} = {1}", Beolvasas2, "Egyéb hiba!");
                    sw.WriteLine("{0} = {1}", Beolvasas2, "Hiba!");
                }
                if (Beolvasas2.Contains("/ 0"))
                {
                    Console.WriteLine("\t\t{0} = {1}", Beolvasas2, "Hiba!");
                    sw.WriteLine("{0} = {1}", Beolvasas2, "Hiba!");
                }
                if (!Muvelet.Contains(o.AritmetikaiValt))
                {
                    Console.WriteLine("\t\t{0} = {1}", Beolvasas2, "Hibás operátor!");
                    sw.WriteLine("{0} = {1}", Beolvasas2, "Hibás operátor!");
                }
            }
        }

        private static void Feladat67()
        {
            Console.WriteLine("7.Feladat: Bekérés");
            int db = 0;
            
            double Eredmeny = 0;
            do
            {
                Console.Write("\tKérem adjon meg egy kifejezést (pl: 1 + 1) : ");
                string Bekeres = Console.ReadLine();
                var dbok = Bekeres.Split(' ');
                int Szam1 = int.Parse(dbok[0]);
                BekertMuvelet = dbok[1];
                int Szam2 = int.Parse(dbok[2]); 
                if(Muvelet.Contains(BekertMuvelet) && !Bekeres.Contains("div 0") && db<5)
                {
                    if (BekertMuvelet == "+")
                    {
                        Eredmeny = Szam1 + Szam2;
                    }
                    if (BekertMuvelet == "-")
                    {
                        Eredmeny = Szam1 - Szam2;
                    }
                    if (BekertMuvelet == "*")
                    {
                        Eredmeny = Szam1 * Szam2;
                    }
                    if (BekertMuvelet == "/")
                    {
                        Eredmeny = Szam1 / Szam2;
                    }
                    if (BekertMuvelet == "mod")
                    {
                        Eredmeny = Szam1 % Szam2;
                    }
                    if (BekertMuvelet == "div")
                    {
                        Eredmeny = (double)Szam1 / (double)Szam2;
                    }
                    Console.WriteLine("\t\t{0} = {1}", Bekeres, Eredmeny);
                   
                }
                if(Bekeres.Contains("div 0"))
                {
                    Console.WriteLine("\t\t{0} = {1}", Bekeres, "Egyéb hiba!");
                }
                if (Bekeres.Contains("/ 0"))
                {
                    Console.WriteLine("\t\t{0} = {1}", Bekeres, "Hiba!");
                }
                if(!Muvelet.Contains(BekertMuvelet))
                {
                    Console.WriteLine("\t\t{0} = {1}", Bekeres, "Hibás operátor!");
                }
                
                db++;
            } while (db != 5); 

        }

        private static void Feladat5Statisztika()
        {
            Console.WriteLine("5.FeladatMűleletek statisztikája");
            MuveletList = new List<string>();
            foreach (var o in OperatorList)
            {
                if (!MuveletList.Contains(o.AritmetikaiValt))
                {
                    MuveletList.Add(o.AritmetikaiValt);
                }                    
            }
            Statisztika = new Dictionary<string, int>();
            foreach (var m in MuveletList)
            {
                int db = 0;
                foreach (var o in OperatorList)
                {
                    if(m==o.AritmetikaiValt)
                    { db++; }
                }
                Statisztika.Add(m, db);
            }
            foreach (var s in Statisztika)
            {if(s.Key=="+" || s.Key=="-" || s.Key=="/" || s.Key == "div" || s.Key == "mod" || s.Key == "*" )
                Console.WriteLine("\t{0,-4} : {1}",s.Key,s.Value);
            }
        }

        private static void Feladat410elOszthato()
        {
            Console.WriteLine("4.Feladat: Van-e olyan számpár melynek mindkét tagja osztható 10-el");
            bool Dontes = false;
            foreach (var o in OperatorList)
            {
                if(o.ELso_Operator%10==0 && o.Masodik_Operator%10==0)
                {
                    Dontes = true;
                    break;
                }
            }
            if (Dontes == true) Console.WriteLine("\tVan ilyen számpár");
            else Console.WriteLine("\tNincs ilyen számpár");
        }

        private static void Feladat3ModSzam()
        {
            Console.WriteLine("3.Feladat: Maradékos osztás száma");
            int dbMod = 0;
            foreach (var o in OperatorList)
            {
                if(o.AritmetikaiValt=="mod")
                { dbMod++; }
            }
            Console.WriteLine("\tMaradékos soztás száma :{0}", dbMod);
        }

        private static void Feladat2BeolvasottSorokSzama()
        {
            Console.WriteLine("2.Feladat: Beolvasot sorok száma");
            Console.WriteLine("\tBeolvasott sorok száma: {0}",OperatorList.Count);
        }

        private static void Feladat1Beolvasas()
        {
            Console.WriteLine("1.Feladat: Adatok beolvasása");
            OperatorList = new List<Operator>();
            int db = 0;
            var sr = new StreamReader(@"kifejezesek.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                OperatorList.Add(new Operator(sr.ReadLine()));
                db++;
            }
            sr.Close();
            if (db > 0) Console.WriteLine("\tSikeres beolvasás, beolvastt sorok száma: {0}", db);
            else Console.WriteLine("\tSikertelen beolvasás");
        }
    }
}
