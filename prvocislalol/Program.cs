using System.Diagnostics;
using System.Reflection;

double prumernycas = 0;
long maxprvocislo = 0;
string jmenosouboru = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\prvocisla.txt";

for (int i = 0; i < 1000; i++)
{
    Stopwatch sw = Stopwatch.StartNew();
    Random random = new Random();
    long cislo = 0;
    long generacecisla = 0;
    do
    {
        generacecisla += 1;
        cislo = random.NextInt64(0, long.MaxValue);
    } while (!jeprvocislo(cislo));
    sw.Stop();

    prumernycas += sw.Elapsed.TotalMilliseconds;
    if(cislo > maxprvocislo)
    {
        maxprvocislo = cislo;
    }

    using (StreamWriter streamwr = File.AppendText(jmenosouboru))
    {
        streamwr.WriteLine("Počet generace: {0}", i);
        streamwr.WriteLine("Číslo: {0}", cislo);
        streamwr.WriteLine("Zabraný čas: {0}ms", sw.Elapsed.TotalMilliseconds);
        streamwr.WriteLine("Kolikrát regenerováno: {0}", generacecisla);
        streamwr.WriteLine("----------------");
    }

}


using (StreamWriter streamwr = File.AppendText(jmenosouboru))
{
    streamwr.WriteLine("----------------");
    streamwr.WriteLine("Průměrný čas: " + prumernycas / 1000 + "ms");
    streamwr.WriteLine("Největší prvočíslo: " + maxprvocislo);
    streamwr.WriteLine("----------------");
}
Console.WriteLine("Průměrný čas: " + prumernycas / 1000 + "ms");
Console.WriteLine("Největší prvočíslo: " + maxprvocislo);
Console.ReadLine();

bool jeprvocislo(long cislo)
{
    if (cislo == 1) return false;
    if (cislo == 2) return true;

    var limit = Math.Sqrt(cislo);

    if (cislo % 2 == 0)
    {
        return false;
    }

    for (int i = 3; i <= limit; i += 2)
        if (cislo % i == 0)
            return false;
    return true;
}