﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTooling.Models
{
    internal class HistoryItem
    {
        public string Text { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
    }
}
