using System.Collections.Generic;

namespace Day13
{
    public class PackageCompare : IComparer<PackageData>
    {
        public int Compare(PackageData x, PackageData y)
        {
            if (x.CompareOrder(y))
                return 1;
            return -1;
        }
    }
}