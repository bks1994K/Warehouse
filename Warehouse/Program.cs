// See https://aka.ms/new-console-template for more information
using Warehouse;

Console.WriteLine("Hello, World!");

Box boxA1 = new Box(11, 80, 90, 10, 13, new DateOnly(2023, 06, 20), DateType.ProductionDate);
Box boxA2 = new Box(12, 85, 55, 10, 25, new DateOnly(2023, 06, 10), DateType.ProductionDate);
Box boxA3 = new Box(13, 19, 100, 3, 99, new DateOnly(2023, 06, 01), DateType.ExpirationDate);

Box boxB1 = new Box(21, 180, 290, 100, 154, new DateOnly(2023, 05, 05), DateType.ProductionDate);
Box boxB2 = new Box(22, 185, 155, 110, 201, new DateOnly(2023, 05, 09), DateType.ExpirationDate);

Box boxC1 = new Box(31, 69, 20, 9, 2, new DateOnly(2023, 05, 25), DateType.ExpirationDate);
Box boxC2 = new Box(32, 50, 25, 5, 9, new DateOnly(2023, 05, 29), DateType.ExpirationDate);

Box boxD1 = new Box(41, 11, 10, 20, 3, new DateOnly(2023, 05, 30), DateType.ProductionDate);
Box boxD2 = new Box(42, 1, 2, 1, 4, new DateOnly(2023, 06, 02), DateType.ExpirationDate);
Box boxD3 = new Box(42, 8, 11, 20, 9, new DateOnly(2023, 05, 01), DateType.ExpirationDate);

Pallet palletA = new Pallet(100, 100, 150, 50);
Pallet palletB = new Pallet(200, 200, 300, 150);
Pallet palletC = new Pallet(300, 70, 30, 10);
Pallet palletD = new Pallet(400, 15, 20, 25);
var pallets = new List<Pallet> { palletA, palletB, palletC, palletD };

palletA.AddBoxesToPallet(new List<Box> { boxA1, boxA2, boxA3 });
palletB.AddBoxesToPallet(new List<Box> { boxB1, boxB2 });
palletC.AddBoxesToPallet(new List<Box> { boxC1, boxC2 });
palletD.AddBoxesToPallet(new List<Box> { boxD1, boxD2, boxD3});

var fileService = new FileService<Pallet>(@".\pathFile.txt");
fileService.RewriteFile(pallets);
var result = fileService.ReturnFromFile();

var allSortedPallets = pallets
    .GroupBy(p => p.ExpirationDate)
    .OrderBy(p => p.Key)
    .Select(sp => sp.OrderByDescending(b => b.Weight))
    .ToList();

foreach (var groupPallet in allSortedPallets)
{
    Console.WriteLine("Группа паллет: ");

    foreach (var pallet in groupPallet)
    {
        Console.WriteLine($"{pallet}");
    }
}

var sortedThreePallets = pallets
    .OrderBy(p => p.Boxes.MaxBy(b => b.ExpirationDate)?.ExpirationDate)
    .ThenBy(b => b.Volume)
    .Take(3)
    .ToList();

foreach (var pallet in sortedThreePallets)
{
    Console.WriteLine($"{pallet}");
}
