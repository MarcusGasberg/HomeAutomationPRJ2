using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Enum for the different functionality
/// </summary>
[Flags]
public enum Func
{
    /// <summary>
    /// No functionality
    /// </summary>
    None = 0,
    /// <summary>
    /// On and Off functionality
    /// </summary>
    OnOff = 1<<0,
    /// <summary>
    /// Dimmer functionality
    /// </summary>
    Dimmer = 1<<1,
}

namespace HomeAutomationLibrary
{
    public class Apparat
    {
        #region Private
        private string name_;
        private int port_;
        private string picture_;
        private Func functionality_;
        #endregion
        #region Public Properties
        /// <summary>
        /// The Name of the apparat
        /// </summary>
        public string Name_ { get => name_; set => name_ = value; }
        /// <summary>
        /// The port which the apparat is connected to
        /// </summary>
        public int Port_ { get => port_; set => port_ = (value>0 && value<4 ? value : 0); }
        /// <summary>
        /// The icon path for the apparat
        /// </summary>
        public string Picture_ { get => picture_; set => picture_ = value; }
        /// <summary>
        /// The functionality of the apparat
        /// </summary>
        public Func Functionality_ { get => functionality_; set => functionality_ = (value == Func.OnOff || value == Func.Dimmer ? value : Func.OnOff); }
        #endregion
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Apparat()
        {
            Name_ = "DummyApparat";
            Port_ = 0;
            Functionality_ = Func.OnOff;
        }
        /// <summary>
        /// Parametrized Constructor
        /// </summary>
        /// <param name="name">Navn på apparatet</param>
        /// <param name="port">Port på apparatet</param>
        /// <param name="func">Funktionalitet på apparatet</param>
        public Apparat(string name, int port, Func func)
        {
            Name_ = name;
            Port_ = port;
            Functionality_ = func;
        }
        #endregion
    }
}
