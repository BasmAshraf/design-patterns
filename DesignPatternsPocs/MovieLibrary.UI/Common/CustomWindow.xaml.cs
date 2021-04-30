using System.Windows;


namespace MovieLibrary.UI.Common
{
    public partial class CustomWindow
    {
        public CustomWindow(ViewModel viewModel)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            DataContext = viewModel;
            Width = viewModel.Width;
            Height = viewModel.Height;
        }
    }
}
