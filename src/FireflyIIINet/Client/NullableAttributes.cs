/*
 * Firefly III API
 *
 * The nullable-analysis attribute the models use, for .NET Framework, which does not ship it.
 * The compiler recognises it by name, so an internal copy is enough.
 */

#if !NETCOREAPP3_0_OR_GREATER
namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Null may be assigned even though the type does not allow it.</summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, Inherited = false)]
    internal sealed class AllowNullAttribute : Attribute
    {
    }
}
#endif
