using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    
        public class Classdata
        {
            public int Class_Id { get; set; }
            public int Roll_no { get; set; }

            public int Subject_Id { get; set; }
        }
        public class Studentdata
        {
            public int Roll_no { get; set; }

            public string StudentName { get; set; }

            public int Class { get; set; }

            public int Age { get; set; }


        }
        public class Subjectdata
        {
            public int SubjectId { get; set; }
            public string SubjectName { get; set; }
        }
    }

