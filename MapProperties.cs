using assignment_22;
using System;
using System.Reflection;

public class PropertyMapper
{
    public static void MapProperties(Source source, Destination destination)
    {
        Type sourceType = source.GetType();
        Type destType = destination.GetType();

        PropertyInfo[] sourceProperties = sourceType.GetProperties();
        PropertyInfo[] destProperties = destType.GetProperties();

        foreach (PropertyInfo sourceProperty in sourceProperties)
        {
            PropertyInfo destProperty = Array.Find(destProperties, p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);

            if (destProperty != null && destProperty.CanWrite)
            {
                destProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }
    }
}