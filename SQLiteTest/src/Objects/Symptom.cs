using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteTest.Objects
{
    public class Symptom
    {
        public int SymptomId { get; set; }
        public string Name { get; set; }
        public List<Disease> Diseases { get; } = new List<Disease>();
    }
}
