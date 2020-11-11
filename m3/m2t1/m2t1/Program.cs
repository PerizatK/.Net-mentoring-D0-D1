using System;
using System.IO;

namespace m2t1
{
    public struct SearchParams
    {
        public string path;
        public Boolean bSort;
        public string itype;
        public string name;
        public int length;
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                SearchParams searchParams = new SearchParams();
                GetParams(ref searchParams);

                FileSystemVisitor fsv = new FileSystemVisitor(searchParams);

                Console.WriteLine("One more time? Press Yes: Y, No: N");
                if (Console.ReadLine() == "N")
                {
                        break;
                }
            }

            Console.ReadKey();
        }

        private static void GetParams(ref SearchParams searchParams)
        {
            searchParams.bSort = false;

            Console.WriteLine("PLease enter the path");
            searchParams.path = Console.ReadLine();
            //"C:\\Users\\Perizat_Karina\\Documents\\GitHub\\.Net-mentoring-D1\\m2\\m2t1\\m2t1Tests\\bin\\Debug\\netcoreapp3.1\\test"; 

            if (Directory.Exists(searchParams.path))
            {
                Console.WriteLine("Filter list? Press Yes: Y, No: N");
                if (Console.ReadLine() == "Y")
                {
                    searchParams.bSort = true;
                    Console.WriteLine("Type: Directory(D), File(F) or All(0). \n");
                    String sType = Console.ReadLine();
                    if (sType == "F")
                    {
                        searchParams.itype = "File";
                    }
                    else if (sType == "D")
                    {
                        searchParams.itype = "Directory";
                    }
                    else
                    {
                        searchParams.itype = "0";
                    }

                    if (searchParams.itype != "Directory")
                    {
                        Console.WriteLine("Size: less then X byte (amount), All (0). \n");
                        string sLength = Console.ReadLine();
                        if ((sLength != "0") && (searchParams.itype == "File"))
                        {
                            searchParams.length = Convert.ToInt32(sLength);                        
                        }
                        else
                        {
                            searchParams.length = 0;
                        }
                    }
                    else
                    {
                        searchParams.length = 0;
                    }

                    Console.WriteLine("Name: Contains (..) or All(leave this field empty). \n");
                    searchParams.name = Console.ReadLine();
                }
                else
                {
                    searchParams.itype = "0";

                }
            }
        }
    }


}
