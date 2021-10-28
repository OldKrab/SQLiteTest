using System;
using Microsoft.EntityFrameworkCore;
using SQLiteTest.Objects;

namespace SQLiteTest
{
    public class TestContext : DbContext
    {
        public TestContext()
        {
            DbPath = "test.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public string DbPath { get; private set; }
    }
}