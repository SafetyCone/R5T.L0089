using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;

using R5T.L0089.T000;


namespace R5T.L0089.F000
{
    [FunctionalityMarker]
    public partial interface IWasFoundOperator : IFunctionalityMarker
    {
        public bool Any_NotFound<T>(IEnumerable<WasFound<T>> wasFounds)
        {
            var output = wasFounds
                .Select(this.Is_NotFound)
                .Any();

            return output;
        }

        public bool Any_Found<T>(IEnumerable<WasFound<T>> wasFounds)
        {
            var output = wasFounds
                .Where_IsFound()
                .Any();

            return output;
        }

        public WasFound<TDestination> Convert<TSource, TDestination>(WasFound<TSource> wasFound, Func<TSource, TDestination> converterIfFound)
        {
            if (wasFound)
            {
                var convertedResult = converterIfFound(wasFound.Result);

                var output = WasFound.From(wasFound, convertedResult);
                return output;
            }
            else
            {
                var output = WasFound.From(wasFound, default(TDestination));
                return output;
            }
        }

        public WasFound<TDestination> Convert<TSource, TDestination>(WasFound<TSource> wasFound, Func<TSource, WasFound<TDestination>> converterIfFound)
        {
            if (wasFound)
            {
                var convertedResult = converterIfFound(wasFound.Result);

                var output = convertedResult;
                return output;
            }
            else
            {
                var output = WasFound.From(wasFound, default(TDestination));
                return output;
            }
        }

        public bool Is_Found<T>(WasFound<T> wasFound)
        {
            return wasFound.Exists;
        }

        public bool Is_NotFound<T>(WasFound<T> wasFound)
        {
            var output = !wasFound.Exists;
            return output;
        }

        public T Get_Result_OrDefaultIfNotFound<T>(WasFound<T> wasFound)
        {
            var output = wasFound
                ? wasFound.Result
                : default
                ;

            return output;
        }

        public T Get_Result_OrExceptionIfNotFound<T>(WasFound<T> wasFound,
            Exception exception)
        {
            if (!wasFound)
            {
                throw exception;
            }

            return wasFound.Result;
        }

        public T Get_Result_OrExceptionIfNotFound<T>(WasFound<T> wasFound,
            Func<string> exceptionMessageConstructor)
        {
            if (!wasFound)
            {
                var message = exceptionMessageConstructor();

                var exception = new Exception(message);
                throw exception;
            }

            return wasFound.Result;
        }

        public T Get_Result_OrExceptionIfNotFound<T>(WasFound<T> wasFound,
            Func<Exception> exceptionConstructor)
        {
            if (!wasFound)
            {
                var exception = exceptionConstructor();
                throw exception;
            }

            return wasFound.Result;
        }

        public T Get_Result_OrExceptionIfNotFound<T, TException>(WasFound<T> wasFound,
            Func<TException> exceptionConstructor)
            where TException : Exception
        {
            if (!wasFound)
            {
                var exception = exceptionConstructor();
                throw exception;
            }

            return wasFound.Result;
        }

        public T Get_Result_OrExceptionIfNotFound<T>(WasFound<T> wasFound,
            string message)
        {
            var output = this.Get_Result_OrExceptionIfNotFound(wasFound,
                () => new Exception(message));

            return output;
        }

        public T Get_Result_OrExceptionIfNotFound<T>(WasFound<T> wasFound)
        {
            var output = this.Get_Result_OrExceptionIfNotFound(wasFound,
                () => new Exception("Result did not exist."));

            return output;
        }

        public T Get_Result<T>(WasFound<T> wasFound)
        {
            return this.Get_Result_OrExceptionIfNotFound(wasFound);
        }

        public T Get_Result_OrIfNotFound<T>(
            WasFound<T> wasFound,
            T orIfNotFound)
        {
            var output = wasFound
                ? wasFound.Result
                : orIfNotFound
                ;

            return output;
        }

        public T Get_Result_OrIfNotFound<T>(
            WasFound<T> wasFound,
            Func<T> orIfNotFound)
        {
            var output = wasFound
                ? wasFound.Result
                : orIfNotFound()
                ;

            return output;
        }

        public IEnumerable<TValue> Get_ValuesFound<TValue>(IEnumerable<WasFound<TValue>> wasFounds)
        {
            var output = wasFounds
                .Where_IsFound()
                .Select(this.Get_Result)
                ;

            return output;
        }

        public IEnumerable<WasFound<T>> Where_IsNotFound<T>(IEnumerable<WasFound<T>> wasFounds)
        {
            var output = wasFounds
                .Where(this.Is_NotFound)
                ;

            return output;
        }

        public IEnumerable<WasFound<T>> Where_IsFound<T>(IEnumerable<WasFound<T>> wasFounds)
        {
            var output = wasFounds
                .Where(this.Is_Found)
                ;

            return output;
        }
    }
}
