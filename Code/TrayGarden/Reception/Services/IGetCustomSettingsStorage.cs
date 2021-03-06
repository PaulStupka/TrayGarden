﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TrayGarden.RuntimeSettings;

#endregion

namespace TrayGarden.Reception.Services
{
  /// <summary>
  /// This service provides plant with custom data storage.
  /// There are no ways to change this value through UI, this is only for plant internal usage.
  /// </summary>
  public interface IGetCustomSettingsStorage
  {
    #region Public Methods and Operators

    void StoreCustomSettingsStorage(ISettingsBox settingsStorage);

    #endregion
  }
}