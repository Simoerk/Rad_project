using Hashes;
using System.Numerics;

class HashTable{

    private IHashFunct HashFunct;

    private int l;

    private int size;

    private List<(ulong, int)>[] arrayOfLists;


    public HashTable(IHashFunct HashFunct, int l){
        this.HashFunct = HashFunct;
        this.l = l;
        size = (2 << l);
        arrayOfLists = new List<(ulong, int)>[size];
        for (int i = 0; i < size; i++){
            arrayOfLists[i] = new List<(ulong, int)>();
        }
    }
    

    
    public int get(ulong x){
        // Hashing indgående værdi
        ulong hash = HashFunct.HashFunction(x,l);
        List<(ulong, int)> list = arrayOfLists[(ulong)hash];
        foreach ((ulong, int) tuple in list){
            if (tuple.Item1 == x){
                return tuple.Item2;
            }
        } 
        return 0;  
    }

    
    public void set(ulong x, int v){
        ulong hashed_val_index = HashFunct.HashFunction(x, l) % (ulong)size;
        // Tjek om nøglen allerede er i tabellen
        for (int i = 0; i < arrayOfLists[hashed_val_index].Count; i++)
        {  
            if (arrayOfLists[hashed_val_index][i].Item1 == x)
            {
            // Nøglen findes allerede, opdater værdien
                arrayOfLists[hashed_val_index][i] = (x, v);
                return;
            }
        }
        // Nøglen findes ikke, tilføj den til listen på indekspositionen
        arrayOfLists[hashed_val_index].Add((x, v));
        
        
    }
    
    public void increment(ulong x, int d){
        
        List<(ulong, int)> listVal = arrayOfLists[HashFunct.HashFunction(x, l)];
        
        for (int i = 0; i < listVal.Count; i++)
        {
            if (listVal[i].Item1 == x)
            {
                arrayOfLists[HashFunct.HashFunction(x, l)][i] = (listVal[i].Item1, 
                listVal[i].Item2 + d);
            }
        }
    }
    
}