using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationLibrary
{
    public enum ApplicationPage
    {
        /// <summary>
        /// The Main Page with apparats and serial com settings
        /// </summary>
        ApparatMenu = 0,
        /// <summary>
        /// The Page which contains the settings of the apparat
        /// </summary>
        ApparatSettings = 1,
        /// <summary>
        /// The page to add a new apparat to the list of apparats
        /// </summary>
        AddApparat = 2,
    }
}
