using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidDBDemo.ORM;

namespace AndroidDBDemo
{
    [Activity(Label = "UpdateTaskActivity")]
    public class UpdateTaskActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.UpdateTaskLayout);

            Button btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnSearch.Click += btnSearch_Click;

            // CUpdate Button_click

            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnUpdate.Click += btnUpdate_Click;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskID);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            DBRepository dbr = new DBRepository();

            string result = dbr.updateRecord(int.Parse(txtId.Text), txtTask.Text);
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskID);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            txtTask.Text = dbr.GetTaskById(int.Parse(txtId.Text));
        }
    }
}