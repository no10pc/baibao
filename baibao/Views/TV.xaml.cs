using Microsoft.Phone.Controls;
using System.Text;
using System.Collections.Generic;
using System;
using Microsoft.Phone.Controls.Primitives;
using System.Windows.Controls;
namespace baibao.Model
{
    /// <summary>
    /// Description for TV.
    /// </summary>
    public partial class TV : PhoneApplicationPage
    {
        PopupCotainer pc;
        UserControl1 loading ;
        /// <summary>
        /// Initializes a new instance of the TV class.
        /// </summary>
        public TV()
        {
            InitializeComponent();
            List<area> areaList = new List<area>();
            areaList = new DataItem().areaList();
            this.selectorLeft.DataSource = new ListLoopingDataSource<area>() { Items = areaList, SelectedItem = areaList[0] };
            this.selectorLeft.DataSource.SelectionChanged += new EventHandler<SelectionChangedEventArgs>(DataSourceLeft_SelectionChanged);
        }
        void DataSourceLeft_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            area b = selectorLeft.DataSource.SelectedItem as area;
            List<station> stationList = new DataItem().stationList(b.id);
            this.selectorMiddle.DataSource = new ListLoopingDataSource<station>() { Items = stationList, SelectedItem = stationList[0] };
            this.selectorMiddle.DataSource.SelectionChanged += new EventHandler<SelectionChangedEventArgs>(DataSourceMiddle_SelectionChanged);
            selectorRight.Visibility = System.Windows.Visibility.Collapsed;
            // this.selectorRight.IsExpandedChanged += new System.Windows.DependencyPropertyChangedEventHandler(selectorRight_IsExpandedChanged);
            // this.selectorRight.DataSource = new ListLoopingDataSource<station>() { Items = stationList, SelectedItem = stationList[0] };
        }
        void DataSourceMiddle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            station b = selectorMiddle.DataSource.SelectedItem as station;
            List<channel> channelList = new DataItem().channelList(b.id);
            selectorRight.Visibility = System.Windows.Visibility.Visible;
            this.selectorRight.DataSource = new ListLoopingDataSource<channel>() { Items = channelList, SelectedItem = channelList[0] };
            this.selectorRight.IsExpandedChanged += new System.Windows.DependencyPropertyChangedEventHandler(selectorRight_IsExpandedChanged);
            // this.selectorRight.DataSource = new ListLoopingDataSource<station>() { Items = stationList, SelectedItem = stationList[0] };
        }

        void selectorRight_IsExpandedChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            //BaseInfo a = selectorLeft.DataSource.SelectedItem as BaseInfo;
            channel b = selectorRight.DataSource.SelectedItem as channel;
            if (!selectorRight.IsExpanded)
            {
                TvServices.ChinaTVprogramWebServiceSoapClient client = new TvServices.ChinaTVprogramWebServiceSoapClient();

                client.getTVprogramStringAsync(int.Parse(b.id), DateTime.Now.ToString("yyyy-MM-dd"), "");
                client.getTVprogramStringCompleted += new EventHandler<TvServices.getTVprogramStringCompletedEventArgs>(client_getTVprogramStringCompleted);
                selectorRight.IsExpanded = true;
                loading = new UserControl1(new List<string>() { "loading..." });
                pc = new PopupCotainer(this);
                pc.Show(loading);
            }
        }

        void client_getTVprogramStringCompleted(object sender, TvServices.getTVprogramStringCompletedEventArgs e)
        {


            char[] chars = new char[] { '@' };

            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (string s in e.Result)
            {
                list.Add(s.Split(chars, StringSplitOptions.RemoveEmptyEntries)[0] + ":" + s.Split(chars, StringSplitOptions.RemoveEmptyEntries)[1]);
                sb.Append(s.Split(chars, StringSplitOptions.RemoveEmptyEntries)[0] + ":" + s.Split(chars, StringSplitOptions.RemoveEmptyEntries)[1]);
            }
            //System.Windows.MessageBox.Show(sb.ToString());
            //pc = new PopupCotainer(this);
            loading.CloseMeAsPopup();
            pc = new PopupCotainer(this);
            loading = new UserControl1(list);
            pc.Show(loading);
        }


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