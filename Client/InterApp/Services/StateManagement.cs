using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
namespace BlazorComponent.Client.InterApp.Services
{
    public class StateManagement:IStateManagement
    {
        private ExpandoObject stateContainer = new ExpandoObject();

        public T GetState<T>(string key)
        {
            var dict = (IDictionary<String, object>)stateContainer;
            return (T)dict[key];

        }

        public void SetState<T>(string key, T value)
        {
            var dict = (IDictionary<String, object>)stateContainer;
            dict[key] = value;
        }
    }
}
