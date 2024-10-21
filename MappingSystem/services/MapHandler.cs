// using System;
// using MappingSystem.Mappers;

// namespace MappingSystem.Services
// {
//     public class MapHandler
//     {
//         /// <summary>
//         /// Maps the properties of the source object to a new instance of type T.
//         /// </summary>
//         /// <typeparam name="T">The type to map to.</typeparam>
//         /// <param name="source">The object to map from.</param>
//         /// <returns>A new instance of type T with properties mapped from the source object.</returns>
//         /// <exception cref="ArgumentNullException">Thrown when the source object is null.</exception>
//         public T Map<T>(object source)
//         {
//             if (source == null)
//             {
//                 throw new ArgumentNullException(nameof(source), "Source object cannot be null.");
//             }

//             try
//             {
//                 return Mapper.To<T>(source);
//             }
//             catch (Exception ex)
//             {
//                 // Log the exception (assuming a logging mechanism is in place)
//                 // Logger.LogError(ex, "Error occurred while mapping object of type {SourceType} to type {TargetType}", source.GetType(), typeof(T));
//                 throw new InvalidOperationException($"Error occurred while mapping object of type {source.GetType()} to type {typeof(T)}.", ex);
//             }
//         }
//     }
// }