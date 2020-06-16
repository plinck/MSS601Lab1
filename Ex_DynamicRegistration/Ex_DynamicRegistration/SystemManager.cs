//-----------------------------------------------------------------------
// <copyright file="SystemManager.cs" company="Crestron">
//     Copyright (c) Crestron Electronics. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crestron.SimplSharp;                       // For Basic SIMPL# Classes
using Crestron.SimplSharp.CrestronIO;            // For Directory
using Crestron.SimplSharpPro;                    // For Basic SIMPL#Pro classes
using Crestron.SimplSharpPro.CrestronThread;     // For Threading
using Crestron.SimplSharpPro.DeviceSupport;      // For Generic Device Support
using Crestron.SimplSharpPro.Diagnostics;        // For System Monitor Access
using Crestron.SimplSharpPro.UI;
using Ex_DynamicRegistration.UI;

namespace Ex_DynamicRegistration
{
    /// <summary>
    /// Used to manage all the different subsystems
    /// </summary>
    public class SystemManager
    {
        private const string LogHeader = "[MSS601Room1] ";

        /// <summary>
        /// Keeps track of all the touchpanels that are registered
        /// </summary>
        private Dictionary<string, BasicTriListWithSmartObject> touchpanels;

        /// <summary>
        /// TouchpanelUI object to use for registration
        /// </summary>
        private UI.TouchpanelUI tp;

        /// <summary>
        /// Initializes a new instance of the SystemManager class
        /// </summary>
        /// <param name="config">full config data</param>
        /// <param name="cs">CrestronControlSystem</param>
        public SystemManager(Configuration.ConfigData.Configuration config, CrestronControlSystem cs)
        {
            if (config.Touchpanels != null)
            {
                this.touchpanels = new Dictionary<string, BasicTriListWithSmartObject>();
                
                // TODO: Level1. Implement touchPanel + sources + destinations
                foreach (var touchPanel in config.Touchpanels)
                {
                    // TODO: Level1. Create new instance of TouchpanelUI
                    // ! Don't forget to use Register() from TouchpanelUI class !
                    string type = touchPanel.Type;
                    uint id = touchPanel.Id;
                    string label = touchPanel.Label;

                    this.tp = new TouchpanelUI(type, id, label, cs);
                    if (this.tp.Register())
                    {
                        ErrorLog.Info($"{LogHeader} created and registered tp {label}");
                    }
                    else
                    {
                        ErrorLog.Error($"{LogHeader} Error created and registering tp {label}");
                    }

                    // TODO: Level1. Dynamically set up sources using the config file

                    // TODO: Level1. Dynamically set up destinations using the config file

                    // TODO: Level2. Implement the additional subsystem dynamically.
                    // Please see Student Guide for more explanation.
                }
            }
        }
    }//class
}
