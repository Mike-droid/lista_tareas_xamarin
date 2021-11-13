using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

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
            return $"{this.task_name} - Fecha límite: {this.task_date}";
        }
    }
}
