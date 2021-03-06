﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TrayGarden.Pipelines.Engine;
using TrayGarden.UI.Configuration.EntryVM;
using TrayGarden.UI.ForSimplerLife;

#endregion

namespace TrayGarden.Services.PlantServices.UserNotifications.Core.Configuration.UIInteraction.GetStepPipeline
{
  public class UNConfigurationStepArgs : PipelineArgs
  {
    #region Constructors and Destructors

    public UNConfigurationStepArgs()
    {
      this.StateConstructInfo = new WindowWithBackStateConstructInfo();
      this.ConfigurationConstructInfo = new ConfigurationControlConstructInfo()
                                          {
                                            ConfigurationEntries =
                                              new List<ConfigurationEntryBaseVM>()
                                          };
    }

    #endregion

    #region Public Properties

    public ConfigurationControlConstructInfo ConfigurationConstructInfo { get; set; }

    public WindowWithBackStateConstructInfo StateConstructInfo { get; set; }

    #endregion
  }
}