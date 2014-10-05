using GalaSoft.MvvmLight;
using AuThink.Desktop.Model;

namespace AuThink.Desktop.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string a { get; set; }

        public MainViewModel()
        {
            var b = new Class1();

            a = b.Panj;
        }
    }
}