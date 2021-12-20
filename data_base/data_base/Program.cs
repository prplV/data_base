using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace practica
{

    [Serializable]
    public class Db
    {
        public string Name { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public Db()
        {

        }
        public Db(string name, string fname, string lname, int age)
        {
            Name = name;
            Fname = fname;
            Lname = lname;
            Age = age;
        }
    }
    class Program
    {
        static void Main()
        {
            Db db = new Db();
            List<Db> students = new List<Db>();
            
            char o = ' ';
            XmlSerializer form = new XmlSerializer(typeof(List<Db>));

            try
            {
                using (FileStream fl = new FileStream("1.xml", FileMode.OpenOrCreate))
                {
                    students = form.Deserialize(fl) as List<Db>;
                }
            }
            catch { 
            
            }

                while (true) {
                    try
                    {
                        Console.WriteLine($"{'\n'}Choose an operation{'\n'}************************************{'\n'}1 - to add new user{'\n'}2 - to delete existing user{'\n'}3 - to show all users{'\n'}4 - to search certain user{'\n'}0 - to exit{'\n'}************************************{'\n'}");
                        o = Convert.ToChar(Console.ReadLine());
                    }
                    catch (Exception exp) {
                        Console.WriteLine($"*******Exception!*******{'\n'}{exp}");
                    }
                    if (o == '1')
                    {
                        Console.WriteLine("Enter a name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter a fname:");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Enter a lname:");
                        string lname = Console.ReadLine();
                        Console.WriteLine("Enter an age:");
                        int age = Convert.ToInt32(Console.ReadLine());


                        Db user = new Db(name, fname, lname, age);
                        students.Add(user);
                        using (FileStream file = new FileStream("1.xml", FileMode.Truncate))
                        {
                            form.Serialize(file, students);

                        }

                    }
                    else if (o == '2')
                    {
                        
                    }
                    else if (o == '3')
                    {
                        Console.WriteLine("************************************");
                        foreach (Db user in students)
                        {
                            Console.WriteLine(user.Name + ' ' + user.Fname + ' ' + user.Lname + ' ' + user.Age);
                        }
                        Console.WriteLine("************************************");
                    }
                    else if (o == '4')
                    {
                        
                    }
                    else if (o == '0') {
                        break;
                    }
                    else {
                        Console.WriteLine("************************************");
                    }
                }
        }
    }
}

