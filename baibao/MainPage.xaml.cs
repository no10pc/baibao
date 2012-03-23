using Microsoft.Phone.Controls;
using GalaSoft.MvvmLight.Messaging;
using baibao.Common;
using baibao.Model;

namespace baibao
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Messenger.Default.Register<TransferMessage>(this, (x) => ReceiveMessage(x));

        }

        private object ReceiveMessage(TransferMessage x)
        {
            string url = string.Format("/Views/{0}", x.msg_menuitem.Uri);
            NavigationService.Navigate(new System.Uri(url, System.UriKind.Relative));
            return null;
        }

      
    }
}
