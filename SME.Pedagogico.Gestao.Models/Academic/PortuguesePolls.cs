using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Academic
{
    public class PortuguesePoll : Base.Abstracts.Table
    {
        public string dreCodeEol { get; set; }
        public string schoolCodeEol { get; set; }
        public string classroomCodeEol { get; set; }
        public string schoolYear { get; set; }
        public string yearClassroom { get; set; }
        public string studentCodeEol { get; set; }
        public string studentNameEol { get; set; }

        public string reading1B { get; set; }
        public string writing1B { get; set; }

        public string reading2B { get; set; }
        public string writing2B { get; set; }

        public string reading3B { get; set; }
        public string writing3B { get; set; }

        public string reading4B { get; set; }
        public string writing4B { get; set; }
    }
}
