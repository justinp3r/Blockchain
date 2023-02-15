using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

class Block
{   //Blueprint für jeden einzelnen Block
    public int index;
    public string data;
    public string previous_hash;
    public string own_hash;
    public DateTime time;

    //Konstruktor für den Block
    public Block(int index, string data, string previous_hash, DateTime time) 
    {
        this.index = index;
        this.data = data;
        this.time = time;
        this.previous_hash = previous_hash;
        this.own_hash = sha256(Convert.ToString(index + data + previous_hash));
    }
    //Hashfunktion mit einem SHA-2 Verfahren
    static string sha256(string secret)
    {
        using var sha256 = SHA256.Create();
        var secretBytes = Encoding.UTF8.GetBytes(secret);
        var secretHash = sha256.ComputeHash(secretBytes);
        return Convert.ToHexString(secretHash).ToLower();
    }
}
class Program
{
    //Funktion zur Erstellung eines neuen Blocks
    //Generiert für jede Eigenschaft vom Typ Block die jeweiligen Werte
    static Block generate_Block(Block recentBlock)
    {
        //Hier werden zunächst die einzelnen Eigenschaften zugewiesen
        int generateIndex = recentBlock.index+1;
        string generateData = "Ich bin Block Nummer "+generateIndex;
        string previousHash = recentBlock.own_hash;
        DateTime currently = DateTime.Now;

        //Hier wird nun ein Block mit den zuvor zugewiesenen Eigenschaften erstellt
        Block created = new Block(generateIndex,generateData,previousHash,currently);
        return created;
    }
    static void Main(string[] args)
    {
        //Der Genesisblock ist der erste, er hat einen Index von 0, und manuell selbstfestegelgte Daten
        Block Genesis = new Block(0, "5,- an Justin überwiesen", 0.ToString(),DateTime.Now);
        List<Block> Blockchain = new List<Block>() {Genesis}; //Liste (Blockchain) mit Genesisblock füllen

        for (int i = 0; i < 30; i++)
        {
            Block currentBlock = Blockchain[0]; //Hier definieren wir, welches der vorherige Block war (für die weitergabe des alten hashwertes)
            Block block_to_Add = generate_Block(currentBlock); //Den Generate Block aufrufen und den alten Block dabei weitergeben
            Blockchain.Insert(0, block_to_Add); //Block an vorderster Stelle in Liste einfügen

            //Nach jedem hinzugefügten Block wird geprüft ob dieser echt ist (unverfälscht)
            //Ist er das nciht, wird er danach wieder entfernt.
            if (Blockchain[0].previous_hash != Blockchain[1].own_hash)
            {
                throw new Exception("Ungültiger Block entdeckt, Block "+Blockchain[0].index+ " wird entfernt!");
            }

            Console.WriteLine("Block {0} - Daten: {1} - Zeit: {2}" + 
                "\nVorheriger Hash: {3}\nAktueller Hash: {4}",
                   Blockchain[0].index, Blockchain[0].data, Blockchain[0].time,
                   Blockchain[0].previous_hash, Blockchain[0].own_hash);

            Console.WriteLine();
            Thread.Sleep(1000);
        }
    }
}