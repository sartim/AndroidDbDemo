using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AndroidDBDemo.ORM;

namespace AndroidDBDemo
{
    [Activity(Label = "AndroidDBDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Home);

            // Create the database
            Button btnCreateDB = FindViewById<Button>(Resource.Id.btnCreateDB);
            btnCreateDB.Click += btnCreateDB_Click;

            // To create the table
            Button btnCreateTable = FindViewById<Button>(Resource.Id.btnCreateTable);
            btnCreateTable.Click += btnCreateTable_Click;

            //To Insert the record
            Button btnAddRecord = FindViewById<Button>(Resource.Id.btnInsert);
            btnAddRecord.Click += btnAddRecord_Click;

            //To retrieve the data
            Button btnGetAll = FindViewById<Button>(Resource.Id.btnGetData);
            btnGetAll.Click += btnGetAll_Click;

            //To retrieve specific Record
            Button btnGetById = FindViewById<Button>(Resource.Id.btnGetDataById);
            btnGetById.Click += btnGetById_Click;

            //To update Record
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnUpdate.Click += btnUpdate_Click;

            // to Delete the record
            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnDelete.Click += btnDelete_Click;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(UpdateTaskActivity));
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SearchActivity));
        }

        void btnGetAll_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.GetAllRecords();

            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        void btnAddRecord_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InsertTaskActivity));
        }

        void btnCreateTable_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateTable();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        void btnCreateDB_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateDB();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }
    }
}

