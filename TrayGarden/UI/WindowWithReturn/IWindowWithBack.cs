﻿using System.Collections.Generic;
using JetBrains.Annotations;
using TrayGarden.UI.Common.VMtoVMapping;

namespace TrayGarden.UI.WindowWithReturn
{
    public interface IWindowWithBack
    {
        void Initialize([NotNull] List<IViewModelToViewMapping> mvtovmappings);
        void PrepareAndShow(WindowWithBackVM viewModel);
    }
}