﻿using System;
using System.Xml;
using TrayGarden.Configuration.ModernFactoryStuff.Parcers;

namespace TrayGarden.Configuration.ModernFactoryStuff
{
    public interface IContentAssigner
    {
        void AssignContent(XmlNode contentNode, object instance, Type instanceType,
                           Func<Type, IParcer> valueParcerResolver);
    }
}