using data_table;

class Program
{
    static void Main(string[] args)
    {
        LSMTree lsmTree = new LSMTree();

        // Veri ekleme
        Console.WriteLine("Veri ekleniyor...");
        lsmTree.AddOrUpdate("key1", "value1");
        lsmTree.AddOrUpdate("key2", "value2");
        lsmTree.AddOrUpdate("key3", "value3");

        // Eklendiğini doğrulama
        Console.WriteLine("Eklendikten sonra sorgulama:");
        Console.WriteLine("key1: " + lsmTree.Get("key1")); // Çıktı: value1
        Console.WriteLine("key2: " + lsmTree.Get("key2")); // Çıktı: value2
        Console.WriteLine("key3: " + lsmTree.Get("key3")); // Çıktı: value3

        // Veri güncelleme
        Console.WriteLine("\nVeri güncelleniyor...");
        lsmTree.AddOrUpdate("key2", "updated_value2");

        // Güncellenmiş veriyi doğrulama
        Console.WriteLine("Güncellendikten sonra sorgulama:");
        Console.WriteLine("key2: " + lsmTree.Get("key2")); // Çıktı: updated_value2

        // Compaction işlemi
        Console.WriteLine("\nCompaction işlemi gerçekleştiriliyor...");
        lsmTree.Compact();

        // Compaction sonrası veri sorgulama
        Console.WriteLine("Compaction sonrası sorgulama:");
        Console.WriteLine("key1: " + lsmTree.Get("key1")); // Çıktı: value1
        Console.WriteLine("key2: " + lsmTree.Get("key2")); // Çıktı: updated_value2
        Console.WriteLine("key3: " + lsmTree.Get("key3")); // Çıktı: value3
    }
}