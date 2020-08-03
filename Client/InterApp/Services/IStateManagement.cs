using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponent.Client.InterApp.Services
{
    public interface IStateManagement
    {
        void SetState<T>(string key, T value);
        T GetState<T>(string key);
    }
}
