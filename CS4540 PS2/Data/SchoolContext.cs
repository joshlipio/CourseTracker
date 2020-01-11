/*
  Author:    Joshua Lipio
  Date:      9/13/2019
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Joshua Lipio - This work may not be copied for use in Academic Coursework.

  I, Joshua Lipio, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS4540_PS2.Models;
using Microsoft.EntityFrameworkCore;

namespace CS4540_PS2.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<CourseInstance> CourseInstances { get; set; }
        public DbSet<LearningOutcome> LearningOutcomes { get; set; }
        public DbSet<CourseNote> CourseNotes { get; set; }
        public DbSet<LONote> LONotes { get; set; }
    }
}
