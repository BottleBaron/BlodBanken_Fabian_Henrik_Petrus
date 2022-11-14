namespace BlodBanken_Fabian_Henrik_Petrus;

class BloodUnitComparer : IComparer<BloodUnit>
{
    public int Compare(BloodUnit? x, BloodUnit? y)
    {
        if (x == null || y == null) return 1;

        int diff = x.blood_type - y.blood_type;

        if(diff == 0) return 0;
        else if(diff > 0) return 1;
        else return -1;
    }
}