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
            SetupListView();
        }
        
        /// <summary>
        /// Funktion til setup af listview ved brug af hjælper klasse <see cref="ListViewExtender"/>
        /// </summary>
        private void SetupListView()
        {
            listView1.FullRowSelect = true;
            //Kald af extender methods
            ListViewExtender extender = new ListViewExtender(listView1);
            // extend 2nd column
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(1);
            //Tilfoej Action
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;
            //Tilfoej column med dummy data
            extender.AddColumn(buttonAction);
            //Opdater Listview
            updateListView(listView1);
        }

        /// <summary>
        /// Funktion til at opdatere et listview
        /// </summary>
        /// <param name="listView2Update">Listviewet der skal opdateres</param>
        private void updateListView(ListView listView2Update)
        {
            //Slet eksisterende listview items
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView2Update.Items[i].Remove();
                i--;
            }

            //Tilfoej apparater
            for (int i = 0; i < myApparats.Count; i++)
            {
                ListViewItem item = listView2Update.Items.Add(myApparats[i].Navn_);
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
            //Add default objekt som dummy data
            myApparats.Add(new Apparat());
        }
        

        private void addApparat_Click(object sender, EventArgs e)
        {
            //Skift side til AddMenu
            MainView.SelectTab(AddMenu);
            ApparatMenu.Enabled = false;
            AddMenu.Enabled = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            //Skift side til ApparatMenu
            MainView.SelectTab(ApparatMenu);
            ApparatMenu.Enabled = true;
            AddMenu.Enabled = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Create new apparat
            Apparat apparatToAdd = new Apparat();
            //Set Navn til Teksten af apparatNameTextbox
            apparatToAdd.Navn_ = apparatNameTextbox.Text;
            //Set Port til porten der er valgt
            apparatToAdd.Port_ = ++portComboBox.SelectedIndex;
            //Tilfoej den valgte funktionalitet
            foreach(object indexChecked in functionalityCheckBox.CheckedIndices)
            {
                apparatToAdd.Funktionalitet_ |= (Func)indexChecked;
            }
            //Tilfoej det nye apparat
            myApparats.Add(apparatToAdd);
            //Opdater listview
            updateListView(listView1);
            //Skift side tilbage til MainView
            MainView.SelectTab(ApparatMenu);
            ApparatMenu.Enabled = true;
            AddMenu.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
