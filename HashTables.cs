using Hashes;
using System.Numerics;

class HashTable{

    private IHashFunct HashFunct { get; set; }

    private int l { get; set; }

    private int size { get; set; }

    private List<(ulong, int)>[] arrayOfLists { get; set; }


    public HashTable(IHashFunct HashFunct, int l){
        this.HashFunct = HashFunct;
        this.l = l;
        size = (1 << l);
        arrayOfLists = new List<(ulong, int)>[size];
        for (int i = 0; i < size; i++){
            arrayOfLists[i] = new List<(ulong, int)>();
        }
    } 
    

    
    public int get(ulong x){
        // Hashing indgående værdi
        ulong hash = HashFunct.HashFunction(x,l);
        List<(ulong, int)> list = arrayOfLists[(ulong)hash];
        // Gennemgår listen for at finde matchende nøgle
        foreach ((ulong, int) tuple in list){
            // Hvis nøglen matcher, returner den tilsvarende værdi
            if (tuple.Item1 == x){
                return tuple.Item2;
            }
        } 
        // Hvis nøglen ikke findes, returner 0
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
        ulong hash = HashFunct.HashFunction(x, l);
        List<(ulong, int)> listVar = arrayOfLists[hash];
        for (int i = 0; i < arrayOfLists[hash].Count; i++){
            if (arrayOfLists[hash][i].Item1 == x){
            arrayOfLists[hash][i] = (x, (arrayOfLists[hash][i].Item2 + d));
            return;
            }
        }
        arrayOfLists[hash].Add((x,d));
    }
    

    public BigInteger quadratic_sum(IEnumerable<Tuple<ulong, int>> stream){
        //Console.WriteLine("Start");
        foreach (Tuple< ulong, int > key in stream){
            this.increment(key.Item1, key.Item2);
        } 
        // Console.WriteLine("Done incrementing.\n");
        ulong counter = 0;
        //for hver indgang i hash tabellen
        foreach (List<(ulong, int)> list in arrayOfLists){
            //Console.WriteLine("Secondloop");
            //Console.WriteLine(list.Count);
            for (int i = 0; i<list.Count; i++ ){
                counter += (ulong)list[i].Item2 * (ulong)list[i].Item2;
                //Console.WriteLine("Second loop inner");
            }
        }   
        return counter;
    }






}