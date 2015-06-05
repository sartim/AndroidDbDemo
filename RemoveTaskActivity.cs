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
    [Activity(Label = "RemoveTaskActivity")]
    public class RemoveTaskActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.RemoveTaskLayout);
            Button btnRemove = FindViewById<Button>(Resource.Id.btnDelete);
            btnRemove.Click += btnRemove_Click;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtTaskId = FindViewById<EditText>(Resource.Id.txtTaskID);
            string result = dbr.RemoveTask(int.Parse(txtTaskId.Text));
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }
    }
}