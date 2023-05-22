namespace Hashing_util;

public class Hash_util
{

    public ulong CalculateH(ulong x)
    {
        int l = 32;
        ulong a = MakeOdd("1111110111101010001111111000101000000101011100101000110010101010");
        return (a * x) >> (64 - l);
    }


    public ulong MakeOdd(string binary)
    {

        ulong number = Convert.ToUInt64(binary, 2);

        if ((number & 1UL) == 0UL)  // Check if the number is even
            return number | 1UL;    // Set the least significant bit to 1 to make it odd

        return number;  // Return the number unchanged if it is already odd
    }


}
