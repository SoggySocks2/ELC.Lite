using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ELC.Lite.SharedKernel.Exceptions.Helpers
{
    public static class CheckExtensions
    {
        public static T NullWithMessage<T>(this ICheckClause checkClause, [NotNull] T? input, string message)
        {
            if (input is null)
            {
                throw new ArgumentNullException(message, (Exception?)null);
            }

            return input;
        }

        public static T Null<T>(this ICheckClause checkClause, [NotNull] T? input, [CallerArgumentExpression("input")] string? parameterName = null)
        {
            return checkClause.NullWithMessage(input, $"Required input {parameterName} was null.");
        }

        public static string NullOrWhiteSpace(this ICheckClause checkClause, [NotNull] string? input, [CallerArgumentExpression("input")] string? parameterName = null)
        {
            checkClause.Null(input, parameterName);

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"Required input {parameterName} was empty or white space.", parameterName);
            }

            return input;
        }

    }
}
