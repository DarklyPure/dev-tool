using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pure.Library.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Either will get the value from the Dictionary if it exists or add the passed value if it doesn't
        /// </summary>
        /// <typeparam name="TKey">The key for the dictionary entry</typeparam>
        /// <typeparam name="TValue">The value for the dictionary</typeparam>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="key">The key to check for</param>
        /// <param name="value">The value to add</param>
        /// <returns>The value from the dictionary</returns>
        /// <remarks>
        /// This avoids having to access the dictionary to see if the key exists
        /// and then having to access the dictionary a second time to add the item.
        /// This performs only one trip
        /// </remarks>
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> item, TKey key, TValue value) where TKey : notnull
        {
            ref TValue? val = ref CollectionsMarshal.GetValueRefOrAddDefault(item, key, out bool exists);

            if (exists)
            {
                return val!;
            }

            val = value;
            return value;
        }

        /// <summary>
        /// This will update the value if the value only if it exists in the dictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="key">The key</param>
        /// <param name="value">The value with which to update</param>
        /// <returns>True if the update was successful, false if not (including if it doesn't exist)</returns>
        /// <remarks>
        /// This avoids having to access the dictionary to see if the key exists
        /// and then having to access the dictionary a second time to update the item.
        /// This performs only one trip
        /// </remarks>
        public static bool TryUpdate<TKey, TValue>(this Dictionary<TKey, TValue> item, TKey key, TValue value) where TKey : notnull
        {
            ref TValue val = ref CollectionsMarshal.GetValueRefOrNullRef(item, key);

            if (Unsafe.IsNullRef(ref val))
            {
                return false;
            }

            val = value;
            return true;
        }

        public static ResultBinary<TValue> TryGetTypedValue<TKey, TValue>(this Dictionary<TKey, object> item, TKey key) where TKey : notnull
        {
            ResultBinary<TValue> result = new();

            item.TryGetValue(key, out object? value);

            if (value != null)
            {
                result = (TValue)value;
                return result;
            }
            return result;
        }
    }
}
