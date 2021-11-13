using SQLite;
using System;

namespace Lista_Tareas
{
    public class Task
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string task_name { get; set; }
        public DateTime task_date { get; set; }

        public override string ToString()
        {
            return $"{task_name} - Fecha límite {task_date}";
        }
    }
}
