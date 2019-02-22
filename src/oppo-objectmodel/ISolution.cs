﻿using System.Collections.Generic;

namespace Oppo.ObjectModel
{
    public interface ISolution
    {
        List<IOpcuaapp> Projects { get; } // if we switch Opcuaapp to IOpcuaapp, own JSON converter needs to be implemented
    }
}