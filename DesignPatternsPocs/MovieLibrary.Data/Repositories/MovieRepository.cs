using CSharpFunctionalExtensions;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.ORM;
using NHibernate;
using System;
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

        public IReadOnlyList<Movie> GetList(bool forKidsOnly, double minRating, bool OnCD)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Movie>()
                    .Where(m => !forKidsOnly || m.MpaaRating <= MpaaRating.PG)
                    .Where(m=> m.Rating >= minRating)
                    .Where(m=> !OnCD || m.ReleaseDate <= DateTime.Now.AddMonths(-6))
                    .ToList();
            }
        }
    }
}
