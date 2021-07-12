using System;
using Exiled.API.Interfaces;

namespace Martyrdom
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}