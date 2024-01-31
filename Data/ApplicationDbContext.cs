using ClassesApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp.Data;

public class ApplicationDbContext: DbContext
{
    //database tables
    public DbSet<ClassModel> Classes { get; set; }

    public string DBPath { get; private set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public ApplicationDbContext()
    {
        DBPath = $"{FileSystem.Current.AppDataDirectory}{System.IO.Path.DirectorySeparatorChar}class.dat";
        Debug.WriteLine($"STORAGE CLASS DATABASE: {DBPath}");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite($"Data Source={DBPath}");
    }
}
