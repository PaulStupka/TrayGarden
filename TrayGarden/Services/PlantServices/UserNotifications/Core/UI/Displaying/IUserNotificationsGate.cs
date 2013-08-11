﻿using TrayGarden.Services.PlantServices.UserNotifications.Core.UI.ResultDelivering;

namespace TrayGarden.Services.PlantServices.UserNotifications.Core.UI.Displaying
{
  public interface IUserNotificationsGate
  {
    INotificationResultCourier EnqueueToShow(IResultProvider notificationVM, string originator);
  }
}