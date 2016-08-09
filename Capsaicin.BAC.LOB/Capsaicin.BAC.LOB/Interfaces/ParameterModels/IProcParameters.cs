using System;
using System.Collections.Generic;

namespace Capsaicin.BAC.LOB.Interfaces.ParameterModels
{
    public interface IProcParameters
    {
        Dictionary<string, string> MapToDictionary();
    }
}
