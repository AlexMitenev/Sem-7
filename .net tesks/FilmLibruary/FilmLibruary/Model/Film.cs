﻿using System.Collections.Generic;
using System.Drawing;

namespace FilmLibruary.Model
{
    public class Film
    {
        public int Id {get; set;}
        public Bitmap Picture { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public Producer Producer { get; set; }
        public List<Actor> MainActors { get; set; }
    }
}
