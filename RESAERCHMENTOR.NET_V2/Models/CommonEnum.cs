using System.ComponentModel;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public enum Title
    {
        [Description("Mr.")]
        Mr,
        [Description("Mrs.")]
        Mrs,
        [Description("Dr.")]
        Dr,
        [Description("Prof.")]
        Prof,
        [Description("Chief")]
        Chief,
    }
    public enum Gender
    {
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female = 2,
    }

}