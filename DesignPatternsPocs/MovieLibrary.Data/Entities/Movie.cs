﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Data.Entities
{
    public class Movie : Entity
    {
        public virtual string Name { get; }
        public virtual DateTime ReleaseDate { get; }
        public virtual MpaaRating MpaaRating { get; }
        public virtual string Genre { get; }
        public virtual double Rating { get; }

        protected Movie()
        {
        }
    }


    public enum MpaaRating
    {
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4
    }
}
