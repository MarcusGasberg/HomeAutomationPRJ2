using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationLibrary
{
    public class AppAction
    {
        #region Private Attributes
        private bool selectedDimmer_;
        private bool selectedOnOff_;
        #endregion
        #region Public Methods
        /// <summary>
        /// function to see if Apparat has dimmer selected 
        /// </summary>
        public bool SelectedDimmer
        {
            get { return selectedDimmer_; }
            set { selectedDimmer_ = value; }
        }

        /// <summary>
        /// function to see if Apparat has OnOff selected 
        /// </summary>
        public bool SelectedOnOff
        {
            get { return selectedOnOff_; }
            set { selectedOnOff_ = value; }
        }
        #endregion
        #region Constructor
        public AppAction(Apparat selected)
        {
            if((selected.Functionality & Func.OnOff) == Func.OnOff)
            {
                selectedOnOff_ = true;
            }
            if ((selected.Functionality & Func.Dimmer) == Func.Dimmer)
            {
                selectedDimmer_ = true;
            }
            
        }
        #endregion
    }
}
