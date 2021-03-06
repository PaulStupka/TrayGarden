﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JetBrains.Annotations;

using TrayGarden.Configuration;
using TrayGarden.Diagnostics;
using TrayGarden.Helpers;

#endregion

namespace TrayGarden.TypesHatcher
{
  [UsedImplicitly]
  public class Mapping : IMapping
  {
    #region Public Properties

    public Type InterfaceType { get; protected set; }

    public IObjectFactory ObjectFactory { get; protected set; }

    #endregion

    #region Public Methods and Operators

    [UsedImplicitly]
    public virtual void Initialize([NotNull] Type interfaceType, IObjectFactory objectFactory)
    {
      Assert.ArgumentNotNull(interfaceType, "interfaceType");
      Assert.ArgumentNotNull(objectFactory, "objectFactory");
      this.InterfaceType = interfaceType;
      this.ObjectFactory = objectFactory;
    }

    public override string ToString()
    {
      if (this.ObjectFactory == null || this.InterfaceType == null)
      {
        return base.ToString();
      }
      return "Mapping: Interface {0}, ObjFactory {1}".FormatWith(this.InterfaceType.FullName, this.ObjectFactory.GetType().FullName);
    }

    #endregion
  }
}