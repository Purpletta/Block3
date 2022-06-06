﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
   
    public partial class NotesPage : ContentPage
    {  // CollectionView collectionView = new CollectionView();
        public NotesPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = await App.NotesDB.GetNotesAsync(); 
            base.OnAppearing();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NoteAddingPage));

        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        { if (e.CurrentSelection != null) {
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync(
                    $"{nameof(NoteAddingPage)}?{nameof(NoteAddingPage.ItemID)}={note.ID.ToString()}");
            }


        }
    }
}