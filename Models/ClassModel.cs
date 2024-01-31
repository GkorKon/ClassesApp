using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp.Models;
/// <summary>
/// This is the main class model
/// </summary>

public partial class ClassModel: ObservableObject
{
    [Key]
    public int Id { get; set; }

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string description;

}
