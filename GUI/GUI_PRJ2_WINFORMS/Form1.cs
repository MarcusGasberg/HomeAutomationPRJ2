using HomeAutomationLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace GUI_PRJ2_WINFORMS
{
    public partial class Form1 : Form
    {
        private List<Apparat> availableApparats = new List<Apparat>();
        private int currentApparatPort = 0;
        private Func currentApparatFunc = Func.OnOff;

        public Form1()
        {
            InitializeComponent();

            //Sets up dummy data
            SetupData();

            //Sets up list view
            SetupListView(listView1);

            //Populate the Combobox with SerialPorts on the System
            comboBox_available_serialPorts.Items.AddRange(SerialPort.GetPortNames());

            //Disable the apparatlist group
            apparatsGroup.Enabled = false;
        }
        
        /// <summary>
        /// Function for setup of listview with use of helper class<see cref="ListViewExtender"/>
        /// <paramref name="listViewToSetup">The listview to setup</paramref>
        /// </summary>
        private void SetupListView(ListView listViewToSetup)
        {
            listViewToSetup.FullRowSelect = true;
            //Create extender
            ListViewExtender extender = new ListViewExtender(listViewToSetup);
            // extend 2nd column
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(1);
            //Add action for button
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;
            //Add column with dummy data
            extender.AddColumn(buttonAction);
            //Update listview
            UpdateListView(listViewToSetup);
        }

        /// <summary>
        /// Function for updating a listview
        /// </summary>
        /// <param name="listView2Update">The list view to update</param>
        private void UpdateListView(ListView listView2Update)
        {
            //Delete existing listview items
            if (availableApparats.Count != 0)
            {
                for (int i = 0; i < listView2Update.Items.Count; i++)
                {
                    listView2Update.Items[i].Remove();
                    i--;
                }
            }

            //Add new items
            for (int i = 0; i < availableApparats.Count; i++)
            {
                ListViewItem item = listView2Update.Items.Add(availableApparats[i].Name_);
                item.SubItems.Add(availableApparats[i].Port_.ToString());
            }

        }
        /// <summary>
        /// Private helper method for list view button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            currentApparatPort = e.Item.Index;
            AppAction current = new AppAction(availableApparats[e.Item.Index]);
            currentApparatPort = availableApparats[e.Item.Index].Port_;
            currentApparatFunc = availableApparats[e.Item.Index].Functionality_;
            if (current.SelectedOnOff)
            {
                onOffButton.Visible = true;
                onOffButton.Enabled = true;
            }
            else
            {
                onOffButton.Visible = false;
                onOffButton.Enabled = false;
            }
            if (current.SelectedDimmer)
            {
                dimmer.Visible = true;
                dimmer.Enabled = true;
                dimmerText.Visible = true;
            }
            else
            {
                dimmer.Visible = false;
                dimmer.Enabled = false;
                dimmerText.Visible = false;
            }
            ApparatMenu.Enabled = false;
            AddMenu.Enabled = false;
            Settings.Enabled = true;
            mainView.SelectTab(Settings);
        }
        /// <summary>
        /// Sets up dummy data
        /// </summary>
        private void SetupData()
        {
            //Add default object as dummy data
            availableApparats.Add(new Apparat());
        }
        

        private void AddApparat_Click(object sender, EventArgs e)
        {
            //Change page to AddMenu
            mainView.SelectTab(AddMenu);
            ApparatMenu.Enabled = false;
            Settings.Enabled = false;
            AddMenu.Enabled = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            //Change page to ApparatMenu
            mainView.SelectTab(ApparatMenu);
            ApparatMenu.Enabled = true;
            AddMenu.Enabled = false;
            Settings.Enabled = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Create new apparat
            Apparat apparatToAdd = new Apparat();
            //Set name to the text of apparatNameTextbox
            apparatToAdd.Name_ = (!string.IsNullOrEmpty(apparatNameTextbox.Text) ? apparatNameTextbox.Text : "Unknown");
            
            //Set functionality of the apparat
            foreach (object indexChecked in functionalityCheckBox.CheckedIndices)
            {
                apparatToAdd.Functionality_ |= (Func)((int)indexChecked + 1);
            }

            //Set Port to the port chosen
            apparatToAdd.Port_ = portComboBox.SelectedIndex;

            //If the port chosen already exist
            if (availableApparats.Exists(x => x.Port_ == portComboBox.SelectedIndex))
            {
                //Replace the apparat
                int index = availableApparats.FindIndex(x => x.Port_ == portComboBox.SelectedIndex);
                availableApparats[index] = apparatToAdd;
            }
            else
            {
                //Else add new apparat
                availableApparats.Add(apparatToAdd);
            }
            //update listview
            UpdateListView(listView1);
            //change page to apparat menu
            mainView.SelectTab(ApparatMenu);
            ApparatMenu.Enabled = true;
            AddMenu.Enabled = false;
            Settings.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Disable other pages
            AddMenu.Enabled = false;
            Settings.Enabled = false;
            //Add necessary columns to the listview for the listview extender to work
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Port", 60);
            //Set the selected index of the port
            portComboBox.SelectedIndex = 0;
            //Disable baudrate selection
            comboBox_baudRate.Enabled = false;
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void OnOffButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Open Serial port
                serialPort1.Open();
            }
            #region Exceptions
            catch(UnauthorizedAccessException SerialException)
            {
                //Exception for when the operating system denies access
                MessageBox.Show(SerialException.ToString());
                serialPort1.Close();
            }
            catch(System.IO.IOException SerialException)
            {
                //An attempt to set the state of the underlying port failed
                MessageBox.Show(SerialException.ToString());
                serialPort1.Close();
            }
            catch(InvalidOperationException SerialException)
            {
                //The specified port on the current instance of the SerialPort is already open
                MessageBox.Show(SerialException.ToString());
                serialPort1.Close();
            }
            catch
            {
                MessageBox.Show("ERROR in opening SerialPort - Unknown ERROR");
                serialPort1.Close();
            }
            #endregion

            if (serialPort1.IsOpen)
            {
                //FIND OUT HOW TO CREATE THE CODE TO SEND
                //FIND OUT HOW TO CREATE THE CODE TO SEND
                string Data = (currentApparatFunc & Func.OnOff).ToString() + currentApparatPort.ToString();
                //FIND OUT HOW TO CREATE THE CODE TO SEND
                //FIND OUT HOW TO CREATE THE CODE TO SEND

                //Send data
                serialPort1.WriteLine(Data);
                serialPort1.Close();
            }

        }

        //FIND OUT WHAT TO DO WITH BUTTON AFTER IT HAS TURNED ON
        //FIND OUT WHAT TO DO WITH BUTTON AFTER IT HAS TURNED ON
        //FIND OUT WHAT TO DO WITH BUTTON AFTER IT HAS TURNED ON



        private void dimmer_Scroll(object sender, EventArgs e)
        {

            try
            {
                //Open Serial port
                serialPort1.Open();
            }
            #region Exceptions
            catch (UnauthorizedAccessException SerialException)
            {
                //Exception for when the operating system denies access
                MessageBox.Show(SerialException.ToString());
                serialPort1.Close();
            }
            catch (System.IO.IOException SerialException)
            {
                //An attempt to set the state of the underlying port failed
                MessageBox.Show(SerialException.ToString());
                serialPort1.Close();
            }
            catch (InvalidOperationException SerialException)
            {
                //The specified port on the current instance of the SerialPort is already open
                MessageBox.Show(SerialException.ToString());
                serialPort1.Close();
            }
            catch
            {
                MessageBox.Show("ERROR in opening SerialPort - Unknown ERROR");
                serialPort1.Close();
            }
            #endregion

            if (serialPort1.IsOpen)
            {
                //FIND OUT HOW TO CREATE THE CODE TO SEND
                //FIND OUT HOW TO CREATE THE CODE TO SEND
                string Data = (currentApparatFunc & Func.Dimmer).ToString() + currentApparatPort.ToString();
                //FIND OUT HOW TO CREATE THE CODE TO SEND
                //FIND OUT HOW TO CREATE THE CODE TO SEND

                //Send data
                serialPort1.WriteLine(Data);
                serialPort1.Close();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Foreach selected item in listview1: Delete
            foreach(ListViewItem selected in listView1.SelectedItems)
            {
                availableApparats.RemoveAt(selected.Index);
                selected.Remove();
            }
        }

        private void comboBox_available_serialPorts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Sets the portName
            serialPort1.PortName = comboBox_available_serialPorts.SelectedItem.ToString();
            //Enable baudrate to be set
            comboBox_baudRate.Enabled = true;
        }

        private void comboBox_baudRate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Sets the baudrate of serialPort1
            serialPort1.BaudRate = Convert.ToInt32(comboBox_baudRate.SelectedItem.ToString());
            //Enable apparats after baud rate is chosen
            apparatsGroup.Enabled = true;
        }
    }
}
