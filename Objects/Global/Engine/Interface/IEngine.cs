﻿using Objects.Global.Engine.Engines;
using Objects.Global.Engine.Engines.Interface;

namespace Objects.Global.Engine.Interface
{
    public interface IEngine
    {
        ICombat Combat { get; set; }
        IEvent Event { get; set; }
        IParty Party { get; set; }
    }
}