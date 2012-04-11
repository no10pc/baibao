using Microsoft.Phone.Controls;
using baibao.Common;
using System;
using System.Windows.Controls;
using System.Collections.Generic;
using Microsoft.Phone.Controls.Primitives;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

using System.IO;
using System.Text;

namespace baibao.Model
{
    /// <summary>
    /// Description for ZIP.
    /// </summary>
    public partial class ZIP : PhoneApplicationPage
    {
        PopupCotainer pc;
        UserControl1 loading;
        /// <summary>
        /// Initializes a new instance of the ZIP class.
        /// </summary>
        public ZIP()
        {
            InitializeComponent();

            List<BaseInfo> Province = new List<BaseInfo>();
            Province = new DataItem().ProvinceItem();
            this.selectorLeft.DataSource = new ListLoopingDataSource<BaseInfo>() { Items = Province, SelectedItem = Province[0] };

            this.selectorLeft.DataSource.SelectionChanged += new EventHandler<SelectionChangedEventArgs>(DataSource_SelectionChanged);
        }

        void DataSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BaseInfo b = selectorLeft.DataSource.SelectedItem as BaseInfo;
            List<BaseInfo> City = new DataItem().CityItem(b.Name);
            this.selectorRight.Visibility = System.Windows.Visibility.Collapsed;
            this.selectorMiddle.DataSource = new ListLoopingDataSource<BaseInfo>() { Items = City, SelectedItem = City[0] };
            this.selectorMiddle.DataSource.SelectionChanged += new EventHandler<SelectionChangedEventArgs>(DataSourceMiddle_SelectionChanged);
            //this.selectorRight.IsExpandedChanged += new System.Windows.DependencyPropertyChangedEventHandler(selectorRight_IsExpandedChanged);

        }
        void DataSourceMiddle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BaseInfo b = selectorMiddle.DataSource.SelectedItem as BaseInfo;
                List<BaseInfo> City = new DataItem().CityNextItem(b.Id);
                if (City.Count > 0)
                {
                    this.selectorRight.DataSource = new ListLoopingDataSource<BaseInfo>() { Items = City, SelectedItem = City[0] };
                   
                }
                else
                {

                    this.selectorRight.DataSource = selectorMiddle.DataSource;
                }
                this.selectorRight.Visibility = System.Windows.Visibility.Visible;
                this.selectorRight.IsExpandedChanged += new System.Windows.DependencyPropertyChangedEventHandler(selectorRight_IsExpandedChanged);

            }
            catch
            {

            }

        }


        void selectorRight_IsExpandedChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            BaseInfo a = selectorLeft.DataSource.SelectedItem as BaseInfo;
            BaseInfo b = selectorMiddle.DataSource.SelectedItem as BaseInfo;
            BaseInfo c = selectorRight.DataSource.SelectedItem as BaseInfo;
            if (!selectorRight.IsExpanded)
            {
                //System.Windows.MessageBox.Show(a.Id + "," + b.Name+","+c.Name);
                selectorRight.IsExpanded = true;
                ZipServices.ChinaZipSearchWebServiceSoapClient client = new ZipServices.ChinaZipSearchWebServiceSoapClient();
                client.getZipCodeByAddressCompleted += new EventHandler<ZipServices.getZipCodeByAddressCompletedEventArgs>(client_getZipCodeByAddressCompleted);
                client.getZipCodeByAddressAsync(a.Id, b.Name, "", "");

                loading = new UserControl1(new List<string>() { "loading..." });
                pc = new PopupCotainer(this);
                pc.Show(loading);

            }
        }

        void client_getZipCodeByAddressCompleted(object sender, ZipServices.getZipCodeByAddressCompletedEventArgs e)
        {


            List<Zipinfo> zipinfos = new List<Zipinfo>();
            List<XElement> list = e.Result.Nodes;

            string str = list[0].ToString();
            try
            {

                if (str.Contains("数据没有发现"))
                {
                    System.Windows.MessageBox.Show("数据没有发现");
                }
                else
                {
                    using (XmlReader reader = XmlReader.Create(new StringReader(str)))
                    {
                        Zipinfo zipinfo = null;
                        while (reader.Read())
                        {
                            if (reader.Name == "PROVINCE")
                            {
                                zipinfo = new Zipinfo
                                {
                                    province = reader.ReadInnerXml()
                                };
                            }
                            else
                            {
                                if (reader.Name == "CITY")
                                {
                                    zipinfo.city = reader.ReadInnerXml();
                                    continue;
                                }
                                if (reader.Name == "ADDRESS")
                                {
                                    zipinfo.address = reader.ReadInnerXml();
                                    continue;
                                }
                                if (reader.Name == "ZIP")
                                {
                                    zipinfo.zip = reader.ReadInnerXml();
                                    zipinfos.Add(zipinfo);
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception exception)
            {
                if (str == null)
                {
                    System.Windows.MessageBox.Show("网络连接失败，请稍后再试！");
                }
                else
                {
                    System.Windows.MessageBox.Show(exception.Message);
                }
            }

            zipinfos.TrimExcess();
            List<string> citylist = new List<string>();
            foreach (Zipinfo z in zipinfos)
            {
                citylist.Add(z.zip + ":" + z.address);
            }

            loading.CloseMeAsPopup();
            loading = new UserControl1(citylist);
            pc = new PopupCotainer(this);
            pc.Show(loading);
        }

        //This XML file does not appear to have any style information associated with it. The document tree is shown below.
        //<DataSet xmlns="http://WebXml.com.cn/">
        //<xs:schema xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" id="NewDataSet">
        //<xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">
        //<xs:complexType>
        //<xs:choice minOccurs="0" maxOccurs="unbounded">
        //<xs:element name="ZipInfo">
        //<xs:complexType>
        //<xs:sequence>
        //<xs:element name="PROVINCE" type="xs:string" minOccurs="0"/>
        //<xs:element name="CITY" type="xs:string" minOccurs="0"/>
        //<xs:element name="ADDRESS" type="xs:string" minOccurs="0"/>
        //<xs:element name="ZIP" type="xs:string" minOccurs="0"/>
        //</xs:sequence>
        //</xs:complexType>
        //</xs:element>
        //</xs:choice>
        //</xs:complexType>
        //</xs:element>
        //</xs:schema>
        //<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
        //<NewDataSet xmlns="">
        //<ZipInfo diffgr:id="ZipInfo1" msdata:rowOrder="0">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>城子河及所属各街道</ADDRESS>
        //<ZIP>158100</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo2" msdata:rowOrder="1">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>滴道区及所属各街道</ADDRESS>
        //<ZIP>158100</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo3" msdata:rowOrder="2">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>恒山区及所属各街道</ADDRESS>
        //<ZIP>158100</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo4" msdata:rowOrder="3">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>鸡冠区及所属各街道</ADDRESS>
        //<ZIP>158100</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo5" msdata:rowOrder="4">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>鸡冠区西郊乡</ADDRESS>
        //<ZIP>158100</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo6" msdata:rowOrder="5">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>梨树区及所属各街道</ADDRESS>
        //<ZIP>158100</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo7" msdata:rowOrder="6">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>安村付业队、义安村、安</ADDRESS>
        //<ZIP>158130</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo8" msdata:rowOrder="7">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>长胜村、薛家村、义安村</ADDRESS>
        //<ZIP>158130</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo9" msdata:rowOrder="8">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>村</ADDRESS>
        //<ZIP>158130</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo10" msdata:rowOrder="9">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>滴道河乡</ADDRESS>
        //<ZIP>158130</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo11" msdata:rowOrder="10">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>红旗乡所属义安村三队、义</ADDRESS>
        //<ZIP>158130</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo12" msdata:rowOrder="11">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>乐村、红旗村、张鲜村、</ADDRESS>
        //<ZIP>158130</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo13" msdata:rowOrder="12">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>民主乡</ADDRESS>
        //<ZIP>158130</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo14" msdata:rowOrder="13">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>四队、小恒山村及其余各</ADDRESS>
        //<ZIP>158130</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo15" msdata:rowOrder="14">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>村、南甸子村、全铁村</ADDRESS>
        //<ZIP>158150</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo16" msdata:rowOrder="15">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>滴道河乡所属王家村、河东</ADDRESS>
        //<ZIP>158150</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo17" msdata:rowOrder="16">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>鸡西市梨树乡</ADDRESS>
        //<ZIP>158160</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo18" msdata:rowOrder="17">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>长青乡及所属新华村、新城</ADDRESS>
        //<ZIP>158170</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo19" msdata:rowOrder="18">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>村、西城村、城西畜牧场</ADDRESS>
        //<ZIP>158170</ZIP>
        //</ZipInfo>
        //<ZipInfo diffgr:id="ZipInfo20" msdata:rowOrder="19">
        //<PROVINCE>黑龙江</PROVINCE>
        //<CITY>鸡西市</CITY>
        //<ADDRESS>及所属其余各村</ADDRESS>
        //<ZIP>158170</ZIP>
        //</ZipInfo>
        //</NewDataSet>
        //</diffgr:diffgram>
        //</DataSet>


        public abstract class LoopingDataSourceBase : ILoopingSelectorDataSource
        {
            private object selectedItem;

            #region ILoopingSelectorDataSource Members

            public abstract object GetNext(object relativeTo);

            public abstract object GetPrevious(object relativeTo);

            public object SelectedItem
            {
                get
                {
                    return this.selectedItem;
                }
                set
                {
                    // this will use the Equals method if it is overridden for the data source item class
                    if (!object.Equals(this.selectedItem, value))
                    {
                        // save the previously selected item so that we can use it 
                        // to construct the event arguments for the SelectionChanged event
                        object previousSelectedItem = this.selectedItem;
                        this.selectedItem = value;
                        // fire the SelectionChanged event
                        this.OnSelectionChanged(previousSelectedItem, this.selectedItem);
                    }
                }
            }

            public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

            protected virtual void OnSelectionChanged(object oldSelectedItem, object newSelectedItem)
            {
                EventHandler<SelectionChangedEventArgs> handler = this.SelectionChanged;
                if (handler != null)
                {
                    handler(this, new SelectionChangedEventArgs(new object[] { oldSelectedItem }, new object[] { newSelectedItem }));
                }
            }

            #endregion
        }

        public class ListLoopingDataSource<T> : LoopingDataSourceBase
        {
            private LinkedList<T> linkedList;
            private List<LinkedListNode<T>> sortedList;
            private IComparer<T> comparer;
            private NodeComparer nodeComparer;

            public ListLoopingDataSource()
            {
            }

            public IEnumerable<T> Items
            {
                get
                {
                    return this.linkedList;
                }
                set
                {
                    this.SetItemCollection(value);
                }
            }

            private void SetItemCollection(IEnumerable<T> collection)
            {
                this.linkedList = new LinkedList<T>(collection);

                this.sortedList = new List<LinkedListNode<T>>(this.linkedList.Count);
                // initialize the linked list with items from the collections
                LinkedListNode<T> currentNode = this.linkedList.First;
                while (currentNode != null)
                {
                    this.sortedList.Add(currentNode);
                    currentNode = currentNode.Next;
                }

                IComparer<T> comparer = this.comparer;
                if (comparer == null)
                {
                    // if no comparer is set use the default one if available
                    if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                    {
                        comparer = Comparer<T>.Default;
                    }
                    else
                    {
                        throw new InvalidOperationException("There is no default comparer for this type of item. You must set one.");
                    }
                }

                this.nodeComparer = new NodeComparer(comparer);
                this.sortedList.Sort(this.nodeComparer);
            }

            public IComparer<T> Comparer
            {
                get
                {
                    return this.comparer;
                }
                set
                {
                    this.comparer = value;
                }
            }

            public override object GetNext(object relativeTo)
            {
                // find the index of the node using binary search in the sorted list
                int index = this.sortedList.BinarySearch(new LinkedListNode<T>((T)relativeTo), this.nodeComparer);
                if (index < 0)
                {
                    return default(T);
                }

                // get the actual node from the linked list using the index
                LinkedListNode<T> node = this.sortedList[index].Next;
                if (node == null)
                {
                    // if there is no next node get the first one
                    node = this.linkedList.First;
                }
                return node.Value;
            }

            public override object GetPrevious(object relativeTo)
            {
                int index = this.sortedList.BinarySearch(new LinkedListNode<T>((T)relativeTo), this.nodeComparer);
                if (index < 0)
                {
                    return default(T);
                }
                LinkedListNode<T> node = this.sortedList[index].Previous;
                if (node == null)
                {
                    // if there is no previous node get the last one
                    node = this.linkedList.Last;
                }
                return node.Value;
            }

            private class NodeComparer : IComparer<LinkedListNode<T>>
            {
                private IComparer<T> comparer;

                public NodeComparer(IComparer<T> comparer)
                {
                    this.comparer = comparer;
                }

                #region IComparer<LinkedListNode<T>> Members

                public int Compare(LinkedListNode<T> x, LinkedListNode<T> y)
                {
                    return this.comparer.Compare(x.Value, y.Value);
                }

                #endregion
            }

        }
    }
}