using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MappingSystem.Mappers
{
    public class Mapper
    {
        // Main map method that dynamically maps based on class names
        public object Map(string fromClassName, string toClassName, object source)
        {
            // Find the types by their names
            Type fromType = Type.GetType(fromClassName);
            Type toType = Type.GetType(toClassName);

            // Ensure the types are found
            if (fromType == null || toType == null) throw new ArgumentException("Invalid class names provided.");

            // Create an instance of the destination type
            object destination = Activator.CreateInstance(toType);

            // Check if the destination class has a custom 'Map' method that accepts the exact source type
            MethodInfo customMapMethod = toType.GetMethod("Map", new[] { fromType });
            if (customMapMethod != null)
            {
                try
                {
                    // Use the custom map method to map the source to destination
                    customMapMethod.Invoke(destination, new[] { source });
                    return destination;
                }
                catch (TargetException ex)
                {
                    throw new InvalidOperationException($"Custom map method in {toType.Name} could not be invoked properly.", ex);
                }
            }

            // Fallback to automatic property mapping using reflection
            PropertyInfo[] sourceProperties = fromType.GetProperties();
            PropertyInfo[] destinationProperties = toType.GetProperties();

            foreach (var sourceProp in sourceProperties)
            {
                var matchingDestProp = Array.Find(destinationProperties, destProp =>
                    destProp.Name == sourceProp.Name && destProp.CanWrite);

                if (matchingDestProp != null)
                {
                    try
                    {
                        var sourceValue = sourceProp.GetValue(source);
                        if (sourceValue != null)
                        {
                            // Check if the destination property can accept the source value directly
                            if (matchingDestProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                            {
                                matchingDestProp.SetValue(destination, sourceValue);
                            }
                            // Try to convert the source value if the types are compatible
                            else
                            {
                                var convertedValue = Convert.ChangeType(sourceValue, matchingDestProp.PropertyType);
                                matchingDestProp.SetValue(destination, convertedValue);
                            }
                        }
                    }
                    catch (TargetException ex)
                    {
                        throw new InvalidOperationException($"Failed to map property {sourceProp.Name} from {fromType.Name} to {toType.Name}.", ex);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new InvalidOperationException($"Failed to cast property {sourceProp.Name} from {sourceProp.PropertyType} to {matchingDestProp.PropertyType}.", ex);
                    }
                }
            }

            return destination;
        }
    }
}