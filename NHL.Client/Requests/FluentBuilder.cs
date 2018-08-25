using NHL.Client.RequestModels;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NHL.Client.Requests
{
    //TODO: make internal
    public class FluentBuilder<TRequest>
        where TRequest : IRequestModel
    {
        private IRequestModel RequestModel { get; }

        internal FluentBuilder(IRequestModel requestModel)
        {
            RequestModel = requestModel;
        }

        public FluentBuilder<TRequest> SetProperty<TPropertyType>(Expression<Func<TRequest, TPropertyType>> property, TPropertyType value)
        {
            PropertyInfo propertyInfo = null;

            if (property.Body is MemberExpression)
            {
                propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;
            }
            else
            {
                propertyInfo = (((UnaryExpression)property.Body).Operand as MemberExpression).Member as PropertyInfo;
            }

            propertyInfo.SetValue(RequestModel, value, null);

            return this;
        }
    }
}
