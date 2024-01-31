using ClassesApp.Data;
using ClassesApp.Models;
using ClassesApp.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application = Microsoft.Maui.Controls.Application;

namespace ClassesApp.ViewModels;

public partial class ClassViewModel: ObservableObject
{
    [ObservableProperty]
    ObservableCollection<ClassModel> items = new();

    [ObservableProperty]
    bool loading;

    [ObservableProperty]
    ClassModel item = new();

    public bool isNew = false;

    // CRUD Create-Read-Update-Remove
    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand UpdateCommand { get; }

    ApplicationDbContext Db = new();

    public ClassViewModel()
    {
        SaveCommand = new RelayCommand(SaveProcess);
        DeleteCommand = new RelayCommand<ClassModel>(DeleteProcess);
        AddCommand = new RelayCommand(AddProcess);
        UpdateCommand = new RelayCommand<ClassModel>(UpdateProcess);

        Task.Run(async () =>
        {
            Loading = true;
            await LoadItems();
            Loading = false;
        }).ConfigureAwait(false);
    } 

    private async void DeleteProcess(ClassModel model)
    {
        bool confirm = await Application.Current.MainPage
                      .DisplayAlert("Warning", "Are you sure?", "Yes","No");

        if (confirm) 
        { 
        Items.Remove(model);
        Db.Remove(model);
        //todo remove from database
        await Db.SaveChangesAsync();
        }

    }

    private void AddProcess()
    {
        isNew = true;
        Item = new();
        Shell.Current.Navigation.PushAsync(new ClassPage(this));
    }

    private void UpdateProcess(ClassModel model)
    {
        isNew = false;
        Item = model;
        Shell.Current.Navigation.PushAsync(new ClassPage(this));
    }

    private async void SaveProcess ()
    {

        if (isNew == true)
        {
            //todo save to database
            Db.Classes.Add(Item);
            await Db.SaveChangesAsync();

            Items.Add(Item);

            
        } else
        {
            int index = Items.IndexOf
                        (Items.Where(x => x.Id == Item.Id).Single()
                        );

            Items[index] = Item;
            //todo update to database
           await Db.SaveChangesAsync();
        }
        await Shell.Current.Navigation.PopAsync();
    }

    protected async Task LoadItems()
    {
        Items.Clear();
        // todo read from database

        List<ClassModel> myList = await Db.Classes
                                        .OrderBy(cl => cl.Name)
                                        .ToListAsync();

        // query executed:
        // select * from classes
        // order by classes.name

        foreach (ClassModel model in myList)
        {
            Items.Add (model);
        }

    }
}
