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

        public IReadOnlyList<Movie> GetList(
            Specification<Movie> specification,
            double minimumRating)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Movie>()
                    .Where(specification.ToExpression())
                    .Where(x => x.Rating >= minimumRating)
                    .ToList();
            }
        }
    }
}
