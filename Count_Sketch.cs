using System.Numerics;
namespace Hashing_util;

public class Count_Sketch { 

    public int k { get; set; }
    public Count_Sketch (int k){ 
            this.k = k;
        }

    public BigInteger Algorithm1(ulong x, int l, BigInteger[] aqarray){
        BigInteger p = ((BigInteger)(1<<89)) - (ulong) 1 ; //p is 2 bitshifted which is equal to the power with 89, - 1
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
    public (int, int) Algorithm2(ulong x, int l, BigInteger[] aqarray){
        BigInteger gx = Algorithm1(x, l, aqarray);
        int hx =(int) (gx & (k-1));
        int bx = (int) (gx >> (89-1));
        int sx = 1-2*89;
        return (hx, sx);

    }

    public ulong CountSketchAlgorithm( IEnumerable<Tuple<ulong, int>> stream, BigInteger[] aqarray) {
        //h_x og s_x
        (int, int) myTuple;
        int[] C = new int[k];
        //indsæt værdier af strømmen i minsketch
        foreach (Tuple<ulong, int> tuple in stream){
            myTuple = Algorithm2 (tuple.Item1, tuple.Item2, aqarray);
            C[myTuple.Item1] += (myTuple.Item2 * tuple.Item2);
        }
        
        //summen af alle elementer i C^2
        ulong CSum = 0;
        for (int i = 0; i < k; i++) {
            CSum += (ulong)(C[i] * C[i]);
        }
        return CSum;
    }

}