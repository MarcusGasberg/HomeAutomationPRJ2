using HomeAutomationLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_PRJ2_WINFORMS
{
    public partial class Form1 : Form
    {
        private List<Apparat> myApparats = new List<Apparat>();
        
        public Form1()
        {
            InitializeComponent();
            //Sets up dummy data
            SetupData();
            //Sets up list view
            SetupListView(listView1);
        }
        
        /// <summary>
        /// Function for setup of listview with use of helper class<see cref="ListViewExtender"/>
        /// <paramref name="listViewToSetup">The listview to setup</paramref>
        /// </summary>
        private void SetupListView(ListView listViewToSetup)
        {
            listViewToSetup.FullRowSelect = true;
            //Kald af extender methods
            ListViewExtender extender = new ListViewExtender(listViewToSetup);
            // extend 2nd column
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(1);
            //Tilfoej Action
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;
            //Tilfoej column med dummy data
            extender.AddColumn(buttonAction);
            //Opdater Listview
            UpdateListView(listViewToSetup);
        }

        /// <summary>
        /// Function for updating a listview
        /// </summary>
        /// <param name="listView2Update">The list view to update</param>
        private void UpdateListView(ListView listView2Update)
        {
            //Delete existing listview items
            for (int i = 0; i < listView2Update.Items.Count; i++)
            {
                listView2Update.Items[i].Remove();
                i--;
            }

            //Add new items
            for (int i = 0; i < myApparats.Count; i++)
            {
                ListViewItem item = listView2Update.Items.Add(myApparats[i].Name_);
                item.SubItems.Add(myApparats[i].Port_.ToString());
            }

        }
        /// <summary>
        /// Private helper method for list view button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            MessageBox.Show(this, @"you clicked " + e.SubItem.Text);
        }
        /// <summary>
        /// Sets up dummy data
        /// </summary>
        private void SetupData()
        {
            //Add default object as dummy data
            myApparats.Add(new Apparat());
        }
        

        private void AddApparat_Click(object sender, EventArgs e)
        {
            //Change page to AddMenu
            MainView.SelectTab(AddMenu);
            ApparatMenu.Enabled = false;
            AddMenu.Enabled = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            //Change page to ApparatMenu
            MainView.SelectTab(ApparatMenu);
            ApparatMenu.Enabled = true;
            AddMenu.Enabled = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Create new apparat
            Apparat apparatToAdd = new Apparat();
            //Set Navn til Teksten af apparatNameTextbox
            apparatToAdd.Name_ = apparatNameTextbox.Text;
            //Set Port til porten der er valgt
            apparatToAdd.Port_ = portComboBox.SelectedIndex + 1;
            //Set
            foreach (object indexChecked in functionalityCheckBox.CheckedIndices)
            {
                apparatToAdd.Functionality_ |= (Func)indexChecked;
            }
            //Tilfoej det nye apparat
            myApparats.Add(apparatToAdd);
            //Opdater listview
            UpdateListView(listView1);
            //Skift side tilbage til MainView
            MainView.SelectTab(ApparatMenu);
            ApparatMenu.Enabled = true;
            AddMenu.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Add necessary columns to the listview for the listview extender to work
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Port", 60);
            //Set the selected index of the port
            portComboBox.SelectedIndex = 0;

        }
    }
}
