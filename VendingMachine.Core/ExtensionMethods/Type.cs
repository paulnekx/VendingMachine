using System;
using System.ComponentModel;
using System.Linq;

namespace VendingMachine.Core.ExtensionMethods
{
    public static class Type
    {
        public static string GetDisplayName(this System.Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var displayNameAttribute = type
                .GetCustomAttributes(typeof(DisplayNameAttribute), true)
                .FirstOrDefault() as DisplayNameAttribute;
            return displayNameAttribute?.DisplayName;
        }
    }
}
