using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;
class Program
{
    static void Main()
    {
        //задание 1
        List<(string, int)> objects = new List<(string, int)>
        {
            ("Containment Cell A", 4),
            ("Archive Vault", 1),
            ("Bio Lab Sector", 3),
            ("Observation Wing", 2)

        };
        var sordetObject = objects.OrderBy(i => i.Item2).ToList();
        foreach (var obj in sordetObject)
        {
            Console.WriteLine(obj.Item1, obj.Item2);
        }
        //задание 2
        var staffShifts = new[]
        {
        new { Name = "Dr. Shaw", ShiftCost = 120, Shifts = 15 },
        new { Name = "Agent Torres", ShiftCost = 90, Shifts = 22 },
        new { Name = "Researcher Hall", ShiftCost = 150, Shifts = 10 }
        };
        var result = staffShifts
        .Select(i => new{i.Name,i.ShiftCost,i.Shifts,Total = i.ShiftCost * i.Shifts}).OrderBy(e => e.Total).ToList();
        foreach (var i in result)
        {
            Console.WriteLine($"{i.Name}: ${i.Total} (${i.ShiftCost} × {i.Shifts})");
        }

        Console.WriteLine(result.Max(e => e.Total));
        //задание 3
        var personnel = new[]
        {
            new{Name= "Dr. Klein", Clearance= 2},
            new{Name= "Agent Brooks", Clearance= 4},
            new{Name= "Technician Reed", Clearance= 1}
        };
        var acsessLevel = personnel
        .Select(i => new { i.Name, i.Clearance, category = i.Clearance == 1 ? "Restricted" : i.Clearance <= 3 ? "Confidential" : "Top Secret" }).ToList();
        foreach (var person in acsessLevel)
        {
            Console.WriteLine($" {person.Name}, " + $" {person.Clearance}, " + $" {person.category}");
        }
        //задание 4
        new[]
        {
            new { zone = "Sector-12", active_from = 8, active_to = 18 },
            new { zone = "Deep Storage", active_from = 0, active_to = 24 },
            new { zone = "Research Wing", active_from = 9, active_to = 17 }
        }
        .Where(i => i.active_from >= 8 && i.active_to <= 18)
        .ToList()
        .ForEach(i => Console.WriteLine($"{i.zone}: {i.active_from}:00 - {i.active_to}:00"));
        //задание 5
        var reports = new[]
        {
            new {Author= "Dr. Moss", Text= "Analysis completed. Reference: http://external-archive.net"},
            new {Author= "Agent Lee", Text= "Incident resolved without escalation."},
            new {Author= "Dr. Patel", Text= "Supplementary data available at https://secure-research.org"},
            new {Author="Supervisor Kane", Text= "No anomalies detected during inspection."},
            new {Author= "Researcher Bloom", Text= "Extended observations uploaded to http://research-notes.lab"},
            new {Author= "Agent Novak", Text= "Perimeter secured. No external interference observed."},
            new {Author= "Dr. Hargreeve", Text= "Full containment log stored at https://internal-db.scp"},
            new {Author= "Technician Moore", Text= "Routine maintenance completed successfully."},
            new {Author= "Dr. Alvarez", Text= "Cross-reference materials: http://crosslink.foundation"},
            new {Author= "Security Officer Tan", Text= "Shift completed without incidents."},
            new {Author= "Analyst Wright", Text= "Statistical model published at https://analysis-hub.org"},
            new {Author= "Dr. Kowalski", Text= "Behavioral deviations documented internally."},
            new {Author= "Agent Fischer", Text= "Additional footage archived: http://video-storage.sec"},
            new {Author= "Senior Researcher Hall", Text= "All test results verified and approved."},
            new {Author= "Operations Lead Grant", Text= "Emergency protocol draft shared via https://ops-share.scp"}
        }
        .Where(i => i.Text.Contains("http") || i.Text.Contains("hppts"));
        var newreports = reports
        .Select(i => new { i.Author, text = i.Text.Replace("http", "ДАННЫЕ УДАЛЕНЫ").Replace("https", "ДАННЫЕ УДАЛЕНЫ") }).ToList();
        newreports.ForEach(i => Console.WriteLine($"{i.Author}: {i.text}"));
        //задание 6
        new[]
        {
            new {Scp= "SCP-096", Class = "Euclid"},
            new {Scp= "SCP-173", Class= "Euclid"},
            new {Scp= "SCP-055", Class= "Keter"},
            new {Scp= "SCP-999", Class= "Safe"},
            new {Scp = "SCP-3001", Class=  "Keter"}
        }
        .Where(i => i.Class == "Euclid" || i.Class == "Keter")
        .ToList()
        .ForEach(i => Console.WriteLine($"{i.Scp}:{i.Class}"));
        //задание 7
        var incidents = new[]
        {
            new {Id= 101, Staff= 4},
            new {Id= 102, Staff= 12},
            new {Id= 103, Staff= 7},
            new {Id= 104, Staff= 20}
        };
        var sortedIncident = incidents.OrderByDescending(i => i.Staff).Take(3);
        foreach(var obj in sortedIncident)
        {
            Console.WriteLine($"{obj.Id}, {obj.Staff}");
        }
        //задание 8
        var protocols = new[]
        {
            ("Lockdown", 5),
            ("Evacuation", 4),
            ("Data Wipe", 3),
            ("Routine Scan", 1)
        };
        foreach(var i in  protocols)
        {
            Console.WriteLine($"Protocol {i.Item1} - Critically {i.Item2} ");
        }
        //задание 9
        int[] shifts = { 6, 12, 8, 24, 10, 4 };
        foreach (var i in shifts)
        {
            if (i>=8 && i<=12)
            {
                Console.WriteLine(i);
            }
        }
        //задание 10
        var evaluations = new[]
        {
            new {Name= "Agent Cole", Score=78},
            new {Name= "Dr. Weiss", Score= 92},
            new {Name= "Technician Moore", Score= 61},
            new {Name= "Researcher Lin", Score= 88}
        };
        var maxEvaluation = evaluations.MaxBy(e => e.Score);
        Console.WriteLine($"{maxEvaluation.Name}, {maxEvaluation.Score}");




        


    }
}



