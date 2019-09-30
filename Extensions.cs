using System;
using System.ComponentModel;
using System.Reflection;

namespace csharp
{
    public static class Extensions
    {
        public static string GetDescription(this Enum element)
        {
            FieldInfo fi = element.GetType().GetField(element.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;

            else
                return element.ToString();
        }

        public static ItemType GetItemType(this string name)
        {
            if (name.StartsWith(ItemType.Aged.GetDescription()))
                return ItemType.Aged;

            if (name.StartsWith(ItemType.BackstagePass.GetDescription()))
                return ItemType.BackstagePass;

            if (name.StartsWith(ItemType.Conjured.GetDescription()))
                return ItemType.Conjured;

            if (name.StartsWith(ItemType.Legendary.GetDescription()))
                return ItemType.Legendary;

            return ItemType.Regular;
        }
    }
}
