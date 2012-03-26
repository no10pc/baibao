using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace forDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            makeStrsql("province.xml");
            makeStrsql("city.xml");
            makeStrsql("city_next.xml");
            Console.ReadKey();
        }
        static void makeStrsql(string filename)
        {
            string path = string.Format(@"{0}xml\{1}", AppDomain.CurrentDomain.BaseDirectory, filename);
            XMLManger xml = new XMLManger();
            List<CityTestData> list = xml.ParseCity(path).ToList();
            var queryID = from x in list
                          select x.CityId;
            FileStream file = new FileStream(@"c:\" + filename.Replace("xml", "txt"), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter wr = new StreamWriter(file);

            foreach (var id in queryID)
            {
                var query = from x in list
                            where x.CityId == id
                            select x.data;
                foreach (var q in query)
                {
                    foreach (BaseInfo b in q as BaseInfo[])
                    {
                        string strsql = string.Empty;
                        switch (filename)
                        {
                            case "province.xml":
                                strsql = string.Format(@"INSERT INTO [province] ([provincename],[provincecode],[provincepy]) VALUES ('{0}','{1}','{2}');", b.Id, b.Name, id);
                                break;
                            case "city.xml":
                                strsql = string.Format(@"INSERT INTO [city] ([cityname],[citycode],[cityparentcode]) VALUES ('{0}','{1}','{2}');", b.Name, b.Id, id);
                                break; ;
                            case "city_next.xml":
                                strsql = string.Format(@"INSERT INTO [citynext] ([cityname],[citycode],[cityparentcode]) VALUES ('{0}','{1}','{2}');", b.Name, b.Id, id);
                                break;
                        }
                        wr.WriteLine(strsql);
                        wr.WriteLine("go");
                    }
                }

            }
            wr.Close();//关闭流
            file.Close();
        }

    }
}
