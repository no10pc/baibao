using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using baibao.Common;
using System.IO;
using System.Windows;
using System.Xml.Linq;
namespace baibao.Model
{
    public class area : IComparable<area>
    {
        public string id { get; set; }
        public string name { get; set; }
        public int CompareTo(area other)
        {
            return this.id.CompareTo(other.id);
        }
    }
    public class station : IComparable<station>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string areaid { get; set; }
        public int CompareTo(station other)
        {
            return this.id.CompareTo(other.id);
        }
    }
    public class channel : IComparable<channel>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string stationid { get; set; }
        public int CompareTo(channel other)
        {
            return this.id.CompareTo(other.id);
        }
    }

    public class DataItem
    {
        public DataItem(string title)
        {
            Title = title;
        }

        public DataItem()
        {
        }

        /// <summary>
        /// 获取电视节目地区列表
        /// </summary>
        /// <returns></returns>
        public List<area> areaList()
        {
            List<area> list = new List<area>();

            System.Windows.Resources.StreamResourceInfo input = Application.GetResourceStream(new Uri("/baibao;component/DataSource/area.xml", UriKind.Relative));
            foreach (XElement element in XElement.Load(input.Stream).Elements("city"))
            {
                list.Add(new area() { id = element.Element("id").Value, name = element.Element("name").Value });
            }
            return list;
        }
        public List<station> stationList(string areaid)
        {
            List<station> list = new List<station>();

            System.Windows.Resources.StreamResourceInfo input = Application.GetResourceStream(new Uri("/baibao;component/DataSource/station.xml", UriKind.Relative));


            foreach (XElement element in XElement.Load(input.Stream).Elements("station"))
            {
                list.Add(new station() { id = element.Element("id").Value, name = element.Element("name").Value,areaid=element.Element("area").Value });
            }
            var query = from q in list
                        where q.areaid == areaid
                        select q;
            return query.ToList<station>();
        }

        public List<channel> channelList(string stationid)
        {
            List<channel> list = new List<channel>();

            System.Windows.Resources.StreamResourceInfo input = Application.GetResourceStream(new Uri("/baibao;component/DataSource/channel.xml", UriKind.Relative));


            foreach (XElement element in XElement.Load(input.Stream).Elements("channel"))
            {
                list.Add(new channel() { id = element.Element("id").Value, name = element.Element("name").Value, stationid = element.Element("station").Value });
            }
            var query = from q in list
                        where q.stationid == stationid
                        select q;
            return query.ToList<channel>();
        }




        public List<BaseInfo> ProvinceItem()
        {
            List<CityTestData> list = new List<CityTestData>();
            XMLManger xml = new XMLManger();
            System.Windows.Resources.StreamResourceInfo input = Application.GetResourceStream(new Uri("/baibao;component/DataSource/province.xml", UriKind.Relative));
            list = xml.ParserPovince(input.Stream).ToList();
            var data1 = from x in list
                        select x.data;

            List<BaseInfo[]> data2 = data1.ToList();
            List<BaseInfo> info = new List<BaseInfo>();
            foreach (BaseInfo[] data in data2)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    info.Add(data[i]);
                }
            }
            return info;
        }
        public List<BaseInfo> CityItem(string provincecode)
        {
            List<CityTestData> list = new List<CityTestData>();
            List<BaseInfo> info = new List<BaseInfo>();
            XMLManger xml = new XMLManger();


            System.Windows.Resources.StreamResourceInfo input = Application.GetResourceStream(new Uri("/baibao;component/DataSource/city.xml", UriKind.Relative));

            list = xml.ParseCity(input.Stream).ToList();

            if (provincecode != "")
            {

                var data1 = from x in list
                            where x.CityId == provincecode
                            select x.data;

                List<BaseInfo[]> data2 = data1.ToList();

                foreach (BaseInfo[] data in data2)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        info.Add(data[i]);
                    }
                }
            }
            return info;
        }
        public List<BaseInfo> CityNextItem(string citycode)
        {
            List<CityTestData> list = new List<CityTestData>();
            List<BaseInfo> info = new List<BaseInfo>();
            XMLManger xml = new XMLManger();

            System.Windows.Resources.StreamResourceInfo input = Application.GetResourceStream(new Uri("/baibao;component/DataSource/city_next.xml", UriKind.Relative));

            list = xml.ParseCity(input.Stream).ToList();

            if (citycode != "")
            {

                var data1 = from x in list
                            where x.CityId == citycode
                            select x.data;

                List<BaseInfo[]> data2 = data1.ToList();

                foreach (BaseInfo[] data in data2)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        info.Add(data[i]);
                    }
                }
            }
            return info;
        }

        public string Title
        {
            get;
            private set;
        }


    }

}
