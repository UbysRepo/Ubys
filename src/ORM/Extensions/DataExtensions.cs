namespace sORM.Extensions
{
    public static class DataExtensions
    {
        public static void Exchange<T>(ref T ele1, ref T ele2)
        {
            var cache = ele1;

            ele1 = ele2;
            ele2 = cache;
        }
    }
}
