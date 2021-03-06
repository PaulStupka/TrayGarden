﻿#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using ClipboardChangerPlant.NotificationIcon;

#endregion

namespace ClipboardChangerPlant.RequestHandling.PipelineModel
{
  public class Processor
  {
    #region Properties

    protected virtual Icon ErrorTrayIcon
    {
      get
      {
        return NotifyIconManager.ActualManager.ErrorTrayIcon;
      }
    }

    protected virtual Icon NotFoundTrayIcon
    {
      get
      {
        return NotifyIconManager.ActualManager.NotFoundTrayIcon;
      }
    }

    protected virtual Icon SuccessTrayIcon
    {
      get
      {
        return NotifyIconManager.ActualManager.SuccessTrayIcon;
      }
    }

    #endregion

    #region Public Methods and Operators

    public virtual void Process(ProcessorArgs args)
    {
    }

    #endregion

    #region Methods

    protected virtual void HandleErrorAndAbortPipeline(ProcessorArgs args, Icon errorIcon)
    {
      args.CurrentNotifyIconChangerClient.SetIcon(errorIcon);
      args.Abort();
    }

    protected virtual void HandleErrorAndAbortPipeline(ProcessorArgs args)
    {
      this.HandleErrorAndAbortPipeline(args, this.ErrorTrayIcon);
    }

    #endregion
  }
}