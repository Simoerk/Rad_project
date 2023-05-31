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
            int l = 15;
            IEnumerable<Tuple<ulong, int>> stream = GenerateStream.CreateStream(1<<19, l);
            BigInteger res_mulshift = 0;
            BigInteger res_modprime = 0;
            
            
            // Timing of mulitply shift
            Stopwatch stopwatch_mulshift = new Stopwatch(); // Create stopwatch 
            stopwatch_mulshift.Start();
            foreach (Tuple< ulong, int > key in stream){
                res_mulshift += hash_multiply_shift.HashFunction(key.Item1, 15);
            } 
            stopwatch_mulshift.Stop();

            // Print results 
            Console.WriteLine("Sum multiply shift: "+ res_mulshift);
            Console.WriteLine("Run time multiply shift: "+ (long)stopwatch_mulshift.ElapsedMilliseconds);
            
            string Opgave1 = "Data/Opgave1.txt";
            File.WriteAllText(Opgave1,   "\nUsing: "+l);
            File.AppendAllText(Opgave1,  "Sum multiply shift: "+ res_mulshift+"\n");
            File.AppendAllText(Opgave1,  "Run time multiply shift: "+ (long)stopwatch_mulshift.ElapsedMilliseconds);
            

            // Timing of multiply mod prime
            Stopwatch stopwatch_mulmodprime = new Stopwatch(); // Create stopwatch 
            stopwatch_mulmodprime.Start();
            foreach (Tuple< ulong, int > key in stream){
                res_modprime += hash_multiply_mod_prime.HashFunction(key.Item1, 15);
            }
            stopwatch_mulmodprime.Stop();

            // Print results 
            Console.WriteLine("Sum multiply mod prime: "+ res_modprime);
            Console.WriteLine("Run time multiplty mod prime: "+ (long)stopwatch_mulmodprime.ElapsedMilliseconds);

            File.AppendAllText(Opgave1,  "Sum mulmodprime: "+ res_mulshift);
            File.AppendAllText(Opgave1,  "Run time multiplty mod prime: "+ (long)stopwatch_mulshift.ElapsedMilliseconds);
        
        Console.WriteLine("\n\n\n\n");

        //Opgave 3
        int n = 1<<21;
        int limit = 21;
        string Opgave3 = "Data/Opgave3.txt";
        File.WriteAllText(Opgave3, "");
        
        for (int b = 1; b<= limit; b++){
            stopwatch_mulshift.Restart();
            HashTable hash_table_shift = new HashTable(hash_multiply_shift, b);
            IEnumerable<Tuple<ulong, int>> stream_multi_shift = GenerateStream.CreateStream(n, b);
            Console.WriteLine("Quadratic sum mulshift: {0}, l:{1}\n", hash_table_shift.quadratic_sum(stream_multi_shift), b);
            File.AppendAllText(Opgave3,  "Quadratic sum mulshift: "+hash_table_shift.quadratic_sum(stream_multi_shift)+" l: "+ b);
            stopwatch_mulshift.Stop();
            long time = stopwatch_mulshift.ElapsedMilliseconds;
            Console.WriteLine("MultiShift time: {0}\n", time);
            File.AppendAllText(Opgave3, "\nMultiShift time: "+time+"\n");
        }
    

        Console.WriteLine("\n\n\n\n");


        for (int b = 1; b<= limit; b++){
            stopwatch_mulmodprime.Restart();
            HashTable hash_table_mod = new HashTable(hash_multiply_mod_prime, b);
            IEnumerable<Tuple<ulong, int>> stream_multi_prime = GenerateStream.CreateStream(n, b);
            Console.WriteLine("Quadratic sum mulmodprime: {0} l: {1}\n", hash_table_mod.quadratic_sum(stream_multi_prime), b);
            File.AppendAllText(Opgave3, "Quadratic sum mulmodprime: " + hash_table_mod.quadratic_sum(stream_multi_prime)+" l: " + b);
            stopwatch_mulmodprime.Stop();
            long time = stopwatch_mulmodprime.ElapsedMilliseconds;
            Console.WriteLine("MulModPrime time: {0}\n", time);
            File.AppendAllText(Opgave3, "\nMulmodprime time: " +time+ "\n");
        }


        // Opgave 7 
        n = 1<<19;
        l = 15;
        
        IEnumerable<Tuple<ulong, int>> stream_op_7 = GenerateStream.CreateStream(n, l);
        HashTable hashtable_op7 = new HashTable(hash_multiply_shift, l);
        BigInteger S = hashtable_op7.quadratic_sum(stream_op_7);
        Console.WriteLine("S of stream_op_7: {0}\n", S);
        BigInteger var_S;
        Stopwatch stopwatch = new Stopwatch(); // Create stopwatch 

        

        int[] k_array = {1<<7, 1<<10, 1<<14, 1<<19};
        foreach (int k in k_array) {
            Console.WriteLine("k: "+k);
            string filePath = "numbers.txt";
            BigInteger[] sketch_array = new BigInteger[100];
            int i = 0;
            
            stopwatch.Start();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string nospaces = line.Replace(" ", "");

                        BigInteger.TryParse((nospaces.Substring(0, 16)), System.Globalization.NumberStyles.HexNumber, null, out BigInteger a0);  
                        BigInteger.TryParse((nospaces.Substring(16, 16)), System.Globalization.NumberStyles.HexNumber, null, out BigInteger a1);
                        BigInteger.TryParse((nospaces.Substring(32, 16)), System.Globalization.NumberStyles.HexNumber, null, out BigInteger a2);
                        BigInteger.TryParse((nospaces.Substring(48, 16)), System.Globalization.NumberStyles.HexNumber, null, out BigInteger a3);  
                        
                        
                        BigInteger [] aqarray = {a0, a1, a2, a3};
                        Count_Sketch count_Sketch = new Count_Sketch (k);
                        
                        BigInteger Xn = count_Sketch.CountSketchAlgorithm(stream_op_7, aqarray);
                        sketch_array[i] = Xn; 
                        //Console.WriteLine(Xn);
                        //Console.WriteLine(sketch_array[i]);
                        //Console.WriteLine("i: " + i);
                        i++;
                        
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        
            stopwatch.Stop();
            string timer = "Data/timer_k="+k+".txt";
            File.WriteAllText(timer,  "");
            File.AppendAllText(timer,  (long)stopwatch.ElapsedMilliseconds + Environment.NewLine);


            BigInteger[] sorted_array = sketch_array;
            


            // Calculation of statistics 
            
            Array.Sort(sorted_array);

            var newArray = sorted_array.Select((x, i) => (i + 1, x)).ToArray();
            foreach ((int,ulong) element in newArray)
            {
                //Console.WriteLine("newarray: "+element);
            }

        

            // The koords of Xn
            string Eksperiment = "Data/100eksperiment_k="+k+".txt";
            File.WriteAllText(Eksperiment,  "");
            foreach ((int, ulong) element in newArray)
            {
                //Console.WriteLine(element);

                // Write the data to a text file.
                File.AppendAllText(Eksperiment,  element + Environment.NewLine);
            }
            

            //The S koords
            var newArray3 = newArray.Select((S, i) => (i + 1, S)).ToArray();
            string Eksperiment_S = "Data/100eksperiment_S_k="+k+".txt";
            File.WriteAllText(Eksperiment_S,  "");
            foreach ((int, ulong) element in newArray)
            {
                //Console.WriteLine(element);

                // Write the data to a text file.
                File.AppendAllText(Eksperiment_S,  element + Environment.NewLine);
            }


            BigInteger MSE = 0;
            for (int j = 0; j < 100; j++){
                MSE = MSE + (((BigInteger)sorted_array[j]-S)*((BigInteger)sorted_array[j]-S))/100;
            }
            Console.WriteLine("MSE: {0}", MSE);
            Console.WriteLine("S of stream_op_7: {0}", S);
            var_S = ((((BigInteger)S)*((BigInteger)S))<<1) / ((BigInteger)(k));
            Console.WriteLine("var_S of stream_op_7: {0}\n", var_S);

            BigInteger[] G1 = sketch_array.Skip(0).Take(11).ToArray();
            BigInteger[] G2 = sketch_array.Skip(11).Take(11).ToArray();
            BigInteger[] G3 = sketch_array.Skip(22).Take(11).ToArray();
            BigInteger[] G4 = sketch_array.Skip(33).Take(11).ToArray();
            BigInteger[] G5 = sketch_array.Skip(44).Take(11).ToArray();
            BigInteger[] G6 = sketch_array.Skip(55).Take(11).ToArray();
            BigInteger[] G7 = sketch_array.Skip(66).Take(11).ToArray();
            BigInteger[] G8 = sketch_array.Skip(77).Take(11).ToArray();
            BigInteger[] G9 = sketch_array.Skip(88).Take(11).ToArray();

            Array.Sort(G1);
            Array.Sort(G2);
            Array.Sort(G3);
            Array.Sort(G4);
            Array.Sort(G5);
            Array.Sort(G5);
            Array.Sort(G6);
            Array.Sort(G7);
            Array.Sort(G8);
            Array.Sort(G9);

            // Finding median value
        /*   Console.WriteLine(G1[5]);
            Console.WriteLine(G2[5]);
            Console.WriteLine(G3[5]);
            Console.WriteLine(G4[5]);
            Console.WriteLine(G5[5]);
            Console.WriteLine(G6[5]);
            Console.WriteLine(G7[5]);
            Console.WriteLine(G8[5]);
            Console.WriteLine(G9[5]); */
            
            BigInteger[] median_array = {G1[5], G2[5], G3[5], G4[5], G5[5], G6[5], G7[5], G8[5], G9[5]};
            Array.Sort(median_array);
            var newArray2 = median_array.Select((x, i) => (i + 1, x)).ToArray();


            string Eksperiment2 = "Data/median_eksperiment_k="+k+".txt";
            File.WriteAllText(Eksperiment2,  "");
            foreach ((int, ulong) element in newArray2)
            {
                //Console.WriteLine(element);

                // Write the data to a text file.
                File.AppendAllText(Eksperiment2,  element + Environment.NewLine);
            }



            var newArray4 = median_array.Select((S, i) => (i + 1, S)).ToArray();
            string Eksperiment2S = "Data/100eksperiment2_S_k="+k+".txt";
            File.WriteAllText(Eksperiment2S,  "");
            foreach ((int, ulong) element in newArray4)
            {
                //Console.WriteLine(element);

                // Write the data to a text file.
                File.AppendAllText(Eksperiment2S,  element + Environment.NewLine);
            }
            
            
            // Opgave 8, samme fremgangsmåde som i opgave 7 

        
        }
    }
}









        
