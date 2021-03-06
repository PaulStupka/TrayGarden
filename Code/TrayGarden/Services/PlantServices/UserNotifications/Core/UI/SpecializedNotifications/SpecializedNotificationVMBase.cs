﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

using TrayGarden.Services.PlantServices.UserNotifications.Core.UI.ResultDelivering;
using TrayGarden.UI.Common.VMtoVMapping;

#endregion

namespace TrayGarden.Services.PlantServices.UserNotifications.Core.UI.SpecializedNotifications
{
  public class SpecializedNotificationVMBase : IResultProvider, ISelfViewResolver
  {
    #region Public Events

    public event EventHandler<ResultObtainedEventArgs> ResultObtained;

    #endregion

    #region Public Properties

    public NotificationResult Result { get; protected set; }

    #endregion

    #region Public Methods and Operators

    public virtual Control GetViewToPresentMe()
    {
      return null;
    }

    #endregion

    #region Methods

    protected virtual void OnResultObtained(NotificationResult result)
    {
      EventHandler<ResultObtainedEventArgs> handler = this.ResultObtained;
      if (handler != null)
      {
        handler(this, new ResultObtainedEventArgs(result));
      }
    }

    protected virtual void SetResultNotifyInterestedMen(NotificationResult result)
    {
      this.Result = result;
      this.OnResultObtained(this.Result);
    }

    #endregion
  }
}