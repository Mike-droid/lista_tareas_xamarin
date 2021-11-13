using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Lista_Tareas
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Selecciona una opción";

            StackLayout stackLayout = new StackLayout();

            Button addTaskButton = new Button();
            addTaskButton.Text = "Agregar tarea";
            addTaskButton.Clicked += AddTask_Clicked;

            stackLayout.Children.Add(addTaskButton);

            Button getTasksButton = new Button();
            getTasksButton.Text = "Mostrar tareas";
            getTasksButton.Clicked += GetTasksButton_Clicked;

            stackLayout.Children.Add(getTasksButton);

            Button editTaskButton = new Button();
            editTaskButton.Text = "Editar tarea";
            editTaskButton.Clicked += EditTaskButton_Clicked;

            stackLayout.Children.Add(editTaskButton);

            Button deleteTaskButton = new Button();
            deleteTaskButton.Text = "Eliminar tarea";
            deleteTaskButton.Clicked += DeleteTaskButton_Clicked;

            stackLayout.Children.Add(deleteTaskButton);

            Content = stackLayout;
        }

        private async void DeleteTaskButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteTaskPage());
        }

        private async void EditTaskButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditTaskPage());
        }

        private async void GetTasksButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetTasksPage());
        }

        private async void AddTask_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage());
        }
    }
}