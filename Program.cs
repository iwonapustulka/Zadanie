using System;
using CsvHelper;
using System.IO;
using System.Linq;
using System.Globalization;
using CsvHelper.Configuration;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.List<School> students;
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            using (var streamReader = File.OpenText("grades.csv"))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };
                var reader = new CsvReader(streamReader, config);
                reader.Context.RegisterClassMap<Mapping>();
                students = reader.GetRecords<School>().ToList();

            }
            using (StreamWriter sw = new StreamWriter("gradesjson.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, students);
            }
            
        }
    }
}
