using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Text;

namespace WizardEmporium.Common.SharedSwaggerConfig
{
	public class DescribeErrorTypeOnResponseOperationFilter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			var attribute = context.MethodInfo.CustomAttributes.FirstOrDefault(att => att.AttributeType == typeof(DescribeErrorTypeOnResponseAttribute));
			if (attribute == null)
				return;

			var enumType = (Type)attribute.ConstructorArguments[0].Value;
			var statusCode = (int)attribute.ConstructorArguments[1].Value;
			var enumDescription = new StringBuilder();

			enumDescription.AppendLine();
			enumDescription.AppendLine("Possible values for ErrorCode : ");

			foreach (var enm in Enum.GetValues(enumType))
			{
				if ((int)enm != 0)
					enumDescription.AppendLine(enm + " = " + (int)enm);
			}

			operation.Responses[statusCode.ToString()].Description += enumDescription;
		}
	}
}
