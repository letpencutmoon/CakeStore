﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared.Model
{
    public class Cake
    {
        public int ID { get; set; }
        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty ;

        public string Imgurl { get; set; } = string.Empty ;

        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
    }
}