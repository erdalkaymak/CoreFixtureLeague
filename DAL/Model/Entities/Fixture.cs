using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model
{
    public class Fixture : Base
    {       
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public DateTime FixtureDate { get; set; }
    }
}
