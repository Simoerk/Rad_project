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
        IEnumerable<Tuple<ulong, int>> stream = GenerateStream.CreateStream(1048576, 190);
        BigInteger res_mulshift = 0;
        BigInteger res_modprime = 0;
        
        // Timing of mulitply shift
        Stopwatch stopwatch_mulshift = new Stopwatch(); // Create stopwatch 
        stopwatch_mulshift.Start();
        foreach (Tuple< ulong, int > key in stream){
            res_mulshift += hash_multiply_shift.HashFunction(key.Item1, 32);
        } 
        stopwatch_mulshift.Stop();

        // Print results 
        Console.WriteLine("Sum multiply shift: "+ res_mulshift);
        Console.WriteLine("Run time multiply shift: "+ (long)stopwatch_mulshift.ElapsedMilliseconds);

        // Timing of multiply mod prime
        Stopwatch stopwatch_mulmodprime = new Stopwatch(); // Create stopwatch 
        stopwatch_mulmodprime.Start();
        foreach (Tuple< ulong, int > key in stream){
            res_modprime += hash_multiply_mod_prime.HashFunction(key.Item1, 32);
        }
        stopwatch_mulmodprime.Stop();

        // Print results 
        Console.WriteLine("Sum multiply mod prime: "+ res_modprime);
        Console.WriteLine("Run time multiplty mod prime: "+ (long)stopwatch_mulmodprime.ElapsedMilliseconds);
        
        
        Console.WriteLine("\n\n\n\n");

        //Opgave 3
        int n = 32768;
        int limit = 14;
        for (int l = 1; l<= limit; l++){
            stopwatch_mulshift.Restart();
            HashTable hash_table_shift = new HashTable(hash_multiply_shift, l);
            IEnumerable<Tuple<ulong, int>> stream_multi_shift = GenerateStream.CreateStream(n, l);
            Console.WriteLine("Quadratic sum mulshift: {0}, l:{1}", hash_table_shift.quadratic_sum(stream_multi_shift), l);
            stopwatch_mulshift.Stop();
            long time = stopwatch_mulshift.ElapsedMilliseconds;
            Console.WriteLine("MultiShift time: {0}", time);
        }
    

        Console.WriteLine("\n\n\n\n");


        for (int l = 1; l<= 19; l++){
            stopwatch_mulmodprime.Restart();
            HashTable hash_table_mod = new HashTable(hash_multiply_shift, l);
            IEnumerable<Tuple<ulong, int>> stream_multi_prime = GenerateStream.CreateStream(n, l);
            Console.WriteLine("Quadratic sum mulmodprime: {0} l: {1}", hash_table_mod.quadratic_sum(stream_multi_prime), l);
            stopwatch_mulmodprime.Stop();
            long time = stopwatch_mulmodprime.ElapsedMilliseconds;
            Console.WriteLine("MulModPrime time: {0}", time);
        }
    }
        
}