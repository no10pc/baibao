using GalaSoft.MvvmLight;
using System.Windows.Threading;
using System;

namespace baibao.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class WeatherViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the WeatherViewModel class.
        /// </summary>
        /// 
        private string _cityname;

        /// <summary>
        /// Sets and gets the MyProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CityName
        {
            get
            {
                return _cityname;
            }

            set
            {
                if (_cityname == value)
                {
                    return;
                }

                _cityname = value;
                RaisePropertyChanged("CityName");
            }
        }
        private string _icons;
        public string Icons
        {
            get
            {
                return _icons;
            }

            set
            {
                if (_icons == value)
                {
                    return;
                }

                _icons = value;
                RaisePropertyChanged("Icon");
            }
        }

        public WeatherViewModel()
        {

            if (IsInDesignMode)
            {
               
            }
            _cityname = "北京";
            _icons = "/Images/weather/WeatherImgLarge/Snow/0.png";
            ImgAnmi();
        }
        public void ImgAnmi()
        {
           
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += (s, e) =>
               {

                   _cityname = string.Format("/Images/weather/WeatherImgLarge/Snow/{0}.png", new Random().Next(0, 2));
                 
               };
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(200); //重复间隔
            dispatcherTimer.Start();
            
        }

        void dispatcherTimer_Tick(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}