/*
  Author:    Joshua Lipio
  Date:      10/18/2019
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Joshua Lipio - This work may not be copied for use in Academic Coursework.

  I, Joshua Lipio, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4540_PS2.Models
{
    public class LONote
    {
        public int LONoteID { get; set; }
        public string Note { get; set; }
        public int LearningOutcomeID { get; set; }
        public LearningOutcome LearningOutcome { get; set; }
    }
}
