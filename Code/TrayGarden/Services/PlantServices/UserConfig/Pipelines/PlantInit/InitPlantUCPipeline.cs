﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TrayGarden.Pipelines.Engine;
using TrayGarden.Plants;
using TrayGarden.TypesHatcher;

#endregion

namespace TrayGarden.Services.PlantServices.UserConfig.Pipelines.PlantInit
{
  public class InitPlantUCPipeline
  {
    #region Public Methods and Operators

    public static void Run(string luggageName, IPlantEx relatedPlant)
    {
      var args = new InitPlantUCPipelineArg(luggageName, relatedPlant);
      HatcherGuide<IPipelineManager>.Instance.InvokePipeline("userConfigServiceInitPlant", args);
    }

    #endregion
  }
}