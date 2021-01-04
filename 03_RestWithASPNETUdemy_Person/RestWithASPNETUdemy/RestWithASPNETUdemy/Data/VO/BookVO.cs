﻿using RestWithASPNETUdemy.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Data.VO

{
    public class BookVO
    {
        public long Id { get; set; }
        public string Author { get; set; }

        public DateTime LaunchDate { get; set; }

        public double Price { get; set; }

        public string Title { get; set; }
    }
}
