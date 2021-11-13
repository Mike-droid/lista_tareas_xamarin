using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Lista_Tareas
{
    public class DeleteTaskPage : ContentPage
    {

        private ListView _listView;
        private Button deleteButton;

        Task task = new Task();

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myTasksDB.db3");

        public DeleteTaskPage()
        {
            this.Title = "Elimina una tarea";

            var dataBase = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = dataBase.Table<Task>().OrderBy(t => t.task_date).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            deleteButton = new Button();
            deleteButton.Text = "Eliminar tarea";
            deleteButton.Clicked += DeleteButton_Clicked;
            stackLayout.Children.Add(deleteButton);

            Content = stackLayout;
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var dataBase = new SQLiteConnection(dbPath);
            dataBase.Table<Task>().Delete(t => t.Id == task.Id);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            task = (Task)e.SelectedItem;
        }
    }
}