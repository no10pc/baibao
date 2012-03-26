using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
namespace baibao.ViewModel
{

    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {


         
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<QQViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MobileViewModel>();
            SimpleIoc.Default.Register<WeatherViewModel>();
            SimpleIoc.Default.Register<IPViewModel>();
        }

        public QQViewModel QQ
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QQViewModel>();
            }
        }
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public MobileViewModel Mobile
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MobileViewModel>();
            }
        }

        public IPViewModel IP
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IPViewModel>();
            }
        }

        public WeatherViewModel Weather
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WeatherViewModel>();
            }
        }

        public static void Cleanup()
        {
           
        }
    }
}