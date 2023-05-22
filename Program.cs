using Hashing_util;
using System.Numerics;
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Hash_multiply_shift hash_multiply_shift = new Hash_multiply_shift();  // Instantiate the class
        
        //ulong multiRes = hash_multiply_shift.multiplyShift();
        
        
        Hash_multiply_mod_prime hash_multiply_mod_prime = new Hash_multiply_mod_prime();

        //BigInteger modprimeRes = hash_multiply_mod_prime.multiplyModPrimeH(59);

        // Generate stream 
        IEnumerable<Tuple<ulong, int>> stream = GenerateStream.CreateStream(85, 190);
        BigInteger res_mulshift = 0;
        BigInteger res_modprime = 0;
        // Mulitply shift
        Stopwatch stopwatch_mulshift = new Stopwatch(); // Create stopwatch 
        stopwatch_mulshift.Start();
        foreach (Tuple< ulong, int > key in stream){
            res_mulshift += hash_multiply_shift.multiplyShift();
        } 
        stopwatch_mulshift.Stop();
        Console.WriteLine("Sum: "+ res_mulshift);
        Console.WriteLine("Run time: "+ (long)stopwatch_mulshift.ElapsedMilliseconds);

        // Multiply mod prime
        Stopwatch stopwatch_mulmodprime = new Stopwatch(); // Create stopwatch 
        stopwatch_mulmodprime.Start();
        foreach (Tuple< ulong, int > key in stream){
            res_modprime += hash_multiply_mod_prime.multiplyModPrimeH(7014);
        }
        stopwatch_mulmodprime.Stop();
        Console.WriteLine("Sum: "+ res_modprime);
        Console.WriteLine("Run time: "+ (long)stopwatch_mulmodprime.ElapsedMilliseconds);
        
    }
        
}