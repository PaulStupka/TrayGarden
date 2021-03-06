﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

#endregion

namespace TrayGarden.Services.PlantServices.UserNotifications.Core.UI.HelpContent
{
  public class ImageDisplayOptions
  {
    #region Constructors and Destructors

    public ImageDisplayOptions(double width, double height)
    {
      this.Width = width;
      this.Height = height;
      this.Stretch = Stretch.Fill;
      this.Margins = new Thickness(0);
      this.HorizontalAlignment = HorizontalAlignment.Center;
      this.VerticalAlignment = VerticalAlignment.Stretch;
    }

    #endregion

    #region Public Properties

    public double Height { get; set; }

    public HorizontalAlignment HorizontalAlignment { get; set; }

    public Thickness Margins { get; set; }

    public Stretch Stretch { get; set; }

    public VerticalAlignment VerticalAlignment { get; set; }

    public double Width { get; set; }

    #endregion
  }
}