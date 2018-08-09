using System;

namespace Saltuk.Utils.Validation
{
    internal static class ThrowHelper
    {
        internal static void ThrowArgumentNullException(string argumentName)
        {
            throw new ArgumentNullException(argumentName);
        }
    }
}