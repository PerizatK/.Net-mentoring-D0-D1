using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLIb;

namespace m1t1v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //lName.Text = "Hello," + tName.Text;
                Person person = new Person(tName.Text);
                lNamePerson.Text = "Person: " + person.GetGreetingForName();

                lNamePersonUtils.Text = "PersonUtils: " + PersonUtils.GetGreetingForName(tName.Text);
            }
        }
    }
}
