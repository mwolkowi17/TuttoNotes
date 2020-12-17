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
    }
}