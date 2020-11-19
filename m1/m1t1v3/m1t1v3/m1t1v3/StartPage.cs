using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using MyLIb;

namespace m1t1v3
{
    public class StartPage : ContentPage
    {
        Label lName1, lName2;
        Entry nameEntry;
        public StartPage()
        {
            StackLayout stackLayout = new StackLayout();

            lName1 = new Label { Text = "Enter your name here" }; 

            nameEntry = new Entry { Text = "" };
            nameEntry.Completed += nameEntry_Completed;

            lName2 = new Label { Text = "", TextColor = Color.Red };

            stackLayout.Children.Add(lName1);
            stackLayout.Children.Add(nameEntry);
            stackLayout.Children.Add(lName2);

            this.Content = stackLayout;
        }

        private void nameEntry_Completed(object sender, EventArgs e)
        {
            //lName2.Text = "Hello, " + nameEntry.Text;
            Person person = new Person(nameEntry.Text);
            lName2.Text = person.GetGreetingForName();

        }

    }
}