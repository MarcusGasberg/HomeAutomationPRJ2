using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace HomeAutomationLibrary
{
    public class SerialCom
    {
        #region Private Fields

        private SerialPort serial_;

        #endregion
        #region Public Attribute
        /// <summary>
        /// The Serial Port used for communication
        /// </summary>
        public SerialPort Serial
        {
            get { return serial_; }
            set { serial_ = value; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor for the serial communicaiton
        /// </summary>
        /// <param name="serial"> The serial port</param>
        public SerialCom(SerialPort serial)
        {
            serial_ = serial;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Method for Dimming A Light/Lowering the current
        /// </summary>
        /// <param name="port">The port of the apparat</param>
        /// <param name="bar">The index of the sliding bar, 0=20%, 1=40%,...</param>
        public string Dimm(int port, int bar)
        {
            try
            {
                //Open Serial port
                serial_.Open();
            }
            #region Exceptions
            catch (UnauthorizedAccessException SerialException)
            {
                //Exception for when the operating system denies access
                MessageBox.Show(SerialException.ToString());
                serial_.Close();
            }
            catch (System.IO.IOException SerialException)
            {
                //An attempt to set the state of the underlying port failed
                MessageBox.Show(SerialException.ToString());
                serial_.Close();
            }
            catch (InvalidOperationException SerialException)
            {
                //The specified port on the current instance of the SerialPort is already open
                MessageBox.Show(SerialException.ToString());
                serial_.Close();
            }
            catch
            {
                MessageBox.Show("ERROR in opening SerialPort - Unknown ERROR");
                serial_.Close();
            }
            #endregion

            if (serial_.IsOpen)
            {
                //Set the data address from the port
                string dataAddress = (port < 10 ? "0" + port.ToString() : port.ToString());
                string dataFunc = "00"; //Default to turn off
                switch (bar)
                {
                    case 0:
                        dataFunc = "02"; //20% on
                        break;
                    case 1:
                        dataFunc = "03"; //40% on
                        break;
                    case 2:
                        dataFunc = "04"; //60% on
                        break;
                    case 3:
                        dataFunc = "05"; //80% on
                        break;
                    case 4:
                        dataFunc = "01"; //100% on / TurnOn code
                        break;
                    default:
                        break;
                }
                //Create Data string to be sent
                string data = dataAddress + dataFunc;

                //Send data
                serial_.WriteLine(data);
                serial_.Close();
                return data;
            }
            return null;
        }
        /// <summary>
        /// The method for turning the apparat on and off
        /// </summary>
        /// <param name="port">The port of the apparat</param>
        /// <param name="isOn">The state of the apparat (On/Off)</param>
        public string OnOff(int port, bool isOn)
        {
            
            //Add this to a SerialCom Class
            try
            {
                //Open Serial port
                serial_.Open();
            }
            #region Exceptions
            catch (UnauthorizedAccessException SerialException)
            {
                //Exception for when the operating system denies access
                MessageBox.Show(SerialException.ToString());
                serial_.Close();
            }
            catch (System.IO.IOException SerialException)
            {
                //An attempt to set the state of the underlying port failed
                MessageBox.Show(SerialException.ToString());
                serial_.Close();
            }
            catch (InvalidOperationException SerialException)
            {
                //The specified port on the current instance of the SerialPort is already open
                MessageBox.Show(SerialException.ToString());
                serial_.Close();
            }
            catch
            {
                MessageBox.Show("ERROR in opening SerialPort - Unknown ERROR");
                serial_.Close();
            }
            #endregion

            if (serial_.IsOpen)
            {
                //Set the data address from the port
                string dataAddress = (port < 10 ? "0" + port.ToString() : port.ToString());
                string dataFunc = (isOn ? "00" : "01");
                string data = dataAddress + dataFunc;
                //Send data
                serial_.WriteLine(data);
                serial_.Close();
                return data;
            }
            return null;
        }

        #endregion
    }
}
