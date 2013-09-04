﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TrayGarden.Services.PlantServices.GlobalMenu.Core.ContextMenuCollecting
{
  public interface IMenuEntriesAppender
  {
    void AppentMenuStripItem(string text, Icon icon, EventHandler clickHandler);
  }
}
