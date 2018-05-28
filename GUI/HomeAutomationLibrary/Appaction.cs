
namespace HomeAutomationLibrary
{
    public class AppAction
    {
        #region Private Attributes
        private int selectedDimmerValue_ = 0;
        private bool selectedDimmer_;
        private bool selectedOnOff_;
        #endregion
        #region Public Methods
        /// <summary>
        /// The value of the dimmer of the selected apparat
        /// </summary>
        public int SelectedDimmerValue{ get => selectedDimmerValue_; set => selectedDimmerValue_ = value; }
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
        /// <summary>
        /// The constructor which takes the selected apparat and check the functionality
        /// </summary>
        /// <param name="selected">The selected apparat</param>
        public AppAction(Apparat selected)
        {
            if((selected.Functionality & Func.OnOff) == Func.OnOff)
            {
                selectedOnOff_ = true;
            }
            if ((selected.Functionality & Func.Dimmer) == Func.Dimmer)
            {
                selectedDimmer_ = true;
                selectedDimmerValue_ = selected.DimmerValue;
            }
        }
        #endregion
    }
}
