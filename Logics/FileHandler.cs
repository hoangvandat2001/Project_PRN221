using Microsoft.EntityFrameworkCore;
using Project_PRN221.Model;
using System.Formats.Asn1;
using System.Globalization;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CsvHelper;

namespace Project_PRN221.Logics
{
    public static class FileHandler
    {
        public static void SaveFile(List<Class> listClass)
        {
            File.Delete(@"C:\Users\antoan\Desktop\Project_PRN211\Output.csv");
            String file = @"C:\Users\antoan\Desktop\Project_PRN211\Output.csv";
            String separator = ",";
            StringBuilder output = new StringBuilder();
            String[] headings = {"ID" ,"Room", "TimeSlot", "Class", "Subject", "Teacher" };
            output.AppendLine(string.Join(separator, headings));
           
            
            foreach (Class c in listClass)
            {
                String[] newLine = {Guid.NewGuid().ToString(), c.Room.RoomName.ToString(), $"{c.Timeslot.SlotNumber} {c.Timeslot.DayOfWeek} {c.Timeslot.SlotType}", c.ClassName, c.Subject.SubjectName, c.Teacher.TeacherName };
                output.AppendLine(string.Join(separator, newLine));
            }
            try
            {
                File.AppendAllText(file, output.ToString());
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data could not be written to the CSV file.");
                return;
            }
        }

        public static void UpdateFile(List<ClassModel> listClass)
        {
            File.Delete(@"C:\Users\antoan\Desktop\Project_PRN211\Output.csv");
            String file = @"C:\Users\antoan\Desktop\Project_PRN211\Output.csv";
            String separator = ",";
            StringBuilder output = new StringBuilder();
            String[] headings = {"ID", "Room", "TimeSlot", "Class", "Subject", "Teacher" };
            output.AppendLine(string.Join(separator, headings));


            foreach (ClassModel c in listClass)
            {
                String[] newLine = {c.ID, c.Room.ToString(), c.TimeSlot, c.Class, c.Subject, c.Teacher };
                output.AppendLine(string.Join(separator, newLine));
            }
            try
            {
                File.AppendAllText(file, output.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Data could not be written to the CSV file.");
                return;
            }
        }
        public static List<ClassModel> ReadFile()
        {
            var result = new List<ClassModel>();
            using (var reader = new StreamReader(@"C:\Users\antoan\Desktop\Project_PRN211\Output.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                var records = csv.GetRecords<ClassModel>().ToList();
                foreach (var item in records)
                {
                    var isValid = true;
                    foreach (var rs in result)
                    {
                        if (rs.TimeSlot == item.TimeSlot && rs.Room == item.Room && item.Class != rs.Class)
                        {
                            isValid = false; 
                            continue;
                        }
                        if (rs.TimeSlot == item.TimeSlot && rs.Teacher == item.Teacher && item.Class != rs.Class)
                        {
                            isValid = false;
                            continue;
                        }
                        if (rs.Class == item.Class && rs.TimeSlot == item.TimeSlot && item.Subject != rs.Subject)
                        {
                            isValid = false;
                            continue;
                        }
                    }
                    if (isValid)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
