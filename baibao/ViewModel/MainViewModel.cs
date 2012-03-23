using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using baibao.Model;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using baibao.Common;
using GalaSoft.MvvmLight.Messaging;


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
    public class MainViewModel : ViewModelBase
    {
      
        //--------------------------------
        private baibaoContext _dataContext =new baibaoContext(baibaoContext.ConnectionString);

        private ObservableCollection<Menulist> _menulists;
        public ObservableCollection<Menulist> MenuLists
        {
            get
            {
                return _menulists;
            }
            set
            {
                if (_menulists == value) return;
                _menulists = value;
                RaisePropertyChanged("MenuLists");
            }
        }



        public string ApplicationTitle
        {
            get
            {
                return "My tools";
            }
        }

        public string PageName
        {
            get
            {
                return "百宝箱";
            }
        }

        public RelayCommand<Menulist> DetailsPageCommand
        {
            get;
            private set;
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private object ExecuteDetailsPageCommand(Menulist msg)
        {
            var transferMessage = new TransferMessage() { msg_menuitem = msg };
            Messenger.Default.Send<TransferMessage>(transferMessage);
            return null;
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.MenuLists = new ObservableCollection<Menulist>();
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                if (_dataContext.CreateIfNotExists())
                {
                    //初始化数据
                    //添加分组
                    _dataContext.Menulists.InsertOnSubmit(new Menulist { Name = "汇率转换", Desc = "外汇-人民币即时报价.本服务仅作为用户获取信息之目的,并不构成投资建议.", Icons = "exchange.png", Sortid = 1, Uri = "exchange.xaml" });
                    _dataContext.Menulists.InsertOnSubmit(new Menulist { Name = "IP查询", Desc = "IP地址搜索服务包含中国和国外已知的IP地址数据，是目前最完整的IP地址数据.", Icons = "ip.png", Sortid = 1, Uri = "ip.xaml" });
                    _dataContext.Menulists.InsertOnSubmit(new Menulist { Name = "地图服务", Desc = "BING提供全球地图服务,本地图仅作为出行参考，如有疑问请咨询当地地图服务商", Icons = "map.png", Sortid = 1, Uri = "map.xaml" });
                    _dataContext.Menulists.InsertOnSubmit(new Menulist { Name = "手机查询", Desc = "国内手机号码归属地查询WEB服务,提供最新的国内手机号码段归属地数据，每月更新.", Icons = "mobile.png", Sortid = 1, Uri = "mobile.xaml" });
                    _dataContext.Menulists.InsertOnSubmit(new Menulist { Name = "QQ状态", Desc = "腾讯QQ在线状态查询.本程序不为本页面提供信息的错误、残缺、延迟或因依靠此信息所采取的任何行动负责", Icons = "qq.png", Sortid = 1, Uri = "qq.xaml" });
                    _dataContext.Menulists.InsertOnSubmit(new Menulist { Name = "火车票", Desc = "本火车时刻表查询服务提供的列车时刻表数据仅供参考，如有异议以当地铁路部门颁布为准", Icons = "train.png", Sortid = 1, Uri = "train.xaml" });
                    _dataContext.Menulists.InsertOnSubmit(new Menulist { Name = "电视节目", Desc = "中国电视节目预告,数据准确可靠提供全国近800个电视拼道一个星期以上的节目预告数据.", Icons = "tv.png", Sortid = 1, Uri = "tv.xaml" });
                    _dataContext.Menulists.InsertOnSubmit(new Menulist { Name = "天气查询", Desc = "2400多个城市天气预报Web服务，包含2300个以上中国城市和100个以上国外城市天气预报数据.", Icons = "weather.png", Sortid = 1, Uri = "weather.xaml" });
                    _dataContext.Menulists.InsertOnSubmit(new Menulist { Name = "邮编区号", Desc = "中国邮政编码搜索服务包含中国全部邮政编码共计187285条记录,是目前最完整的邮政编码数据.", Icons = "zip.png", Sortid = 1, Uri = "zip.xaml" });
                    _dataContext.SubmitChanges();
                   
                }
                //加载数据
                List<Menulist> list = _dataContext.Menulists.ToList();
                list.ForEach(x => x.Icons = "images/" + x.Icons);
                this.MenuLists = new ObservableCollection<Menulist>(list);
                DetailsPageCommand = new RelayCommand<Menulist>((x) => ExecuteDetailsPageCommand(x));
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}