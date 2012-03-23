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
    public class QQViewModel : ViewModelBase
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
        private string _qqNumber;
        public string QQNumber
        {
            get { return _qqNumber; }
            set
            {
                if (_qqNumber == value)
                    return;
                _qqNumber = value;
                RaisePropertyChanged("QQNumber");

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


        public RelayCommand<string> QQLocation { get; private set; }
        private object ExecuteQQLocation(string qqNumber)
        {
            _qqNumber = qqNumber;

            if (qqNumber.Trim().Length > 13 || qqNumber.Trim().Length < 3)
            {
                Location = "输入的QQ号格式不正确.";
            }
            else 
            {
                QQServices.qqOnlineWebServiceSoapClient client = new QQServices.qqOnlineWebServiceSoapClient();
                
                client.qqCheckOnlineAsync(qqNumber, "");
                client.qqCheckOnlineCompleted += new EventHandler<QQServices.qqCheckOnlineCompletedEventArgs>(client_qqCheckOnlineCompleted);
            }

           
           
            return null;
        }

        void client_qqCheckOnlineCompleted(object sender, QQServices.qqCheckOnlineCompletedEventArgs e)
        {
            string resault = e.Result as string;
            //：String，Y = 在线；N = 离线；E = QQ号码错误；A = 商业用户验证失败；V = 免费用户超过数量
            switch (resault.ToUpper())
            {
                case "Y":
                    Location = "在线";
                    break;
                case "N":
                    Location = "离线或隐身";
                    break;
                case "E":
                    Location = "不存在的QQ号";
                    break;
                case "A":
                    Location = "您执行了商业用户的功能";
                    break;
                case "V":
                    Location = "你超过了查询限制。";
                    break; 
                default:
                    Location = "腾讯服务器被你搞崩溃了。";
                    break;
            }
            Location += "\n" +"最后查询时间\n"+ DateTime.Now.ToString();
            logoUpdate(resault.ToUpper());
        }
       
        void logoUpdate(string name)
        {
            Logo = "/images/" + name + ".png";
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public QQViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                QQLocation = new RelayCommand<string>((x) => ExecuteQQLocation(x));
                Location = "这个QQ号是本程序作者的";
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}