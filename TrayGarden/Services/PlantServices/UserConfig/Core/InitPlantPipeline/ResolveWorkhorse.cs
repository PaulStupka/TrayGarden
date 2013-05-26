﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrayGarden.Services.PlantServices.UserConfig.Smorgasbord;

namespace TrayGarden.Services.PlantServices.UserConfig.Core.InitPlantPipeline
{
    public class ExtractSettingsMetadata
    {
        public void Process(InitPlantUCPipelineArg args)
        {
            var appropriateWorkhorse = args.RelatedPlant.GetFirstWorkhorseOfType<IUserConfiguration>();
            if (appropriateWorkhorse == null)
            {
                args.Abort();
                return;
            }
            args.Workhorse = appropriateWorkhorse;
        }
    }
}