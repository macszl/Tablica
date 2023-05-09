using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tablica;



Console.WriteLine("=== ARRAY TESTS ===");

        //sprawdzamy dodawanie
        Console.WriteLine("Checking if Add works properly.");
var array = new ResizableArray<int>();

int itemAddedCount = 0;
int sizeChangedCount = 0;
array.ItemAdded += (sender, e) => itemAddedCount++;
array.SizeChanged += (sender, e) => sizeChangedCount++;

array.Add(1);
array.Add(2);
array.Add(3);

Console.WriteLine("Is count equal to 3? " + Helper.isEqual(3, array.getCount()));
Console.WriteLine("Is the first element equal to 1? " + Helper.isEqual(1, array[0]));
Console.WriteLine("Is the second element equal to 2? " + Helper.isEqual(2, array[1]));
Console.WriteLine("Is the third element equal to 3? " + Helper.isEqual(3, array[2]));

Console.WriteLine("Was ItemAdded event called 3 times? " + Helper.isEqual(3, itemAddedCount));
Console.WriteLine("Was SizeChanged event called 3 times? " + Helper.isEqual(3, sizeChangedCount));

//sprawdzamy indexer
Console.WriteLine("Checking if the [] operator works properly.");
array = new ResizableArray<int>();

itemAddedCount = 0;
array.ItemAdded += (sender, e) => itemAddedCount++;

array.Add(1);
array.Add(2);
array.Add(3);

array[1] = 4;

Console.WriteLine("Is the second element equal to 4? " + Helper.isEqual(4, array[1]));
Console.WriteLine("Was ItemAdded event called 4 times? " + Helper.isEqual(itemAddedCount, 4));


//sprawdzamy resize
array = new ResizableArray<int>();

array.Add(1);
array.Add(2);
array.Add(3);

array[5] = 6;

Helper.isEqual(6, array[5]);
Helper.isEqual(6, array.getCount());

//sprawdzamy eventy
array = new ResizableArray<int>();
int count = 0;

array.SizeChanged += (sender, size) =>
{
    count++;
    Console.WriteLine("Size changed to: " + size);
};

array.ItemAdded += (sender, item) =>
{
    Console.WriteLine("Item added: " + item);
};

array.Add(1);
array[0] = 2;

Helper.isEqual(2, count);

//sprawdzamy, czy eventy nie są wywoływane, gdy rozmiar tablicy nie ulega zmianie
array = new ResizableArray<int>();
count = 0;

array.SizeChanged += (sender, size) =>
{
    count++;
    Console.WriteLine("Size changed to: " + size);
};

array.ItemAdded += (sender, item) =>
{
    Console.WriteLine("Item added: " + item);
};

array.Add(1);
array.Add(2);

Helper.isEqual(0, count);

//sprawdzamy, czy zdarzenie SizeChanged jest wywoływane po zmianie rozmiaru tablicy
array = new ResizableArray<int>();
count = 0;

array.SizeChanged += (sender, size) =>
{
    count++;
    Console.WriteLine("Size changed to: " + size);
};

array.Add(1);
array.Add(2);
array.Add(3);
array.Add(4);
array.Add(5);
array.Add(6);

Helper.isEqual(1, count); // event powinien być wywołany tylko raz, przy pierwszej zmianie rozmiaru tablicy

Console.WriteLine("=== END OF ARRAY TESTS ===");