using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Lista_Tareas
{
    public class EditTaskPage : ContentPage
    {

        private ListView _listView;
        private Entry _idEntry;
        private Entry _task_name_entry;
        private DatePicker _date_task_entry;
        private Button _editButton;

        Task task = new Task();

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myTasksDB.db3");

        public EditTaskPage()
        {
            this.Title = "Edita una tarea";

            var dataBase = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = dataBase.Table<Task>().OrderBy(t => t.task_date).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _task_name_entry = new Entry();
            _task_name_entry.Keyboard = Keyboard.Text;
            _task_name_entry.Placeholder = "Tarea";
            stackLayout.Children.Add(_task_name_entry);

            _date_task_entry = new DatePicker();
            _date_task_entry.MinimumDate = DateTime.Now;
            stackLayout.Children.Add(_date_task_entry);

            _editButton = new Button();
            _editButton.Text = "Actualizar tarea";
            _editButton.Clicked += _editButton_Clicked;
            stackLayout.Children.Add(_editButton);

            Content = stackLayout;

        }

        private async void _editButton_Clicked(object sender, EventArgs e)
        {
            var dataBase = new SQLiteConnection(dbPath);
            Task task = new Task()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                task_name = _task_name_entry.Text,
                task_date = _date_task_entry.Date
            };
            dataBase.Update(task);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            task = (Task)e.SelectedItem;
            _idEntry.Text = task.Id.ToString();
            _task_name_entry.Text = task.task_name;
            _date_task_entry.Date = task.task_date;
        }
    }
}