using System;
using System.Drawing;
using System.Linq;
using Pastel;
using RhythmsGonnaGetYou.bin;

namespace RhythmsGonnaGetYou
{
    public class Musicians
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Instrument { get; set; }
        public bool CurrentMember { get; set; }

        public Bands Band { get; set; }

        private RecordLabelContext context = new RecordLabelContext();



    }
}
