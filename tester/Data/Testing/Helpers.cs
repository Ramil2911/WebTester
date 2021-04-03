using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace tester.Data.Testing
{
    public static class Helpers
    {
        /// <summary>
        /// Функция для получения наследованных типов
        /// </summary>
        /// <typeparam name="T">Тип объекта, для которого надо получить результат</typeparam>
        /// <returns>Возвращает список наследованных типов</returns>
        public static IEnumerable<Type> GetInheritedOfType<T>() where T : class
        {
            foreach (var myType in Assembly.GetAssembly(typeof(T)).GetTypes())
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
        
        public static bool IsInvalidFilename(string str)
        {
            return str.Any(Path.GetInvalidFileNameChars().Contains);
        }
    }
}