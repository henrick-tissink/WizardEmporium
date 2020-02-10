using System;

namespace WizardEmporium.Common.SharedSwaggerConfig
{
    public class DescribeErrorTypeOnResponseAttribute : Attribute
    {
        public Type EnumType { get; }

        public int HttpStatusCode { get; }

        public DescribeErrorTypeOnResponseAttribute(Type enumType, int httpStatusCode)
        {
            EnumType = enumType;
            HttpStatusCode = httpStatusCode;
        }
    }
}
