using SQLite;
using System.IO;
using System;
using Xamarin.Forms;

namespace Lista_Tareas
{
    public class GetTasksPage : ContentPage
    {
        private ListView _listView;
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myTasksDB.db3");
        public GetTasksPage()
        {
            this.Title = "Lista de tareas";

            var dataBase = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = dataBase.Table<Task>().OrderBy(t => t.task_date).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}