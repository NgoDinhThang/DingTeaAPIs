using System;
namespace MISA.WEBAPI.Core.MISAAttribute
{
    /// <summary>
    /// Attribute
    /// </summary>
    /// created by NDThang
    //Không được bỏ trống
    [AttributeUsage(AttributeTargets.Property)]
    class NotEmty:Attribute
    {
    }

    //Đặt tên hiển thi
    [AttributeUsage(AttributeTargets.Property)]
    class  PropertyName: Attribute
    {
        public string Name = string.Empty;
        public PropertyName(string name)
        {
            this.Name = name;
        }
    }

    //khoá chính
    [AttributeUsage(AttributeTargets.Property)]
     public class PrimaryKey : Attribute
    {

    }

}
