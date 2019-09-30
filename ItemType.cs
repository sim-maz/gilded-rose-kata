using System.ComponentModel;

namespace csharp
{
    public enum ItemType
    {
        Regular,

        [Description("Aged")]
        Aged,

        [Description("Backstage passes")]
        BackstagePass,

        [Description("Sulfuras")]
        Legendary,

        [Description("Conjured")]
        Conjured
    }
}
