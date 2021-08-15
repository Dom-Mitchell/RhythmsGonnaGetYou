using System;
using System.Collections.Generic;

namespace RhythmsGonnaGetYou.bin
{
    public class Albums
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }

        public Bands Band { get; set; }
        public List<Songs> Songs { get; set; }

    }
}