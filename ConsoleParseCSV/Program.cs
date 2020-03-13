using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleParseCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = ProcessCsv("SourceCsvFile.csv");
            Console.WriteLine("User ID:  First Name:  Last Name:  Company:  Version Number:");
            Console.WriteLine("--------------------------------------------------------------");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}  {user.FirstName}  {user.LastName}  {user.Company}  {user.Version}");
                Console.WriteLine("");
            }
        }

        private static List<User> ProcessCsv(string path)
        {
            return File.ReadAllLines(path)
                .Where(row => row.Length > 0)
                .Select(User.ParseRow).ToList();
        }
    }

    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Version { get; set; }
        public string Company { get; set; }

        internal static User ParseRow(string row)
        {
            var columns = row.Split(',');

            return new User()
            {
                Id = columns[0],
                FirstName = columns[1],
                LastName = columns[2],
                Version = int.Parse(columns[3]),
                Company = columns[4]
            };
        }
    }
}