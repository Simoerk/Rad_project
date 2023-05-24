namespace Hashing_util;
using Hashes;

public class Hash_multiply_shift : IHashFunct
{
// Implementering af hashfunktioner
// Opgave 1 (a)
    
    private ulong a { get; set; } = 18296506298175491242;

    public ulong MakeOdd(ulong number)
    {

        //ulong number = Convert.ToUInt64(binary, 2);

        if ((number & 1) == 0)  // Check if the number is even
            return number | 1;    // Set the least significant bit to 1 to make it odd

        return number;  // Return the number unchanged if it is already odd
    }

    public ulong HashFunction(ulong x, int l){
        
        //ulong x = 59;
        ulong a1 = MakeOdd(a);

        //ulong p = CalculateHMultyShift(x);  // Call the function

        //Console.WriteLine(p);

        return (a1 * x) >> (64 - l);
    }

}
