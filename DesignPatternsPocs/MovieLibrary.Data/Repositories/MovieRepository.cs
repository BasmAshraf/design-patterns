using CSharpFunctionalExtensions;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.ORM;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Data.Repositories
{
    public class MovieRepository
    {
        public Maybe<Movie> GetOne(long id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<Movie>(id);
            }
        }

        public IReadOnlyList<Movie> GetList()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Movie>().ToList();
            }
        }
    }
}
