using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Controllers
{
    public class Container
    {
        private Dictionary<Type, Type> _types;

        public Container()
        {
            _types = new Dictionary<Type, Type>();
        }

        public void Register<T1, T2>() where T2:T1
        {
            if(!_types.ContainsKey(typeof(T1)))
            {
                _types[typeof(T1)] = typeof(T2);
            }
        }

        public T GetInstance<T>()
        {
            if(_types.ContainsKey(typeof(T)))
            {
                var type = _types[typeof(T)];
                return (T)Activator.CreateInstance(type);
            }
            else
            {
                return default(T);
            }
        }
            
    }
}