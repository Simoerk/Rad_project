using System.Numerics;

namespace Hashing_util;

public class Hash_multiply_mod_prime
{
// Implementering af hashfunktioner

// Opgave 1 (b) 
// Bruger exercise 2.7 & 2.8 
    public BigInteger multiplyModPrimeH(BigInteger x){
        BigInteger a = BigInteger.Parse("0110100001010000000000111110110010101011100000101100011101100001"); //a
        BigInteger b = BigInteger.Parse("0101111010001101000101000111100110010010000110001001100101001001"); //b
        int l = 11; // l
        BigInteger p = ((BigInteger)(1<<89)) - (ulong) 1 ; //p is 2 bitshifted which is equal to the power with 89, - 1
        BigInteger x1 = (a*x+b);  // The inner value to mod p with.
        BigInteger y = (x1&p)+(x1>>89); // The inner value to mod 2^l with.
        if (y>=p){
            y-=p;
        }
        //Console.WriteLine("Y is equal to: " + y);
        ulong Result = (ulong)(y % (ulong)(Math.Pow(2,l)) );

        //Console.WriteLine("The Result is: " + Result);

        return Result;
    }
}
