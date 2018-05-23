using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeAutomationLibrary
{
    public class SerialCom
    {
        private SerialPort serial_;

        public SerialPort Serial
        {
            get { return serial_; }
            set { serial_ = value; }
        }


        public SerialCom(SerialPort serial)
        {
            serial_ = serial;
        }

        public void dimm(int port, int bar)
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
                string DataAddress = (port < 10 ? "0" + port.ToString() : port.ToString());
                string DataFunc = "00"; //Default to turn off
                switch (bar)
                {
                    case 0:
                        DataFunc = "02"; //20% on
                        break;
                    case 1:
                        DataFunc = "03"; //40% on
                        break;
                    case 2:
                        DataFunc = "04"; //60% on
                        break;
                    case 3:
                        DataFunc = "05"; //80% on
                        break;
                    case 4:
                        DataFunc = "01"; //100% on / TurnOn code
                        break;
                    default:
                        break;
                }
                string Data = DataAddress + DataFunc;

                //Send data
                serial_.WriteLine(Data);
                serial_.Close();
            }
        }

        public void onOff(int port, bool isOn)
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
                string DataAddress = (port < 10 ? "0" + port.ToString() : port.ToString());
                string DataFunc = (isOn ? "00" : "01");
                string Data = DataAddress + DataFunc;
                //Send data
                serial_.WriteLine(Data);
                serial_.Close();
            }
        }
    }
}
