using System;
using System.Collections.Generic;

#nullable disable

namespace Elearn.KaniniModel
{
    public partial class Course
    {
        public Course()
        {
            Usercourses = new HashSet<Usercourse>();
        }

        public int Courseid { get; set; }
        public string Coursename { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Usercourse> Usercourses { get; set; }
    }
}
