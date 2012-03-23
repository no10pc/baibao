using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Text;
using System;
using baibao.Common;

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
    public class MobileViewModel : ViewModelBase
    {
        IsolatedStorageManager isoManager = new IsolatedStorageManager();

        public string ApplicationTitle
        {
            get
            {
                return "Mobile radar";
            }
        }

        public string PageName
        {
            get
            {
                return "手机雷达";
            }
        }

        public string Welcome
        {
            get
            {
                return "t";
            }
        }
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
        private string _mobileNumber;
        public string MoblieNumber
        {
            get { return _mobileNumber; }
            set
            {
                if (_mobileNumber == value)
                    return;
                _mobileNumber = value;
                RaisePropertyChanged("MoblieNumber");

            }
        }

        private Uri _logo;
        public Uri Logo
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


        public RelayCommand<string> MobileLocation { get; private set; }
        private object ExecuteMobileLocation(string moblieNumber)
        {
            _mobileNumber = moblieNumber;

            if (moblieNumber.Trim().Length > 11 || moblieNumber.Trim().Length < 7)
            {
                Location = "输入的手机号格式不正确.";
            }
            else if (isoManager.ExistFile(moblieNumber.Substring(0, 7)))
            {
                Location = isoManager.ReadFile(moblieNumber.Substring(0,7));
            }
            else if (Location.IndexOf(moblieNumber) <= 0)
            {
                MobileServices.MobileCodeWSSoapClient client = new MobileServices.MobileCodeWSSoapClient();
                client.getMobileCodeInfoAsync(moblieNumber, "");
                client.getMobileCodeInfoCompleted += new System.EventHandler<MobileServices.getMobileCodeInfoCompletedEventArgs>(client_getMobileCodeInfoCompleted);
            }

            logoUpdate();
           
            return null;
        }
        private string StringFormat(string result)
        {
            char[] chars = new char[] { ',', ':', ' ', '：' };
            string[] mystr = result.Split(chars, System.StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            sb.Append("号段:" + mystr[0].Substring(0,7)+"****" + "\n");
            sb.Append("省份:" + mystr[1] + "\n");
            sb.Append("地区:" + mystr[2] + "\n");
            sb.Append("运营商:" + mystr[3]);
            return sb.ToString();
        }

        void client_getMobileCodeInfoCompleted(object sender, MobileServices.getMobileCodeInfoCompletedEventArgs e)
        {
            string resault = e.Result as string;
            Location = StringFormat(resault);

            isoManager.WriteFile(_mobileNumber.Substring(0, 7), Location);
            logoUpdate();
           
        }
        void logoUpdate()
        {
            Logo = new Uri("/images/" + new Random().Next(1, 7).ToString() + ".png", UriKind.RelativeOrAbsolute);
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MobileViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                MobileLocation = new RelayCommand<string>((x) => ExecuteMobileLocation(x));
                Location = "这个手机号是你的？";
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}