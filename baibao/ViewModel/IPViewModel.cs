using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using baibao.Common;
using baibal.Common;
using System.Windows.Threading;

namespace baibao.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class IPViewModel : ViewModelBase
    {
        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location == value)
                    return;
                _location = value;
                RaisePropertyChanged("Location");

            }
        }
        private string _ipNumber;
        public string IPNumber
        {
            get { return _ipNumber; }
            set
            {
                if (_ipNumber == value)
                    return;
                _ipNumber = value;
                RaisePropertyChanged("IPNumber");

            }
        }

        private string _logo;
        public string Logo
        {
            get { return _logo; }
            set
            {
                if (_logo == value)
                    return;
                _logo = value;
                RaisePropertyChanged("Logo");

            }
        }


        public RelayCommand<string> IPLocation { get; private set; }
        public RelayCommand<string> txtClear { get; private set; }
        private object ExecutetxtClear(string x)
        {
            _ipNumber = x;
            return null;
        }

        private object ExecuteIPLocation(string ipNumber)
        {
            _ipNumber = ipNumber;

            ipNumber = ipNumber.Replace("。", ".");
            if (ipNumber.Count(x => x == '.') != 3)
            {
                Location = "输入的IP格式不正确.";
            }
            else
            {
                IPServices.IpAddressSearchWebServiceSoapClient client = new IPServices.IpAddressSearchWebServiceSoapClient();
                client.getCountryCityByIpAsync(ipNumber, "");
                client.getCountryCityByIpCompleted += new EventHandler<IPServices.getCountryCityByIpCompletedEventArgs>(client_getCountryCityByIpCompleted);
            }
            return null;
        }

        void client_getCountryCityByIpCompleted(object sender, IPServices.getCountryCityByIpCompletedEventArgs e)
        {
            List<string> resault = e.Result.ToList();

            Location ="IP地址:"+resault.First()+"\n";
            Location += resault.Last();
            logoUpdate();
        }



        void logoUpdate()
        {
            Logo = "/images/" + new Random().Next(1, 8).ToString() + ".png";
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public IPViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                IPLocation = new RelayCommand<string>((x) => ExecuteIPLocation(x));
                txtClear = new RelayCommand<string>((x) => ExecutetxtClear(""));


                Location = "本机IP地址";
            }
        }


        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}