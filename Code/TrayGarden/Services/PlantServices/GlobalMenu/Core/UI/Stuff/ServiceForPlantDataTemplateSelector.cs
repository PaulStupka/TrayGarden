﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using JetBrains.Annotations;

using TrayGarden.Diagnostics;
using TrayGarden.Services.PlantServices.GlobalMenu.Core.UI.ViewModels;
using TrayGarden.UI.Common;

#endregion

namespace TrayGarden.Services.PlantServices.GlobalMenu.Core.UI.Stuff
{
  [UsedImplicitly]
  public class ServiceForPlantDataTemplateSelector : IDataTemplateSelector
  {
    #region Public Methods and Operators

    public virtual DataTemplate SelectTemplate(object item, DependencyObject container)
    {
      var asFrameworkElement = container as FrameworkElement;
      Assert.IsNotNull(asFrameworkElement, "Strange.. passed dependency object isn't framework element");

      var resolvedDataTemplate = this.TryResolveFromResources(item, asFrameworkElement);

      string defaultResourceKey = "DefaultMode";
      string resourceKey = this.GetResourceKey(item) ?? defaultResourceKey;
      var requiredDataTemplate = this.FindResource(asFrameworkElement, resourceKey);
      return requiredDataTemplate
             ?? (!resourceKey.Equals(defaultResourceKey, StringComparison.OrdinalIgnoreCase)
                   ? this.FindResource(asFrameworkElement, defaultResourceKey)
                   : null);
    }

    #endregion

    #region Methods

    protected virtual DataTemplate FindResource(FrameworkElement container, string key)
    {
      return container.TryFindResource(key) as DataTemplate;
    }

    protected virtual string GetResourceKey(object vmItem)
    {
      if (vmItem is ServiceForPlantActionPerformVM)
      {
        return "ServiceForPlantActionPerform";
      }
      if (vmItem is ServiceForPlantWithEnablingVM)
      {
        return "ServiceForPlantWithEnabling";
      }
      return null;
    }

    protected virtual DataTemplate TryResolveFromResources(object item, FrameworkElement container)
    {
      var c = container.Resources.Count;
      return null;
    }

    #endregion
  }
}