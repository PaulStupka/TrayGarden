﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TrayGarden.Pipelines.Engine;
using TrayGarden.Services.PlantServices.GlobalMenu.Core.UI.ViewModels;
using TrayGarden.TypesHatcher;

#endregion

namespace TrayGarden.Services.PlantServices.GlobalMenu.Core.UI.ResolveSinglePlantVMPipeline
{
  public static class ResolveSinglePlantVMPipelineRunner
  {
    #region Public Methods and Operators

    public static SinglePlantVM Run(ResolveSinglePlantVMPipelineArgs args)
    {
      HatcherGuide<IPipelineManager>.Instance.InvokePipeline("resolveSinglePlantVM", args);
      return !args.Aborted ? args.PlantVM : null;
    }

    #endregion
  }
}