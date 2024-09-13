namespace StaffDirectory1.Areas.Identity.Data
{
    internal class StaffUser<T>
    {
        public object LoginProvider { get; internal set; }
        public object ProviderKey { get; internal set; }
    }
}