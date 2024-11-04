using CA241104;
using System.Text;

List<Versenyzo> versenyzok = [];

using StreamReader sr = new("..\\..\\..\\src\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream)
{
    versenyzok.Add(new(sr.ReadLine()));
}

Console.WriteLine($"versenyzők száma: {versenyzok.Count}");

var f1 = versenyzok.Count(v => v.Kategoria == "elit");
Console.WriteLine($"elit versenyzok száma: {f1} fő");

var f2 = versenyzok.Where(v => !v.Nem).Average(v => 2014 - v.Szul);
Console.WriteLine($"női versenyzők átlag életkora: {f2:0.00} év");

var f3 = versenyzok.Sum(v => v.VersenyIdok["kerékpározás"].TotalHours);
Console.WriteLine($"kerékpározással töltött idő összesen: {f3:0.00} óra");

var f4 = versenyzok.Where(v => v.Kategoria == "elit junior").Average(v => v.VersenyIdok["úszás"].TotalMinutes);
Console.WriteLine($"átlag úszással töltött idő a 20-24es kategóriában: {f4:0.00} perc");

var f5 = versenyzok.Where(v => v.Nem).MinBy(v => v.Osszido);
Console.WriteLine($"Női győztes: {f5}");

var f6 = versenyzok.GroupBy(v => v.Kategoria);
Console.WriteLine($"A versenyt befejezők kategória szerint:");
foreach (var grp in f6)
{
    Console.WriteLine($"\t{(grp.Key)}: {grp.Count()} fő");
}

var f7 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Average(v => v.VersenyIdok["I. depó"].TotalMinutes + v.VersenyIdok["II. depó"].TotalMinutes));
Console.WriteLine($"kategóriánkénti átlag depóban töltött idő:");
foreach (var kvp in f7)
{
    Console.WriteLine($"\t{kvp.Key}: {kvp.Value:0.00}");
}