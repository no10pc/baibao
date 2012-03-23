using Microsoft.Phone.Controls;
using baibal.Common;

namespace baibao.Model
{
    /// <summary>
    /// Description for IP.
    /// </summary>
    public partial class IP : PhoneApplicationPage
    {
        /// <summary>
        /// Initializes a new instance of the IP class.
        /// </summary>
        public IP()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            MyIPAddress finder = new MyIPAddress();
            finder.Find((address) =>
            {
                Dispatcher.BeginInvoke(() => { txtIP.Text = address == null ? "Unknown" : address.ToString(); });
            });
        }
      

    }
}