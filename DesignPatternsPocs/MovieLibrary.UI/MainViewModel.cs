using MovieLibrary.UI.Common;
using MovieLibrary.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.UI
{
    public class MainViewModel
    {
        public ViewModel ViewModel { get; }


        public MainViewModel()
        {
            ViewModel = new MovieListViewModel();
        }
    }
}
