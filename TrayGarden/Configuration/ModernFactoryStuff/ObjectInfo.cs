﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TrayGarden.Configuration.ModernFactoryStuff
{
    public class ObjectInfo
    {
        public bool IsSingleton { get; set; }
        public bool IsPrototype { get; set; }
        public XmlNode ConfigurationNode { get; set; }
        public object Instance { get; set; }

        public ObjectInfo(object instance, XmlNode configurationNode,bool isSingleton,bool isPrototype)
        {
            this.Instance = instance;
            this.ConfigurationNode = configurationNode;
            this.IsPrototype = isPrototype;
            this.IsSingleton = isSingleton;
        }
    }
}
