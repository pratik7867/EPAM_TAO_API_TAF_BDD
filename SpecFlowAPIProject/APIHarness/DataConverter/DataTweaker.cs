using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace SpecFlowAPIProject.APIHarness.DataConverter
{
    public class DataTweaker
    {
        public static string GetRequestData(object instance, Dictionary<string, dynamic> dictOfReqData)
        {
            Type type = instance.GetType();

            foreach (var item in dictOfReqData)
            {
                PropertyInfo propertyInfo = type.GetProperty(item.Key);
                propertyInfo.SetValue(instance, item.Value, null);
            }

            return JsonConvert.SerializeObject(instance);
        }
    }
}
