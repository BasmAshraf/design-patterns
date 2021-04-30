using MovieLibrary.Data;
using System.Windows;

namespace MovieLibrary.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Initer.Init(@"Server=.;Database=SpecPattern;Trusted_Connection=true;");
        }
    }
}
