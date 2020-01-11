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
using Microsoft.AspNetCore.Identity;

namespace CS4540_PS2.Data
{
    public class DatabaseTestData
    {
        public static async Task InitializeAsync(SchoolContext context, IdentityDB identity,
                                            UserManager<IdentityUser> userManager,
                                            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            identity.Database.EnsureCreated();

            //Create roles
            if (!identity.Roles.Any())
            {
                var roles = new IdentityRole[]
                {
                new IdentityRole{ Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole{ Name = "Instructor", NormalizedName = "INSTRUCTOR"},
                new IdentityRole{ Name = "Chair", NormalizedName = "CHAIR"}
                };

                foreach (IdentityRole r in roles)
                {
                    identity.Roles.Add(r);
                }
                identity.SaveChanges();
            }

            //Create users
            if (!identity.Users.Any())
            {
                //admin
                var admin = new IdentityUser
                {
                    UserName = "admin_erin@cs.utah.edu",
                    Email = "admin_erin@cs.utah.edu",
                    EmailConfirmed = true
                };

                var createSuccessful = await userManager.CreateAsync(admin, "123ABC!@#def");

                if (createSuccessful.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }

                //intructor jim
                var intructor1 = new IdentityUser
                {
                    UserName = "professor_jim@cs.utah.edu",
                    Email = "professor_jim@cs.utah.edu",
                    EmailConfirmed = true
                };

                createSuccessful = await userManager.CreateAsync(intructor1, "123ABC!@#def");

                if (createSuccessful.Succeeded)
                {
                    await userManager.AddToRoleAsync(intructor1, "Instructor");
                }

                //instructor mary
                var intructor2 = new IdentityUser
                {
                    UserName = "professor_mary@cs.utah.edu",
                    Email = "professor_mary@cs.utah.edu",
                    EmailConfirmed = true
                };

                createSuccessful = await userManager.CreateAsync(intructor2, "123ABC!@#def");

                if (createSuccessful.Succeeded)
                {
                    await userManager.AddToRoleAsync(intructor2, "Instructor");
                }

                //instructory danny
                var intructor3 = new IdentityUser
                {
                    UserName = "professor_danny@cs.utah.edu",
                    Email = "professor_danny@cs.utah.edu",
                    EmailConfirmed = true
                };

                createSuccessful = await userManager.CreateAsync(intructor3, "123ABC!@#def");

                if (createSuccessful.Succeeded)
                {
                    await userManager.AddToRoleAsync(intructor3, "Instructor");
                }

                //chair
                var chair = new IdentityUser
                {
                    UserName = "chair_whitaker@cs.utah.edu",
                    Email = "chair_whitaker@cs.utah.edu",
                    EmailConfirmed = true
                };

                createSuccessful = await userManager.CreateAsync(chair, "123ABC!@#def");

                if (createSuccessful.Succeeded)
                {
                    await userManager.AddToRoleAsync(chair, "Chair");
                }
            }

            //Create courses
            if (!context.CourseInstances.Any())
            {
                var courses = new CourseInstance[]
                {
                    new CourseInstance{Name="Introduction to Object-Oriented Programming",
                        Description ="Description of Intro to Object-Oriented Programming", Department = "CS", Number = 1410,
                        Semester = "Fall 2019", Professor = "Joseph Zachary"},
                    new CourseInstance{Name="Discrete Structures",
                        Description ="Stuff about Discrete Structures", Department = "CS", Number = 2100,
                        Semester = "Fall 2019", Professor = "Mary Sue", ProfessorID = (await userManager.FindByEmailAsync("professor_mary@cs.utah.edu")).Id},
                    new CourseInstance{Name="Introduction to Algorithms and Data Structures",
                        Description ="Stuff about Intro to Algorithms and Data Structures", Department = "CS", Number = 2420,
                        Semester = "Fall 2019", Professor = "H. James de St. Germain", ProfessorID = (await userManager.FindByEmailAsync("professor_jim@cs.utah.edu")).Id},
                    new CourseInstance{Name="Models of Computation",
                        Description ="Models of Computation information", Department = "CS", Number = 3100,
                        Semester = "Fall 2019", Professor = "Ganesh Gopalakrishnan"},
                    new CourseInstance{Name="Software Practice",
                        Description ="Description to Software Practice", Department = "CS", Number = 3500,
                        Semester = "Fall 2019", Professor = "H. James de St. Germain", ProfessorID = (await userManager.FindByEmailAsync("professor_jim@cs.utah.edu")).Id},
                    new CourseInstance{Name="Software Practice",
                        Description ="Description to Software Practice", Department = "CS", Number = 3500,
                        Semester = "Fall 2019", Professor = "Daniel Kopta", ProfessorID = (await userManager.FindByEmailAsync("professor_danny@cs.utah.edu")).Id},
                    new CourseInstance{Name="Computer Systems",
                        Description ="Computer Systems info", Department = "CS", Number = 4400,
                        Semester = "Fall 2019", Professor = "Mary Sue", ProfessorID = (await userManager.FindByEmailAsync("professor_mary@cs.utah.edu")).Id},
                    new CourseInstance{Name="Web Software Architecture",
                        Description ="This course introduces the basics of \"full stack\" web based software development, including an introduction to front ends (i.e. browser code), back ends (i.e. server code), and databases (e.g. SQL).",
                        Department = "CS", Number = 4540,
                        Semester = "Fall 2019", Professor = "H. James de St. Germain", ProfessorID = (await userManager.FindByEmailAsync("professor_jim@cs.utah.edu")).Id},
                };
                foreach (CourseInstance c in courses)
                {
                    context.CourseInstances.Add(c);
                }
                context.SaveChanges();
            }

            //Create learning outcomes, assign to CourseInstances
            if (!context.LearningOutcomes.Any())
            {
                var learningOutcomes = new LearningOutcome[]
                {
                    //CS1410
                    new LearningOutcome{Name="IOOP1",
                        Description ="Learning outcome for Intro to OOP",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Introduction to Object-Oriented Programming").ID},
                    new LearningOutcome{Name="IOOP2",
                        Description ="Another outcome for Intro to OOP",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Introduction to Object-Oriented Programming").ID},
                    new LearningOutcome{Name="IOOP3",
                        Description ="A third LO for Intro to OOP",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Introduction to Object-Oriented Programming").ID},

                    //CS2100
                    new LearningOutcome{Name="DS1",
                        Description ="Use symbolic logic to model real-world situations by converting informal language statements to propositional and predicate logic expressions, as well as apply formal methods to propositions and predicates (such as computing normal forms and calculating validity)",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Discrete Structures").ID},
                    new LearningOutcome{Name="DS2",
                        Description ="Analyze problems to determine underlying recurrence relations, as well as solve such relations by rephrasing as closed formulas",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Discrete Structures").ID},
                    new LearningOutcome{Name="DS3",
                        Description ="Assign practical examples to the appropriate set, function, or relation model, while employing the associated terminology and operations",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Discrete Structures").ID},
                    new LearningOutcome{Name="DS4",
                        Description ="Map real-world applications to appropriate counting formalisms, including permutations and combinations of sets, as well as exercise the rules of combinatorics (such as sums, products, and inclusion-exclusion)",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Discrete Structures").ID},
                    new LearningOutcome{Name="DS5",
                        Description ="Calculate probabilities of independent and dependent events, in addition to expectations of random variables",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Discrete Structures").ID},
                    new LearningOutcome{Name="DS6",
                        Description ="Illustrate by example the basic terminology of graph theory, as wells as properties and special cases (such as Eulerian graphs, spanning trees, isomorphism, and planarity)",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Discrete Structures").ID},
                    new LearningOutcome{Name="DS7",
                        Description ="Employ formal proof techniques (such as direct proof, proof by contradiction, induction, and the pigeonhole principle) to construct sound arguments about properties of numbers, sets, functions, relations, and graphs",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Discrete Structures").ID},

                    //CS2420
                    new LearningOutcome{Name="ADS1",
                        Description ="Implement, and analyze for efficiency, fundamental data structures (including lists, graphs, and trees) and algorithms (including searching, sorting, and hashing)",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Introduction to Algorithms and Data Structures").ID},
                    new LearningOutcome{Name="ADS2",
                        Description ="Employ Big-O notation to describe and compare the asymptotic complexity of algorithms, as well as perform empirical studies to validate hypotheses about running time",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Introduction to Algorithms and Data Structures").ID},
                    new LearningOutcome{Name="ADS3",
                        Description ="Recognize and describe common applications of abstract data types (including stacks, queues, priority queues, sets, and maps)",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Introduction to Algorithms and Data Structures").ID},
                    new LearningOutcome{Name="ADS4",
                        Description ="Apply algorithmic solutions to real-world data",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Introduction to Algorithms and Data Structures").ID},
                    new LearningOutcome{Name="ADS5",
                        Description ="Use generics to abstract over functions that differ only in their types",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Introduction to Algorithms and Data Structures").ID},
                    new LearningOutcome{Name="ADS6",
                        Description ="Appreciate the collaborative nature of computer science by discussing the benefits of pair programming",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Introduction to Algorithms and Data Structures").ID},

                    //CS3100
                    new LearningOutcome{Name="MC1",
                        Description ="Models of Computation LO",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Models of Computation").ID},

                    //CS3500
                    new LearningOutcome{Name="SP1",
                        Description ="Design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="H. James de St. Germain").ID},
                    new LearningOutcome{Name="SP2",
                        Description ="Perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="H. James de St. Germain").ID},
                    new LearningOutcome{Name="SP3",
                        Description ="Apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="H. James de St. Germain").ID},
                    new LearningOutcome{Name="SP4",
                        Description ="Exercise the client-server model and high-level networking APIs to build a web-based software system",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="H. James de St. Germain").ID},
                    new LearningOutcome{Name="SP5",
                        Description ="Operate a modern relational database to define relations, as well as store and retrieve data",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="H. James de St. Germain").ID},
                    new LearningOutcome{Name="SP6",
                        Description ="Appreciate the collaborative nature of software development by discussing the benefits of peer code reviews",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="H. James de St. Germain").ID},

                    //CS3500
                    new LearningOutcome{Name="SP1",
                        Description ="Design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="Daniel Kopta").ID},
                    new LearningOutcome{Name="SP2",
                        Description ="Perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="Daniel Kopta").ID},
                    new LearningOutcome{Name="SP3",
                        Description ="Apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="Daniel Kopta").ID},
                    new LearningOutcome{Name="SP4",
                        Description ="Exercise the client-server model and high-level networking APIs to build a web-based software system",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="Daniel Kopta").ID},
                    new LearningOutcome{Name="SP5",
                        Description ="Operate a modern relational database to define relations, as well as store and retrieve data",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="Daniel Kopta").ID},
                    new LearningOutcome{Name="SP6",
                        Description ="Appreciate the collaborative nature of software development by discussing the benefits of peer code reviews",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="Daniel Kopta").ID},

                    //CS4400
                    new LearningOutcome{Name="CS1",
                        Description ="Explain the objectives and functions of abstraction layers in modern computing systems, including operating systems, programming languages, compilers, and applications",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Computer Systems").ID},
                    new LearningOutcome{Name="CS2",
                        Description ="Understand cross-layer communications and how each layer of abstraction is implemented in the next layer of abstraction (such as how C programs are translated into assembly code and how C library allocators are implemented in terms of operating system memory management)",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Computer Systems").ID},
                    new LearningOutcome{Name="CS3",
                        Description ="Analyze how the performance characteristics of one layer of abstraction affect the layers above it (such as how caching and services of the operating system affect the performance of C programs)",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Computer Systems").ID},
                    new LearningOutcome{Name="CS4",
                        Description ="Construct applications using operating-system concepts (such as processes, threads, signals, virtual memory, I/O)",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Computer Systems").ID},
                    new LearningOutcome{Name="CS5",
                        Description ="Synthesize operating-system and networking facilities to build concurrent, communicating applications",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Computer Systems").ID},
                    new LearningOutcome{Name="CS6",
                        Description ="Implement reliable concurrent and parallel programs using appropriate synchronization constructs",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Computer Systems").ID},


                    //CS4540
                    new LearningOutcome{Name="WSA1",
                        Description ="Construct web pages using modern HTML and CSS practices, including modern frameworks",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Web Software Architecture").ID},
                    new LearningOutcome{Name="WSA2",
                        Description ="Define accessibility and utilize techniques to create accessible web pages",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Web Software Architecture").ID},
                    new LearningOutcome{Name="WSA3",
                        Description ="Outline and utilize MVC technologies across the “full-stack” of web design (including front-end, back-end, and databases) to create interesting web applications. Deploy an application to a “Cloud” provider",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Web Software Architecture").ID},
                    new LearningOutcome{Name="WSA4",
                        Description ="Describe the browser security model and HTTP; utilize techniques for data validation, secure session communication, cookies, single sign-on, and separate roles",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Web Software Architecture").ID},
                    new LearningOutcome{Name="WSA5",
                        Description ="Utilize JavaScript for simple page manipulations and AJAX for more complex/complete “single-page” applications",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Web Software Architecture").ID},
                    new LearningOutcome{Name="WSA6",
                        Description ="Demonstrate how responsive techniques can be used to construct applications that are usable at a variety of page sizes. Define and discuss responsive, reactive, and adaptive",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Web Software Architecture").ID},
                    new LearningOutcome{Name="WSA7",
                        Description ="Construct a simple web-crawler for validation of page functionality and data scraping",
                        courseinstanceID = context.CourseInstances.Single(s=>s.Name=="Web Software Architecture").ID},
                };
                foreach (LearningOutcome l in learningOutcomes)
                {
                    context.LearningOutcomes.Add(l);
                }
                context.SaveChanges();
            }

            if (!context.CourseNotes.Any())
            {
                var courseNotes = new CourseNote[]
                {
                    new CourseNote{Note = "Note for Intro to OOP",
                        CourseInstanceID = context.CourseInstances.Single(s => s.Name == "Introduction to Object-Oriented Programming").ID,
                        CourseInstance = context.CourseInstances.Single(s => s.Name == "Introduction to Object-Oriented Programming")},
                    new CourseNote{Note = "Discrete Structures note",
                        CourseInstanceID = context.CourseInstances.Single(s => s.Name == "Discrete Structures").ID,
                        CourseInstance = context.CourseInstances.Single(s => s.Name == "Discrete Structures")},
                    new CourseNote{Note = "2420 Note",
                        CourseInstanceID = context.CourseInstances.Single(s => s.Name == "Introduction to Algorithms and Data Structures").ID,
                        CourseInstance = context.CourseInstances.Single(s => s.Name == "Introduction to Algorithms and Data Structures")},
                    new CourseNote{Note = "Another note for Models of Computation",
                        CourseInstanceID = context.CourseInstances.Single(s => s.Name == "Models of Computation").ID,
                        CourseInstance = context.CourseInstances.Single(s => s.Name == "Models of Computation")},
                    new CourseNote{Note = "Software Practice notes for Kopta",
                        CourseInstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="Daniel Kopta").ID,
                        CourseInstance = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="Daniel Kopta")},
                    new CourseNote{Note = "Software Practice notes for Germain",
                        CourseInstanceID = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="H. James de St. Germain").ID,
                        CourseInstance = context.CourseInstances.Single(s=>s.Name=="Software Practice" && s.Professor=="H. James de St. Germain")},
                    new CourseNote{Note = "Note for Computer Systems",
                        CourseInstanceID = context.CourseInstances.Single(s => s.Name == "Computer Systems").ID,
                        CourseInstance = context.CourseInstances.Single(s => s.Name == "Computer Systems")},
                    new CourseNote{Note = "Note for WSA",
                        CourseInstanceID = context.CourseInstances.Single(s => s.Name == "Web Software Architecture").ID,
                        CourseInstance = context.CourseInstances.Single(s => s.Name == "Web Software Architecture")}
                };

                foreach (CourseNote l in courseNotes)
                {
                    context.CourseNotes.Add(l);
                }
                context.SaveChanges();
            }

            if (!context.LONotes.Any())
            {
                var loNotes = new LONote[]
                {
                    //CS1410
                    new LONote{Note="IOOP1",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="IOOP1"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="IOOP1").ID},
                    new LONote{Note="IOOP2",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="IOOP2"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="IOOP2").ID},
                    new LONote{Note="IOOP3",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="IOOP3"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="IOOP3").ID},


                    //CS2100
                    new LONote{Note="DS1",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="DS1"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="DS1").ID},
                    new LONote{Note="DS2",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="DS2"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="DS2").ID},
                    new LONote{Note="DS3",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="DS3"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="DS3").ID},
                    new LONote{Note="DS4",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="DS4"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="DS4").ID},
                    new LONote{Note="DS5",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="DS5"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="DS5").ID},
                    new LONote{Note="DS6",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="DS6"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="DS6").ID},
                    new LONote{Note="DS7",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="DS7"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="DS7").ID},

                    //CS2420
                    new LONote{Note="ADS1",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="ADS1"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="ADS1").ID},
                    new LONote{Note="ADS2",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="ADS2"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="ADS2").ID},
                    new LONote{Note="ADS3",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="ADS3"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="ADS3").ID},
                    new LONote{Note="ADS4",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="ADS4"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="ADS4").ID},
                    new LONote{Note="ADS5",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="ADS5"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="ADS5").ID},
                    new LONote{Note="ADS6",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="ADS6"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="ADS6").ID},

                    //CS3100
                    new LONote{Note="MC1",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="MC1"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="MC1").ID},

                    //CS3500
                    new LONote{Note="SP1",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP1" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="H. James de St. Germain").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="SP1" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="H. James de St. Germain").ID).ID},
                    new LONote{Note="SP2",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP2" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="H. James de St. Germain").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s => s.Name == "SP2" && s.courseinstanceID==context.CourseInstances.Single(c => c.Name=="Software Practice" && c.Professor == "H. James de St. Germain").ID).ID},
                    new LONote{Note="SP3",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP3" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="H. James de St. Germain").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="SP3" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="H. James de St. Germain").ID).ID},
                    new LONote{Note="SP4",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP4" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="H. James de St. Germain").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s => s.Name == "SP4" && s.courseinstanceID==context.CourseInstances.Single(c => c.Name=="Software Practice" && c.Professor == "H. James de St. Germain").ID).ID},
                    new LONote{Note="SP5",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP5" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="H. James de St. Germain").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="SP5" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="H. James de St. Germain").ID).ID},
                    new LONote{Note="SP6",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP6" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="H. James de St. Germain").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="SP6" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="H. James de St. Germain").ID).ID},

                    //CS3500
                    new LONote{Note="SP1",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP1" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="Daniel Kopta").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="SP1" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="Daniel Kopta").ID).ID},
                    new LONote{Note="SP2",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP2" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="Daniel Kopta").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s => s.Name == "SP2" && s.courseinstanceID==context.CourseInstances.Single(c => c.Name=="Software Practice" && c.Professor == "Daniel Kopta").ID).ID},
                    new LONote{Note="SP3",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP3" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="Daniel Kopta").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="SP3" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="Daniel Kopta").ID).ID},
                    new LONote{Note="SP4",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP4" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="Daniel Kopta").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s => s.Name == "SP4" && s.courseinstanceID==context.CourseInstances.Single(c => c.Name=="Software Practice" && c.Professor == "Daniel Kopta").ID).ID},
                    new LONote{Note="SP5",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP5" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="Daniel Kopta").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="SP5" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="Daniel Kopta").ID).ID},
                    new LONote{Note="SP6",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="SP6" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="Daniel Kopta").ID),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="SP6" && s.courseinstanceID==context.CourseInstances.Single(c=>c.Name=="Software Practice" && c.Professor=="Daniel Kopta").ID).ID},

                    //CS4400
                    new LONote{Note="CS1",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="CS1"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="CS1").ID},
                    new LONote{Note="CS2",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="CS2"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="CS2").ID},
                    new LONote{Note="CS3",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="CS3"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="CS3").ID},
                    new LONote{Note="CS4",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="CS4"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="CS4").ID},
                    new LONote{Note="CS5",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="CS5"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="CS5").ID},
                    new LONote{Note="CS6",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="CS6"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="CS6").ID},

                    //CS4540
                    new LONote{Note="WSA1",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="WSA1"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="WSA1").ID},
                    new LONote{Note="WSA2",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="WSA2"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="WSA2").ID},
                    new LONote{Note="WSA3",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="WSA3"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="WSA3").ID},
                    new LONote{Note="WSA4",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="WSA4"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="WSA4").ID},
                    new LONote{Note="WSA5",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="WSA5"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="WSA5").ID},
                    new LONote{Note="WSA6",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="WSA6"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="WSA6").ID},
                    new LONote{Note="WSA7",
                        LearningOutcome = context.LearningOutcomes.Single(s=>s.Name=="WSA7"),
                        LearningOutcomeID = context.LearningOutcomes.Single(s=>s.Name=="WSA7").ID},
                };

                foreach (LONote l in loNotes)
                {
                    context.LearningOutcomes.Single(s => s.ID == l.LearningOutcomeID).Note = l;
                    context.LONotes.Add(l);
                }
                context.SaveChanges();
            }
        }
    }
}
