using System;
using System.Collections.Generic;
using System.Linq;

using R5T.L0089.T000;

using Instances = R5T.L0089.F000.Instances;


namespace System
{
    public static class WasFoundExtensions
    {
        public static bool Any_Found<T>(this IEnumerable<WasFound<T>> wasFounds)
        {
            var output = Instances.WasFoundOperator.Any_Found(wasFounds);
            return output;
        }

        //public static bool SingleWasFound<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByValue)
        //{
        //    var singleOrDefault = wasFoundByValue
        //        .Where(xPair => xPair.Value.Exists)
        //        .SingleOrDefault();

        //    var output = singleOrDefault != default;

        //    return output;
        //}

        public static bool Any_NotFound<T>(this IEnumerable<WasFound<T>> wasFounds)
        {
            var output = Instances.WasFoundOperator.Any_NotFound(wasFounds);
            return output;
        }

        public static WasFound<TDestination> Convert<TSource, TDestination>(this WasFound<TSource> wasFound, Func<TSource, TDestination> converterIfFound)
        {
            var output = Instances.WasFoundOperator.Convert(wasFound, converterIfFound);
            return output;
        }

        public static WasFound<TDestination> Convert<TSource, TDestination>(this WasFound<TSource> wasFound, Func<TSource, WasFound<TDestination>> converterIfFound)
        {
            var output = Instances.WasFoundOperator.Convert(wasFound, converterIfFound);
            return output;
        }

        public static void Throw_ExceptionIfNotFound<T>(this WasFound<T> wasFound, string message)
        {
            wasFound.Throw_InvalidOperationException_IfNotFound(message);
        }

        public static IEnumerable<TKey> Get_KeysNotFound<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByValue)
        {
            var output = wasFoundByValue
                .Where(xPair => !xPair.Value.Exists)
                .Select(xPair => xPair.Key)
                ;

            return output;
        }

        public static T Get_Result_OrExceptionIfNotFound<T>(this WasFound<T> wasFound, string exceptionMessage)
        {
            wasFound.Throw_ExceptionIfNotFound(exceptionMessage);

            var output = wasFound.Result;
            return output;
        }

        public static void Throw_InvalidOperationException_IfNotFound<T>(this WasFound<T> wasFound, string message)
        {
            if(!wasFound)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static bool Is_Found<T>(this WasFound<T> wasFound)
        {
            var output = Instances.WasFoundOperator.Is_Found(wasFound);
            return output;
        }

        public static bool Is_NotFound<T>(this WasFound<T> wasFound)
        {
            var output = Instances.WasFoundOperator.Is_NotFound(wasFound);
            return output;
        }

        public static WasFound<T> OrIfNotFound<T>(this WasFound<T> wasFound,
            Func<T> orIfNotFound)
        {
            var output = wasFound
                ? wasFound
                : WasFound.From(wasFound.Exists, orIfNotFound())
                ;

            return output;
        }

        public static T Get_Result_OrDefaultIfNotFound<T>(this WasFound<T> wasFound)
        {
            var output = Instances.WasFoundOperator.Get_Result_OrDefaultIfNotFound(wasFound);
            return output;
        }

        public static T Get_Result_OrExceptionIfNotFound<T>(this WasFound<T> wasFound,
            Exception exception)
        {
            return Instances.WasFoundOperator.Get_Result_OrExceptionIfNotFound(wasFound, exception);
        }

        public static T Get_Result_OrExceptionIfNotFound<T>(this WasFound<T> wasFound,
            Func<string> exceptionMessageConstructor)
        {
            return Instances.WasFoundOperator.Get_Result_OrExceptionIfNotFound(wasFound, exceptionMessageConstructor);
        }

        public static T Get_Result_OrExceptionIfNotFound<T>(this WasFound<T> wasFound,
            Func<Exception> exceptionConstructor)
        {
            return Instances.WasFoundOperator.Get_Result_OrExceptionIfNotFound(wasFound, exceptionConstructor);
        }

        public static T Get_Result_OrExceptionIfNotFound<T, TException>(WasFound<T> wasFound,
            Func<TException> exceptionConstructor)
            where TException : Exception
        {
            return Instances.WasFoundOperator.Get_Result_OrExceptionIfNotFound(wasFound, exceptionConstructor);
        }

        public static T Get_Result_OrExceptionIfNotFound<T>(this WasFound<T> wasFound)
        {
            return Instances.WasFoundOperator.Get_Result_OrExceptionIfNotFound(wasFound);
        }

        public static T Get_Result<T>(this WasFound<T> wasFound)
        {
            return Instances.WasFoundOperator.Get_Result(wasFound);
        }

        public static T Get_Result_OrIfNotFound<T>(this WasFound<T> wasFound,
            T orIfNotFound)
        {
            var output = Instances.WasFoundOperator.Get_Result_OrIfNotFound(
                wasFound,
                orIfNotFound);

            return output;
        }

        public static T Get_Result_OrIfNotFound<T>(this WasFound<T> wasFound,
            Func<T> orIfNotFound)
        {
            var output = Instances.WasFoundOperator.Get_Result_OrIfNotFound(
               wasFound,
               orIfNotFound);

            return output;
        }

        public static Dictionary<TKey, TValue> To_Dictionary_FromWasFounds<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByKey)
        {
            var output = wasFoundByKey
                .ToDictionary(
                    xPair => xPair.Key,
                    xPair => xPair.Value.Result);

            return output;
        }
    }
}

namespace System.Linq
{
    public static class WasFoundExtensions
    {
        public static WasFound<T> Find_Single<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var selectionOrDefault = items
                .Where(predicate)
                .SingleOrDefault();

            var output = WasFound.From(selectionOrDefault);
            return output;
        }

        public static IEnumerable<TValue> ValuesFound<TValue>(this IEnumerable<WasFound<TValue>> wasFounds)
        {
            var output = Instances.WasFoundOperator.Get_ValuesFound(wasFounds);
            return output;
        }

        public static IEnumerable<WasFound<T>> Where_IsFound<T>(this IEnumerable<WasFound<T>> wasFounds)
        {
            var output = Instances.WasFoundOperator.Where_IsFound(wasFounds);
            return output;
        }

        public static IEnumerable<WasFound<T>> Where_IsNotFound<T>(this IEnumerable<WasFound<T>> wasFounds)
        {
            var output = Instances.WasFoundOperator.Where_IsNotFound(wasFounds);
            return output;
        }
    }
}
