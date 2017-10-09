using System;
using System.Collections.Generic;
using System.Linq;

namespace IoCContainerDemo
{
    public class IocContainer
    {
        private readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();
        
        public T Resolve<T>()
        {
            return (T)Resolve(typeof (T));
        }

        private object Resolve(Type typeToResolve)
        {
            Type resolvedType;

            try
            {
                resolvedType = _dependencyMap[typeToResolve];
            }
            catch
            {
                throw new Exception(string.Format("Could not resolve type {0}", typeToResolve.FullName));
            }

            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();

            if (!constructorParameters.Any())
            {
                return Activator.CreateInstance(resolvedType);
            }

            IList<object> parameters = constructorParameters.Select(parameterToResolve => Resolve(parameterToResolve.ParameterType)).ToList();

            return firstConstructor.Invoke(parameters.ToArray());
        }

        public void Register<TFrom, TTo>()
        {
            _dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }
    }
}