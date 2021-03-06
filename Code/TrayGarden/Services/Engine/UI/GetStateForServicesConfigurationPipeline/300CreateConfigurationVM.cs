﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JetBrains.Annotations;

using TrayGarden.Diagnostics;
using TrayGarden.UI.Configuration;
using TrayGarden.UI.ForSimplerLife;

#endregion

namespace TrayGarden.Services.Engine.UI.GetStateForServicesConfigurationPipeline
{
  [UsedImplicitly]
  public class CreateConfigurationVM
  {
    #region Constructors and Destructors

    public CreateConfigurationVM()
    {
      this.ConfigurationDescription =
        "This window allows to enable or disable the particular plant service. Pay attention that some services cannot be disabled. You have to restart application to apply changes";
    }

    #endregion

    #region Public Properties

    public string ConfigurationDescription { get; set; }

    #endregion

    #region Public Methods and Operators

    [UsedImplicitly]
    public virtual void Process([NotNull] GetStateForServicesConfigurationPipelineArgs args)
    {
      ConfigurationControlConstructInfo configConstructInfo = args.ConfigConstructInfo;
      Assert.ArgumentNotNull(configConstructInfo.ConfigurationEntries, "args.ConfigConstructInfo.ConfigurationEntries");
      configConstructInfo.ResultControlVM = new ConfigurationControlVM(
        configConstructInfo.ConfigurationEntries,
        configConstructInfo.EnableResetAllOption)
                                              {
                                                ConfigurationDescription = this.ConfigurationDescription,
                                                CalculateRebootOption = configConstructInfo.AllowReboot
                                              };
    }

    #endregion
  }
}