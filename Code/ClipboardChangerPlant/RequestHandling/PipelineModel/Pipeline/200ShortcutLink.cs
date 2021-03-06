﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ClipboardChangerPlant.Shortening;

using JetBrains.Annotations;

#endregion

namespace ClipboardChangerPlant.RequestHandling.PipelineModel.Pipeline
{
  [UsedImplicitly]
  public class ShortcutLink : Processor
  {
    #region Public Methods and Operators

    public override void Process(ProcessorArgs args)
    {
      if (!args.ShouldBeShorted && !args.OnlyShorteningRequired)
      {
        return;
      }
      string outputString;
      if (!ShortenerManager.TryShorterUrl(args.ResultUrl, out outputString))
      {
        this.HandleErrorAndAbortPipeline(args, this.ErrorTrayIcon);
      }
      else
      {
        args.ResultUrl = outputString;
      }
    }

    #endregion
  }
}