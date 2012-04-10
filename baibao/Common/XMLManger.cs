
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;
namespace baibao.Common
{
    public class CityData
    {
        public CityNextData[] cityData { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class CityNextData
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class CityTestData
    {
        public string CityId { get; set; }
        public BaseInfo[] data { get; set; }
    }
    public class BaseInfo : IComparable<BaseInfo>
    {
        public string Id{get;set;}
        public string Name { get; set; }
        public int CompareTo(BaseInfo other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
    public class XMLManger
    {

        public void Parse()
        {
            XElement element2 = Enumerable.First<XElement>(XElement.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("ChinaWeather.DataCity.city.plist")).Descendants("dict"));
            string text1 = element2.Element("key").Value;
            foreach (XElement element3 in element2.Elements("dict"))
            {
                string text2 = element3.Element("key").Value;
                string text3 = element3.Element("string").Value;
            }
        }

        public CityTestData[] ParseCity(string path)
        {
            foreach (XElement element2 in XElement.Load(path).Elements("dict"))
            {
                CityTestData[] dataArray = new CityTestData[Enumerable.Count<XElement>(element2.Elements("key"))];
                int index = 0;
                foreach (XElement element3 in element2.Elements("key"))
                {
                    dataArray[index] = new CityTestData();
                    string str = element3.Value;
                    dataArray[index].CityId = str;
                    index++;

                }
                int num3 = 0;
                foreach (XElement element4 in element2.Elements("dict"))
                {
                    int num4 = Enumerable.Count<XElement>(element4.Elements("key"));
                    dataArray[num3].data = new BaseInfo[num4];
                    int num5 = 0;
                    foreach (XElement element5 in element4.Elements("key"))
                    {
                        dataArray[num3].data[num5] = new BaseInfo();
                        string str2 = element5.Value;
                        dataArray[num3].data[num5].Id = str2;
                        num5++;

                    }
                    num5 = 0;
                    foreach (string str3 in element4.Elements("string"))
                    {
                        dataArray[num3].data[num5].Name = str3;
                        num5++;

                    }
                    num3++;
                }
                return dataArray;
            }
            return null;
        }

        public CityTestData[] ParseCity(Stream stream)
        {
            foreach (XElement element2 in XElement.Load(stream).Elements("dict"))
            {
                CityTestData[] dataArray = new CityTestData[Enumerable.Count<XElement>(element2.Elements("key"))];
                int index = 0;
                foreach (XElement element3 in element2.Elements("key"))
                {
                    dataArray[index] = new CityTestData();
                    string str = element3.Value;
                    dataArray[index].CityId = str;
                    index++;

                }
                int num3 = 0;
                foreach (XElement element4 in element2.Elements("dict"))
                {
                    int num4 = Enumerable.Count<XElement>(element4.Elements("key"));
                    dataArray[num3].data = new BaseInfo[num4];
                    int num5 = 0;
                    foreach (XElement element5 in element4.Elements("key"))
                    {
                        dataArray[num3].data[num5] = new BaseInfo();
                        string str2 = element5.Value;
                        dataArray[num3].data[num5].Id = str2;
                        num5++;

                    }
                    num5 = 0;
                    foreach (string str3 in element4.Elements("string"))
                    {
                        dataArray[num3].data[num5].Name = str3;
                        num5++;

                    }
                    num3++;
                }
                return dataArray;
            }
            return null;
        }

        public CityTestData[] ParseCityTest()
        {
            Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ChinaWeather.DataCity.city.plist");
            return this.ParseCity(manifestResourceStream);
        }

        public CityTestData[] ParsePovinceTest(string path)
        {
            Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            return this.ParserPovince(manifestResourceStream);
        }

        public CityTestData[] ParsePovinceTest2(string path)
        {
            Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            return this.ParserPovince2(manifestResourceStream);
        }

        public CityTestData[] ParserPovince(Stream stream)
        {
            foreach (XElement element2 in XElement.Load(stream).Elements("dict"))
            {
                CityTestData[] dataArray = new CityTestData[Enumerable.Count<XElement>(element2.Elements("key"))];
                int index = 0;
                foreach (XElement element3 in element2.Elements("key"))
                {
                    dataArray[index] = new CityTestData();
                    string str = element3.Value;
                    dataArray[index].CityId = str;
                    index++;

                }
                int num3 = 0;
                foreach (XElement element4 in element2.Elements("dict"))
                {
                    int num4 = Enumerable.Count<XElement>(element4.Elements("key"));
                    dataArray[num3].data = new BaseInfo[num4];
                    int num5 = 0;
                    foreach (XElement element5 in element4.Elements("key"))
                    {
                        dataArray[num3].data[num5] = new BaseInfo();
                        string str2 = element5.Value;
                        dataArray[num3].data[num5].Id = str2;
                        num5++;

                    }
                    num5 = 0;
                    foreach (string str3 in element4.Elements("string"))
                    {
                        dataArray[num3].data[num5].Name = str3;
                        num5++;

                    }
                    num3++;
                }
                return dataArray;
            }
            return null;
        }

        public CityTestData[] ParserPovince2(Stream stream)
        {
            CityTestData[] dataArray = null;
            foreach (XElement element2 in XElement.Load(stream).Elements("dict"))
            {
                dataArray = new CityTestData[Enumerable.Count<XElement>(element2.Elements("key"))];
                int index = 0;
                foreach (XElement element3 in element2.Elements("key"))
                {
                    dataArray[index] = new CityTestData();
                    string str = element3.Value;
                    dataArray[index].CityId = str;
                    index++;

                }
                int num3 = 0;
                foreach (XElement element4 in element2.Elements("dict"))
                {
                    int num4 = Enumerable.Count<XElement>(element4.Elements("key"));
                    dataArray[num3].data = new BaseInfo[num4];
                    int num5 = 0;
                    foreach (XElement element5 in element4.Elements("key"))
                    {
                        dataArray[num3].data[num5] = new BaseInfo();
                        string str2 = element5.Value;
                        dataArray[num3].data[num5].Name = str2;
                        num5++;

                        num5 = 0;
                        foreach (string str3 in element4.Elements("string"))
                        {
                            dataArray[num3].data[num5].Id = str3;
                            num5++;

                        }
                        num3++;
                    }
                    return dataArray;
                }
                return null;
            }
            return dataArray;
        }
    }

}
