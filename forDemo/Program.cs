using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Threading;

namespace forDemo
{
    class Program
    {
        protected string areaid = string.Empty;
        static void Main(string[] args)
        {

            //makeStrsql("province.xml");
            //makeStrsql("city.xml");
            //makeStrsql("city_next.xml");

            //string[] area = client.getAreaString();
            //loadstationXML();
            loadChanelXML();
            //area.ToString();
            Console.WriteLine("生成完毕");
            Console.ReadKey();
            
        }
        static void initXML(string filename, string node)
        {
            XDocument xml = XDocument.Load(filename);

            // 创建需要新增的XElement对象
            var persons = from p in xml.Root.Elements(node)
                          select p;

            // 删除指定的XElement对象
            persons.Remove();

            // 保存xml
            xml.Save(filename);
        }
        static void loadAreaXML()
        {
            myTV.ChinaTVprogramWebService area = new myTV.ChinaTVprogramWebService();
            area.getAreaStringAsync();
            area.getAreaStringCompleted += new myTV.getAreaStringCompletedEventHandler(client_getAreaStringCompleted);
        }
        static void client_getAreaStringCompleted(object sender, myTV.getAreaStringCompletedEventArgs e)
        {
            var list = e.Result.ToList();

            var query = from p in XDocument.Load(@"c:\area.xml").Root.Elements("city")
                        select p;
            if (query.Count() > 0)
            {
                initXML(@"c:\area.xml", "city");
            }

            XDocument xml = XDocument.Load(@"c:\area.xml");

            foreach (string str in list)
            {
                //wr.WriteLine(str);
                XElement area = new XElement("city", new XElement("id", str.Split('@')[0]), new XElement("name", str.Split('@')[1]));
                xml.Root.Add(area);
            }
            xml.Save(@"c:\area.xml");
        }
        static void loadstationXML()
        {
            var query = from p in XDocument.Load(@"c:\area.xml").Root.Elements("city")
                        select p;


            XDocument xml = XDocument.Load(@"c:\station.xml");

            myTV.ChinaTVprogramWebService area = new myTV.ChinaTVprogramWebService();
            


            foreach (var q in query)
            {
                //wr.WriteLine(str);
                string[] stations = area.getTVstationString(int.Parse(q.Element("id").Value));
                foreach (string str in stations)
                {
                    XElement station = new XElement("station", new XElement("area", q.Element("id").Value), new XElement("id", str.Split('@')[0]), new XElement("name", str.Split('@')[1]));
                    xml.Root.Add(station);
                }
            }
            xml.Save(@"c:\station.xml");
        }

        static void loadChanelXML()
        {
            var query = from p in XDocument.Load(@"c:\station.xml").Root.Elements("station")
                        select p;
            myTV.ChinaTVprogramWebService area = new myTV.ChinaTVprogramWebService();



            foreach (var q in query)
            {
                //wr.WriteLine(str);
                string[] stations = area.getTVchannelString(int.Parse(q.Element("id").Value));
                XDocument xml = XDocument.Load(@"c:\channel.xml");
                foreach (string str in stations)
                {
                    XElement station = new XElement("channel", new XElement("station", q.Element("id").Value), new XElement("id", str.Split('@')[0]), new XElement("name", str.Split('@')[1]));
                    xml.Root.Add(station);
                }
                makelog(q.Element("id").Value);
                xml.Save(@"c:\channel.xml");
            }
           
        }


        static void client_getTVstationStringCompleted(object sender, myTV.getTVstationStringCompletedEventArgs e)
        {
            var list = e.Result.ToList();


        }
        void makeSqlDelete()
        {
            string strsql = string.Empty;
            FileStream file = new FileStream(@"c:\mysql.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter wr = new StreamWriter(file);
            //DELETE FROM dnt_posts2  WHERE   (fid = 207) AND (pid > 295821) AND (pid < 480000)
            for (long i = 480000; i <= 2006097; i += 20000)
            {
                strsql = string.Format(" DELETE FROM dnt_posts2  WHERE   (fid = 207) AND (pid > 295821) AND (pid < {0}) \n\r go \n\r", i.ToString());
                wr.WriteLine(strsql);
            }
            wr.Close();//关闭流
            file.Close();
        }
        static void makelog(string str)
        {
            FileStream file = new FileStream(@"c:\mylog.txt", FileMode.Append, FileAccess.Write);
            StreamWriter wr = new StreamWriter(file);
            wr.WriteLine(str);
            wr.Close();//关闭流
            file.Close();
        }
        void makeStrsql(string filename)
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
