using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuttoNotes.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuttoNotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesList : ContentPage
    {
        public SQLiteAsyncConnection _connection;
        public ObservableCollection<Note> _notes;

        public NotesList()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Note>();
            var notes = await _connection.Table<Note>().ToListAsync();
            _notes = new ObservableCollection<Note>(notes);
            NotesListView.ItemsSource = _notes;
            base.OnAppearing();
        }

        private void AddNew_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EntryForm());
        }

        private void NotesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var noteToDisplay = e.SelectedItem as Note;
            Navigation.PushAsync(new NoteDetails(noteToDisplay));
            NotesListView.SelectedItem = null;
        }

        async private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            var noteToDelete = menuitem.CommandParameter as Note;
            await _connection.DeleteAsync(noteToDelete);
            var notes = await _connection.Table<Note>().ToListAsync();
            _notes = new ObservableCollection<Note>(notes);
            NotesListView.ItemsSource = _notes;

        }

        async private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            var noteSelected = menuitem.CommandParameter as Note;
            await Navigation.PushAsync(new NoteUpdate(noteSelected));
        }

        async private void SearchNotes_TextChanged(object sender, TextChangedEventArgs e)
        {
            var notes = await _connection.Table<Note>().ToListAsync();
            _notes = new ObservableCollection<Note>(notes);

            var searchedNotes = _notes.Where(n => n.Title == e.NewTextValue).ToList();
            if (e.NewTextValue == "")
            {
                NotesListView.ItemsSource = _notes;
            }
            else
            {
                NotesListView.ItemsSource = searchedNotes;
            }
        }
    }
}