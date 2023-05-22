using Hashing_util;

class Program
{
    static void Main()
    {
        Hash_util hash_util = new Hash_util();  // Instantiate the class
        
        ulong x = 59;

        ulong p = hash_util.CalculateH(x);  // Call the function
        Console.WriteLine(p);
    }
}