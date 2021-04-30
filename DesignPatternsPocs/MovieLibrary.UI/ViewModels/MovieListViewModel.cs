using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using MovieLibrary.UI.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MovieLibrary.UI.ViewModels
{
    public class MovieListViewModel : ViewModel
    {
        private readonly MovieRepository _repository;

        public Command SearchCommand { get; }
        public Command<long> BuyTicketCommand { get; }
        public IReadOnlyList<Movie> Movies { get; private set; }

        public MovieListViewModel()
        {
            _repository = new MovieRepository();

            SearchCommand = new Command(Search);
            BuyTicketCommand = new Command<long>(BuyTicket);
        }

        private void BuyTicket(long movieId)
        {
            MessageBox.Show("You've bought a ticket", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Search()
        {
            Movies = _repository.GetList();
            Notify(nameof(Movies));
        }
    }
}
