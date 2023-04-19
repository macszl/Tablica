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

array.Add(1);
array.Add(2);
array.Add(3);
 
Console.WriteLine( "Is count equal to 3? " + Helper.isEqual(3, array.getCount()));
Console.WriteLine( "Is the first element equal to 1? " + Helper.isEqual(1, array[0]));
Console.WriteLine( "Is the second element equal to 2? " + Helper.isEqual(2, array[1]));
Console.WriteLine( "Is the third element equal to 3? " + Helper.isEqual(3, array[2]));



//sprawdzamy indexer
Console.WriteLine("Checking if the [] operator works properly.");
array = new ResizableArray<int>();

array.Add(1);
array.Add(2);
array.Add(3);

array[1] = 4;

Console.WriteLine("Is the fourth element" + Helper.isEqual(4, array[1]) );

//sprawdzamy czy zostanie zwrocony wyjatek
array = new ResizableArray<int>();
bool exceptionWasThrown = false;
try
{
    array[0] = 1;
}
catch
{
    exceptionWasThrown = true;
}
finally
{
    String output = exceptionWasThrown ? "Exception was thrown." : "Exception was not thrown.";
    Console.WriteLine(output);
}


//sprawdzamy resize
array = new ResizableArray<int>();

array.Add(1);
array.Add(2);
array.Add(3);

array[5] = 6;

Helper.isEqual(6, array[5]);
Helper.isEqual(6, arra

//sprawdzamy eventy

var array = new ResizableArray<int>();
int count = 0;

array.Changed += (sender, e) => count++;

array.Add(1);
array[0] = 2;

Helper.isEqual(2, count);
