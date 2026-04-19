namespace Pure.Library.Extensions
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// Generates a random <see cref="boo"/> value.
        /// </summary>
        /// <param name="instance">The <see cref="bool"/> instance.</param>
        /// <returns>A random true or false value.</returns>
        public static bool GenerateRandom(this bool instance)
        {
            instance = new Random().Next(0, 2) == 1;

            return instance;
        }
    }
}
