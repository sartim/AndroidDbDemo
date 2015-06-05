using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
using SQLite;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidDBDemo.ORM
{
    public class DBRepository
    {
        //code to create the database

        public string CreateDB()
        {
            var output = "";
            output += "Creating if it doesnt exist.";
            string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            output += "\nDatabase Created...";
            return output;
        }

        //Code to create the table

        public string CreateTable()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<ToDoTasks>();
                string result = "Tablr Created successfully....";
                return result;

            }
            catch(Exception ex)
            {
                return "Error : " + ex.Message; 
            }
        }

        //Code to insert a record
        public string InsertRecord(string task)
        {
            try
            {
            string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            ToDoTasks item = new ToDoTasks();
            item.Task = task;
            db.Insert(item);
            return "Record Added...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }
        
        //Code to retrieve all the records
        public string GetAllRecords()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            string output = "";
            output += "Retrieving ythe ddata using ORM...";
            var table = db.Table<ToDoTasks>();
            foreach (var item in table)
            {
                output += "" + item.Id + " --- " + item.Task;
            }
            return output;
        }

        //Code to retrieve specific record using ORM

        public string GetTaskById(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");

            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTasks>(id);
            return item.Task;
        }

        //code to update the record using ORM
        public string updateRecord(int id, string task)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");

            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTasks>(id);
            item.Task = task;
            db.Update(item);
            return "Record Updated...";
        }
    }
}