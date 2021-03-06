﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JetBrains.Annotations;

#endregion

namespace TrayGarden.Services.PlantServices.GlobalMenu.Core.InitPlantPipeline
{
  [UsedImplicitly]
  public class BindPlantBoxToPlant
  {
    #region Public Methods and Operators

    [UsedImplicitly]
    public virtual void Process(InitPlantGMArgs args)
    {
      if (!(args.IsAdvancedMenuExtendingInUse || args.IsMenuExtendingInUse || args.IsNotifyIconChangerInUse))
      {
        args.Abort();
        return;
      }
      GlobalMenuPlantBox globalMenuPlantBox = args.GMBox;
      globalMenuPlantBox.RelatedPlantEx = args.PlantEx;
      globalMenuPlantBox.RelatedPlantEx.PutLuggage(args.LuggageName, globalMenuPlantBox);
    }

    #endregion
  }
}