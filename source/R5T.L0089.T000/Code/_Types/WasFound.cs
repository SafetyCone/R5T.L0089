using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0142;


namespace R5T.L0089.T000
{
    /// <summary>
    /// Solves a problem that asynchronous (async) methods cannot use out parameters.
    /// Instead, an instance providing both whether the output exists, and the result instance if it does, it output from the asynchronous method.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <remarks>
    /// This is the same idea as suggested in Stack Overflow: https://stackoverflow.com/questions/18716928/how-to-write-a-async-method-with-out-parameter
    /// </remarks>
    [UtilityTypeMarker]
    public class WasFound<T>
    {
        #region Static

        public static implicit operator bool(WasFound<T> wasFound)
        {
            return wasFound.zExists;
        }

        public static implicit operator T(WasFound<T> wasFound)
        {
            return wasFound.Result;
        }

        #endregion


        private readonly bool zExists;

        //[Obsolete("Use the implicit conversion of to bool instead.", false)]
        public bool Exists
        {
            get
            {
                return zExists;
            }
        }
        public T Result { get; set; }


        public WasFound()
        {
        }

        public WasFound(bool exists, T result)
        {
            zExists = exists;
            Result = result;
        }

        public override string ToString()
        {
            var representation = $"{Exists}, {Result}";
            return representation;
        }
    }

    public static class WasFound
    {
        public static WasFound<T> Found<T>(T value)
        {
            var wasFound = new WasFound<T>(true, value);
            return wasFound;
        }

        /// <summary>
        /// Compares the value to the default for the type of the value using the default equality comparer (<see cref="EqualityComparer{T}.Default"/>).
        /// If the value is the default value, then the value was not found.
        /// </summary>
        /// <remarks>
        /// If you instead want to indicate that a value <strong>was</strong> found, but that the default value was found, use <see cref="From{T}(bool, T)"/>.
        /// </remarks>
        public static WasFound<T> From<T>(T resultOrDefault)
        {
            var defaultEqualityComparer = EqualityComparer<T>.Default;

            var defaultValue = default(T);
            var exists = !defaultEqualityComparer.Equals(resultOrDefault, defaultValue);

            var wasFound = new WasFound<T>(exists, resultOrDefault);
            return wasFound;
        }

        public static WasFound<T> From<T>(bool exists, T result)
        {
            var wasFound = new WasFound<T>(exists, result);
            return wasFound;
        }

        /// <summary>
        /// Was found only if the array is non-null and non-empty.
        /// </summary>
        public static WasFound<T[]> From_Array<T>(T[] result)
        {
            var exists = result is object && result.Any();

            var output = new WasFound<T[]>(exists, result);
            return output;
        }

        public static WasFound<T[]> From_Enumerable<T>(IEnumerable<T> result)
        {
            var exists = result is object && result.Any();

            var resultArray = result.ToArray();

            var output = new WasFound<T[]>(exists, resultArray);
            return output;
        }

        public static WasFound<T> NotFound<T>()
        {
            var wasFound = new WasFound<T>(false, default);
            return wasFound;
        }

        public static WasFound<T> NotFound<T>(T value)
        {
            var wasFound = new WasFound<T>(false, value);
            return wasFound;
        }
    }
}
