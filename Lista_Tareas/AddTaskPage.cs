using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

namespace Lista_Tareas
{
    public class AddTaskPage : ContentPage
    {
        private Entry _task_name_entry;
        private DatePicker _date_task_entry;
        private Button _saveButton;

        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myTasksDB.db3");
        public AddTaskPage()
        {
            this.Title = "Crea una nueva tarea";

            StackLayout stackLayout = new StackLayout();

            _task_name_entry = new Entry();
            _task_name_entry.Keyboard = Keyboard.Text;
            _task_name_entry.Placeholder = "Tarea";

            stackLayout.Children.Add(_task_name_entry);

            _date_task_entry = new DatePicker();
            _date_task_entry.MinimumDate = DateTime.Now;

            stackLayout.Children.Add(_date_task_entry);

            _saveButton = new Button();
            _saveButton.Text = "Guardar tarea";
            _saveButton.Clicked += _saveButton_Clicked;

            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var dataBase = new SQLiteConnection(dbPath);
            dataBase.CreateTable<Task>();

            var maxPrimaryKey = dataBase.Table<Task>().OrderByDescending(t => t.Id).FirstOrDefault();

            Task task = new Task()
            {
                Id = (maxPrimaryKey == null ? 1 : maxPrimaryKey.Id + 1),
                task_name = _task_name_entry.Text,
                task_date = _date_task_entry.Date
            };

            dataBase.Insert(task);
            await DisplayAlert(null, $"Tarea {task.Id} agregada", "Ok");
            await Navigation.PopAsync();
        }
    }
}