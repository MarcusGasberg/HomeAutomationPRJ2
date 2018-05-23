using System;

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
        private Func functionality_;
        private bool onOff_;
        #endregion
        #region Public Properties
        /// <summary>
        /// The Name of the apparat
        /// </summary>
        public string Name { get => name_; set => name_ = value; }
        /// <summary>
        /// The port which the apparat is connected to
        /// </summary>
        public int Port { get => port_; set => port_ = (value>0 && value<4 ? value : 0); }
        /// <summary>
        /// The functionality of the apparat
        /// </summary>
        public Func Functionality { get => functionality_; set => functionality_ = value; }
        /// <summary>
        /// Bool to keep track of the state of the port
        /// </summary>
        public bool OnOff { get => onOff_; set  => onOff_ = value; }
        #endregion
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Apparat()
        {
            Name = "DummyApparat";
            Port = 0;
            Functionality = Func.OnOff;
            OnOff = false;
        }
        /// <summary>
        /// Parametrized Constructor
        /// </summary>
        /// <param name="name">Navn på apparatet</param>
        /// <param name="port">Port på apparatet</param>
        /// <param name="func">Funktionalitet på apparatet</param>
        public Apparat(string name, int port, Func func)
        {
            Name = name;
            Port = port;
            Functionality = func;
            OnOff = false;
        }

        
        #endregion
    }
}
