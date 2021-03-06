﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JetBrains.Annotations;

using TrayGarden.Diagnostics;
using TrayGarden.Services.PlantServices.UserConfig.Core.Interfaces;
using TrayGarden.Services.PlantServices.UserConfig.Core.TypeSpecific;

#endregion

namespace TrayGarden.Services.PlantServices.UserConfig.Core
{
  public class TypedUserSetting<T> : UserSettingBase, ITypedUserSetting<T>, ITypedUserSettingMaster<T>
  {
    #region Fields

    protected T currentValue;

    #endregion

    #region Public Events

    public new event EventHandler<TypedUserSettingChange<T>> ValueChanged;

    #endregion

    #region Public Properties

    public new virtual ITypedUserSettingMetadata<T> Metadata { get; set; }

    public IUserSettingStorage<T> Storage { get; set; }

    public virtual T Value
    {
      get
      {
        this.AssertInitialized();
        if (!this.ValueWasAlreadyPooled)
        {
          this.currentValue = this.PullValueFromUnderlyingStorage();
          this.ValueWasAlreadyPooled = true;
        }
        return this.currentValue;
      }

      set
      {
        this.AssertInitialized();
        var oldValue = this.Value;
        this.currentValue = value;
        this.PushValueToUnderlyingStorage(value);
        this.OnValueChanged(oldValue, this.Value);
      }
    }

    #endregion

    #region Properties

    protected bool ValueWasAlreadyPooled { get; set; }

    #endregion

    #region Public Methods and Operators

    public virtual void Initialize(
      [NotNull] ITypedUserSettingMetadata<T> typedMetadata,
      [NotNull] IUserSettingStorage<T> storage,
      List<IUserSettingBase> activityCriterias)
    {
      Assert.ArgumentNotNull(typedMetadata, "metadata");
      Assert.ArgumentNotNull(storage, "storage");
      base.Initialize(typedMetadata, activityCriterias);
      this.Metadata = typedMetadata;
      this.Storage = storage;
    }

    public override void ResetToDefault()
    {
      this.AssertInitialized();
      this.Value = this.Metadata.DefaultValue;
    }

    #endregion

    #region Methods

    protected virtual void OnValueChanged(T oldValue, T newValue)
    {
      var args = new TypedUserSettingChange<T>(this, oldValue, newValue);
      base.OnValueChanged(args);
      EventHandler<TypedUserSettingChange<T>> handler = this.ValueChanged;
      if (handler != null)
      {
        handler(this, args);
      }
    }

    protected virtual T PullValueFromUnderlyingStorage()
    {
      return this.Storage.ReadValue(this.Name, this.Metadata.DefaultValue);
    }

    protected virtual void PushValueToUnderlyingStorage(T value)
    {
      this.Storage.WriteValue(this.Name, value);
    }

    #endregion
  }
}