using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stream_Classwork
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\MyTest.txt";
            Stream writingStream = new FileStream(path, FileMode.Create);
            try
            {
                Console.WriteLine("Please enter 3 strings: ");
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();
                string str3 = Console.ReadLine();

                byte[] bytes1 = Encoding.ASCII.GetBytes(str1);
                byte[] bytes2 = Encoding.ASCII.GetBytes(str2);
                byte[] bytes3 = Encoding.ASCII.GetBytes(str3);

                if (writingStream.CanWrite == true)
                {
                    writingStream.Write(bytes1, 0, bytes1.Length);
                    writingStream.Write(bytes2, 0, bytes2.Length);
                    writingStream.Write(bytes3, 0, bytes3.Length);

                    writingStream.Close();

                    if (!File.Exists(path))
                    {
                        Console.WriteLine("File " + path + "does not exist!");
                        return;
                    }

                    Stream readingStream = new FileStream(path, FileMode.Open);

                    try
                    {
                        Console.WriteLine("Enter the number of characters you want to skip: ");
                        int num = int.Parse(Console.ReadLine());
                        readingStream.Position = num;

                        byte[] temp = new byte[10];
                        int len = 0;

                        while ((len = readingStream.Read(temp, 0, temp.Length)) > 0)
                        {
                            string s = Encoding.UTF8.GetString(temp, 0, len);
                            Console.WriteLine(s);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        readingStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                writingStream.Close();
            }
        }
    }
}
