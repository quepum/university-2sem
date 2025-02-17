using System.Net.Mime;

var array = new int[10];
string str = Console.ReadLine();
if (str is null)
{
    Console.WriteLine("Всё плохо");
    return -1;
}

var str1 = str.Split(' ');
var res = new int[str1.Length];

for (var i = 0; i < res.Length; i++)
{
    if (int.TryParse(str1[i], out int result))
    {
        res[i] = result;
    }
}

for (var i = 0; i < array.Length; i++)
{
    array[i] = array.Length - i;
}

// BubbleSort(array);
// ShowArray(array);
// Console.Write($"mean - {Math(array).Mean}\ndispersion - {Math(array).Dispersion}");

static void BubbleSort(int[] array)
{
    for (var i = 0; i < array.Length; i++)
    {
        for (var j = i + 1; j < array.Length; j++)
        {
            if (array[i] > array[j])
            {
                Swap(array, i, j);
            }
        }
    }
}

static void Swap(int[] array, int pos1, int pos2) => (array[pos1], array[pos2]) = (array[pos2], array[pos1]);

static void ShowArray(int[] array)
{
    foreach (var element in array)
    {
        Console.Write($"{element}\n");
    }
}

(float Mean, double Dispersion) Math(int[] array1)
{
    var mean = array1.Sum() / (float)array1.Length;
    var dispersion = array1.Sum(t => System.Math.Pow(t - mean, 2));
    dispersion /= array1.Length - 1;
    return (mean, dispersion);
}

return 1;