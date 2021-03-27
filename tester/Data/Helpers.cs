using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace tester.Data
{
    public static class Helpers
    {
        /// <summary>
        /// Функция для получения наследовынных типов
        /// </summary>
        /// <typeparam name="T">Тип объекта, для которого надо получить результат</typeparam>
        /// <returns>Возвращает список наследованных типов</returns>
        public static IEnumerable<Type> GetInheritedOfType<T>() where T : class
        {
            foreach (Type myType in Assembly.GetAssembly(typeof(T)).GetTypes())
            {
                if (myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))) yield return myType;
            } //изначально LINQ-метод конвертирован в обычный код, ибо LINQ медленнее
        }
        
        /// <summary>
        /// Аналог #ifdef для html
        /// </summary>
        /// <returns>Возвращает true, если есть символ DEBUG, иначе false</returns>
        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
      return false;
#endif
        }
    }
}