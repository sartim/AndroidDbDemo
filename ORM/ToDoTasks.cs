using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
using SQLite;

namespace AndroidDBDemo.ORM
{
    [Table("ToDoTasks")]

        public class ToDoTasks
        {
            [PrimaryKey, AutoIncrement, Column("id")]
        

            public int Id { get; set; }

            [MaxLength(50)]

            public string Task { get; set; }
        }
    }