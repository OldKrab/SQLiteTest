using System.Collections.Generic;
using System.Windows.Documents;

namespace SQLiteTest.Objects
{
    public class Disease
    {
        public int DiseaseId { get; set; }
        public string Name { get; set; }

        public List<Symptom> Symptoms { get; } = new List<Symptom>();
    }
}