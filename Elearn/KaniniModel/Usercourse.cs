﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Elearn.KaniniModel
{
    public partial class Usercourse
    {
        public int Stuid { get; set; }
        public int Coid { get; set; }

        public virtual Course Co { get; set; }
        public virtual User Stu { get; set; }
    }
}
