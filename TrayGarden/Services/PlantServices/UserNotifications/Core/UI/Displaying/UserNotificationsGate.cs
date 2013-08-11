﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrayGarden.Services.PlantServices.UserNotifications.Core.UI.ResultDelivering;
using TrayGarden.Services.PlantServices.UserNotifications.Core.UI.SpecializedNotifications;

namespace TrayGarden.Services.PlantServices.UserNotifications.Core.UI.Displaying
{
  public class UserNotificationsGate : IUserNotificationsGate
  {
    protected bool Initialized { get; set; }
    protected IDisplayQueueProvider Provider { get; set; }

    public virtual void Initialize(IDisplayQueueProvider provider)
    {
      Provider = provider;
      Initialized = true;
    }


    public virtual INotificationResultCourier EnqueueToShow(IResultProvider notificationVM, string originator)
    {
      AssertInitialized();
      NotificationDisplayTask displayTask = GetDisplayTask(notificationVM, originator);
      if (!AddToDisplayQueue(displayTask))
      {
        displayTask.SetResult(new NotificationResult(ResultCode.Unspecified));
        displayTask.State = NotificationState.Aborted;
      }
      return new NotificationResultCourier(displayTask);
    }

    protected virtual NotificationDisplayTask GetDisplayTask(IResultProvider notificationVM, string originator)
    {
      return new NotificationDisplayTask(notificationVM,originator);
    }

    protected virtual bool AddToDisplayQueue(NotificationDisplayTask task)
    {
      return Provider.EnqueueToDisplay(task);
    }

    protected virtual void AssertInitialized()
    {
      if(!Initialized)
        throw new NonInitializedException();
    }
  }
}