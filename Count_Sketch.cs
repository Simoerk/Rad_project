using System.Numerics;
namespace Hashing_util;

public class Count_Sketch { 

    public int k { get; set; }
    public Count_Sketch (int k){ 
            this.k = k;
        }

    public BigInteger Algorithm1(ulong x, BigInteger[] aqarray){
        BigInteger p = (((BigInteger)1)<<89) - (ulong) 1 ; //p is 2 bitshifted which is equal to the power with 89, - 1
        BigInteger y = aqarray[aqarray.Count()-1];

        for (int i = aqarray.Count()-2; i >= 0; i--) {
                y = y * x + aqarray[i];
                y = (y & p) + (y >> 89);
            }

        if (y>=p){
            y = y-p;
        }

        return y;
    }

    //Måske skal dette typecastes til int? int hx = (int) (gx & (k-1)); int bx = (int) (gx >> (89-1));
    public (int, int) Algorithm2(ulong x, BigInteger[] aqarray){
        BigInteger gx = Algorithm1(x, aqarray);
        int hx = (int)(gx & ((BigInteger)k-1));
        int bx = (int) (gx >> (89-1));
        int sx = 1-(2*bx);
        //Console.WriteLine("sx: "+sx);
        //Console.WriteLine("bx: "+bx);
        return (hx, sx);

    }

    public BigInteger CountSketchAlgorithm( IEnumerable<Tuple<ulong, int>> stream, BigInteger[] aqarray) {
        (int, int) algo2Result;
        int[] C = new int[k];
        //indsæt værdier af strømmen i minsketch
        foreach (Tuple<ulong, int> tuple in stream){
            algo2Result = Algorithm2 (tuple.Item1, aqarray);
            C[algo2Result.Item1] += (algo2Result.Item2 * tuple.Item2);
        }
        
        //summen af alle elementer i C^2
        BigInteger CSum = 0;
        for (int i = 0; i < k; i++) {
            CSum += ((BigInteger)C[i] * (BigInteger)C[i]);
        }
        return CSum;
    }

}