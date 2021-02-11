public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        var lo = 0;
        var hi = input.Length - 1;
        
        while (lo <= hi)
        {
            var mid = (lo + hi) / 2;

            if (input[mid] == value)
                return mid;

            if (input[mid] < value)
                lo = mid + 1;
            else
                hi = mid - 1;
        }

        return -1;
    }
}