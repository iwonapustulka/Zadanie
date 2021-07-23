using System;
using CsvHelper;
using System.IO;
using System.Linq;
using System.Globalization;
using CsvHelper.Configuration;
using System.Text.Json;
using System.Threading.Tasks;


namespace Zadanie
{
    class Program
    {
        static async Task Main()
        {
            System.Collections.Generic.List<School> students;
            using (var streamReader = File.OpenText("grades.csv"))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };
                var reader = new CsvReader(streamReader, config);
                reader.Context.RegisterClassMap<Mapping>();
                students = reader.GetRecords<School>().ToList();

            }

            
            using FileStream stream = File.Create("gradesjson.json");
            await JsonSerializer.SerializeAsync(stream, students);
            await stream.DisposeAsync();


        }
    }
}
