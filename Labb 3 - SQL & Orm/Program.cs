using Labb_3___SQL___Orm.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb2___Olof_Sandberg
{

    internal class Program
    {

        static void Main(string[] args)
        {
            using SkolaDBContext dBContext = new SkolaDBContext();

            Menu(dBContext);

        }
        public static void Menu(SkolaDBContext dBContext)
        {
            bool runProgram = true;
            while (runProgram)
            {
                Console.WriteLine("1, Hämta alla elever");
                Console.WriteLine("2, Hämta alla elever från en viss klass");
                Console.WriteLine("3, Läg till ny personal");

                int input = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (input)
                {
                    case 1:
                        Console.WriteLine("1, Sortera elever på förnamn i stigande ordning");
                        Console.WriteLine("2, Sortera elever på förnamn i fallande ordning");
                        Console.WriteLine("3, Sortera elever på efternamn i stigande ordning");
                        Console.WriteLine("4, Sortera elever på efternamn i fallande ordning");

                        int input2 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        switch (input2)
                        {
                            case 1:
                                SortStudentsAscendingFirstName(dBContext);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 2:
                                SortStudentsDescendingFirstName(dBContext);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 3:
                                SortStudentsAscendingLastName(dBContext);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 4:
                                SortStudentsDescendingLastName(dBContext);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            default:
                                break;
                        }

                        break;
                    case 2:

                        Console.WriteLine("Från vilken klass vill du se eleverna?");

                        foreach (var distinctKlass in dBContext.TblElevers.Select(e => e.Klass).Distinct())
                        {
                            Console.WriteLine(distinctKlass);

                        }

                        string inputClass = Console.ReadLine();
                        var resultClass = dBContext.TblElevers.
                        Where(e => e.Klass == inputClass);
                        Console.Clear();
                        foreach (TblElever e in resultClass)
                        {
                            Console.WriteLine($"{e.Förnamn} {e.Efternamn}\t{e.Klass}");
                        }
                        Console.ReadKey();
                        Console.Clear();


                        break;
                    case 3:
                        Console.WriteLine("Ange lärarens förnamn : ");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Ange lärarens efternamn : ");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Ange lärarens befattning : ");
                        string position = Console.ReadLine();

                        var teacherResult = AddTeacher(firstName, lastName, position);
                        dBContext.TblPersonals.Add(teacherResult);
                        dBContext.SaveChanges();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Ange ett giltligt alternativ");
                        break;
                }


            }
        }

        public static void SortStudentsAscendingFirstName(SkolaDBContext context)
        {
            Console.WriteLine("Samtliga elever i bokstavsordning efter förnamn i stigande ordning\n");
            var resultat = context.TblElevers.OrderBy(e => e.Förnamn);
            foreach (TblElever e in resultat)
            {
                Console.WriteLine(e.Förnamn + " " + e.Efternamn);

            }
        }
        public static void SortStudentsDescendingFirstName(SkolaDBContext context)
        {
            Console.WriteLine("Samtliga elever i bokstavsordning efter förnamn i fallande ordning\n");
            var resultat = context.TblElevers.OrderByDescending(e => e.Förnamn);
            foreach (TblElever e in resultat)
            {
                Console.WriteLine(e.Förnamn + " " + e.Efternamn);

            }
        }

        public static void SortStudentsAscendingLastName(SkolaDBContext context)
        {
            Console.WriteLine("Samtliga elever i bokstavsordning efter efternamn i stigande ordning\n");
            var resultat = context.TblElevers.OrderBy(e => e.Efternamn);
            foreach (TblElever e in resultat)
            {
                Console.WriteLine(e.Efternamn + " " + e.Förnamn);

            }
        }
        public static void SortStudentsDescendingLastName(SkolaDBContext context)
        {
            Console.WriteLine("Samtliga elever i bokstavsordning efter efternamn i fallande ordning\n");
            var resultat = context.TblElevers.OrderByDescending(e => e.Efternamn);
            foreach (TblElever e in resultat)
            {
                Console.WriteLine(e.Efternamn + " " + e.Förnamn);

            }
        }

        public static TblPersonal AddTeacher(string firstname, string lastname, string position)
        {
            TblPersonal personal = new TblPersonal()
            {
                Förnamn = firstname,
                Efternamn = lastname,
                Befattning = position
            };

            Console.WriteLine($"{personal.Förnamn} {personal.Efternamn} ({personal.Befattning}) lades till i databasen");
            Console.ReadKey();
            Console.Clear();

            return personal;


        }

    }

}

