namespace ChinaWeather.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    public class SampleData
    {
        public SampleData()
        {
            this.ContentText = new string[10];
            for (int i = 0; i < 10; i++)
            {
                this.ContentText[i] = "some text";
            }
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            this.SomeItems = list;
        }

        [XmlElement]
        public string[] ContentText { get; set; }

        [XmlElement]
        public List<int> SomeItems { get; set; }
    }
}

