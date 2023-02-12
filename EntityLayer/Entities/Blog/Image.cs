﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Blog
{
    public class Image
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? BackupUrl { get; set; }
        public int Status { get; set; }

    }
}
