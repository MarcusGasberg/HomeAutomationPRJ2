using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationLibrary
{
    public class AppAction
    {
        private bool selectedDimmer_;
        /// <summary>
        /// function to see if Apparat has dimmer selected 
        /// </summary>
        public bool SelectedDimmer
        {
            get { return selectedDimmer_; }
            set { selectedDimmer_ = value; }
        }

        private bool selectedOnOff_;
        /// <summary>
        /// function to see if Apparat has OnOff selected 
        /// </summary>
        public bool SelectedOnOff
        {
            get { return selectedOnOff_; }
            set { selectedOnOff_ = value; }
        }

        public AppAction(Apparat selected)
        {
            if((selected.Functionality_ & Func.OnOff) == Func.OnOff)
            {
                selectedOnOff_ = true;
            }
            if ((selected.Functionality_ & Func.Dimmer) == Func.Dimmer)
            {
                selectedDimmer_ = true;
            }
        }
    }
}
