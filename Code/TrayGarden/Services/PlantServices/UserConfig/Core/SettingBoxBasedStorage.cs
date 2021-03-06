﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JetBrains.Annotations;

using TrayGarden.Diagnostics;
using TrayGarden.RuntimeSettings;
using TrayGarden.Services.PlantServices.UserConfig.Core.Interfaces;

#endregion

namespace TrayGarden.Services.PlantServices.UserConfig.Core
{
  /// <summary>
  /// Storage oriented on ISettingBox interface.
  /// Use delegate binding, just pass appropriate methods from ISettingBox instance to constructor.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class SettingBoxOrientedStorage<T> : IUserSettingStorage<T>
  {
    #region Constructors and Destructors

    public SettingBoxOrientedStorage([NotNull] Func<string, T, T> getter, [NotNull] Action<string, T> setter)
    {
      Assert.ArgumentNotNull(getter, "getter");
      Assert.ArgumentNotNull(setter, "setter");
      this.Getter = getter;
      this.Setter = setter;
    }

    #endregion

    #region Public Properties

    public Func<string, T, T> Getter { get; set; }

    public Action<string, T> Setter { get; set; }

    public ISettingsBox UnderlyingBox { get; set; }

    #endregion

    #region Public Methods and Operators

    public T ReadValue(string key, T defaultValue)
    {
      return this.Getter(key, defaultValue);
    }

    public void WriteValue(string key, T value)
    {
      this.Setter(key, value);
    }

    #endregion
  }
}