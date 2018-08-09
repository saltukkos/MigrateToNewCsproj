using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Saltuk.Utils.Validation
{
    public static class ThrowIf
    {
        public static class Argument
        {
            [ContractAnnotation("argument:null => halt")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void IsNull<T>([CanBeNull] [NoEnumeration] T argument, [NotNull] [InvokerParameterName] string argumentName) where T : class 
            {
                if (argument == null)
                {
                    ThrowHelper.ThrowArgumentNullException(argumentName);
                }
            }
        }
    }
}