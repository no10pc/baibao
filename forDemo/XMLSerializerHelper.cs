namespace ChinaWeather.Xml
{
    using ChinaWeather;
    using ChinaWeather.BaseClass;
    using ChinaWeather.DataClass;
    using ChinaWeather.File;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;

    public class XMLSerializerHelper
    {
        public static object Deserialize(Stream streamObject, Type serializedObjectType)
        {
            if ((serializedObjectType == null) || (streamObject == null))
            {
                return null;
            }
            XmlSerializer serializer = new XmlSerializer(serializedObjectType);
            return serializer.Deserialize(streamObject);
        }

        public static MemoryStream ObjGetMs(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Serialize(stream, obj);
                return stream;
            }
        }

        public static string ObjGetString(object obj)
        {
            return DataChange.MadeMsToString(ObjGetMs(obj));
        }

        public static object ReadObj(string fileName, Type type)
        {
            return StringGetObj(YYYFile.ReadFile(fileName), type);
        }

        public static bool SaveObj(object obj, string fileName)
        {
            try
            {
                string content = ObjGetString(obj);
                YYYFile.WriteFile(fileName, content);
                YYYDebug.Write("SaveObj", "保存" + fileName);
                return true;
            }
            catch (Exception exception)
            {
                YYYDebug.Write("SaveObj异常", exception.get_Message());
                return false;
            }
        }

        public static void Serialize(Stream streamObject, object objForSerialization)
        {
            if ((objForSerialization != null) && (streamObject != null))
            {
                new XmlSerializer(objForSerialization.GetType()).Serialize(streamObject, objForSerialization);
            }
        }

        public static object StringGetObj(string str, Type type)
        {
            try
            {
                if ((str != null) && (str != ""))
                {
                    Stream streamObject = DataChange.StringToStream(str);
                    streamObject.set_Position(0L);
                    return Deserialize(streamObject, type);
                }
                return null;
            }
            catch (Exception exception)
            {
                YYYDebug.Write("StringGetObj", exception.get_Message());
                return null;
            }
        }

        public static void TestXMLSerialization(ChinaWeatherCityData m_da)
        {
            MemoryStream streamObject = new MemoryStream();
            Serialize(streamObject, m_da);
            streamObject.set_Position(0L);
            Assembly.GetExecutingAssembly().GetManifestResourceStream("ChinaWeather.DataCity.ChinaWeatherCityData.xml");
            ChinaWeatherCityData data1 = Deserialize(streamObject, typeof(ChinaWeatherCityData));
        }

        public static void TestXMLSerialization2(List<CityWeatherData> m_da)
        {
            try
            {
                MemoryStream streamObject = new MemoryStream();
                Serialize(streamObject, m_da);
                string content = DataChange.MadeMsToString(streamObject);
                YYYFile.WriteFile(ProFilePath.WeatherData, content);
                MemoryStream stream2 = DataChange.StringToStream(YYYFile.ReadFile(ProFilePath.WeatherData));
                stream2.set_Position(0L);
                List<CityWeatherData> list1 = Deserialize(stream2, typeof(List<CityWeatherData>));
            }
            catch (Exception exception)
            {
                YYYDebug.Write("TestXMLSerialization2", exception.get_Message());
            }
        }

        public class TestData
        {
            public CityTestData[] da;
        }
    }
}

