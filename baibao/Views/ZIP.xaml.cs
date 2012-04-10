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
            BaseInfo b = selectorMiddle.DataSource.SelectedItem as BaseInfo;
            List<BaseInfo> City = new DataItem().CityNextItem(b.Id);
            try
            {
                this.selectorRight.DataSource = new ListLoopingDataSource<BaseInfo>() { Items = City, SelectedItem = City[0] };
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
                client.getZipCodeByAddressAsync(a.Id, b.Name, c.Name, "");

                loading = new UserControl1(new List<string>() { "loading..." });
                pc = new PopupCotainer(this);
                pc.Show(loading);

            }
        }

        void client_getZipCodeByAddressCompleted(object sender, ZipServices.getZipCodeByAddressCompletedEventArgs e)
        {
            ZipServices.ArrayOfXElement element = e.Result;

            var results = from item in element.Nodes[0].Descendants("getZipCodeByAddressResult")
                          select item;
            int count = results.Count();
            loading.CloseMeAsPopup();
            loading = new UserControl1(new List<string>() { "e.Result" });
            pc = new PopupCotainer(this);
            pc.Show(loading);
        }


        //<getZipCodeByAddressResult xmlns="http://WebXml.com.cn/">
        //  <xs:schema id="ZipCodeDataSet" targetNamespace="http://tempuri.org/ZipCodeDataSet.xsd" xmlns:mstns="http://tempuri.org/ZipCodeDataSet.xsd" xmlns="http://tempuri.org/ZipCodeDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified">
        //    <xs:element name="ZipCodeDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">
        //      <xs:complexType>
        //        <xs:choice minOccurs="0" maxOccurs="unbounded">
        //          <xs:element name="ZipInfo">
        //            <xs:complexType>
        //              <xs:sequence>
        //                <xs:element name="PROVINCE" type="xs:string" minOccurs="0" />
        //                <xs:element name="CITY" type="xs:string" minOccurs="0" />
        //                <xs:element name="ADDRESS" type="xs:string" minOccurs="0" />
        //                <xs:element name="ZIP" type="xs:string" minOccurs="0" />
        //              </xs:sequence>
        //            </xs:complexType>
        //          </xs:element>
        //        </xs:choice>
        //      </xs:complexType>
        //    </xs:element>
        //  </xs:schema>
        //  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
        //    <ZipCodeDataSet xmlns="http://tempuri.org/ZipCodeDataSet.xsd">
        //      <ZipInfo diffgr:id="ZipInfo1" msdata:rowOrder="0" diffgr:hasChanges="inserted">
        //        <PROVINCE>提示信息</PROVINCE>
        //        <CITY>数据没有发现</CITY>
        //        <ADDRESS>http://www.webxml.com.cn/</ADDRESS>
        //        <ZIP />
        //      </ZipInfo>
        //    </ZipCodeDataSet>
        //  </diffgr:diffgram>
        //</getZipCodeByAddressResult>







        // option 2: implement and use IComparer<T>




        // abstract the reusable code in a base class
        // this will allow us to concentrate on the specifics when implementing deriving looping data source classes
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