
ulong power(int baseNumber, int exponentNumber)
{
    if (exponentNumber == 0)
    {
        return 1;
    }
    else
    {
        return (ulong)baseNumber * power(baseNumber, exponentNumber - 1);
    }
}

ulong powerSelf(int n)
{
    return power(n, n);
}

int fibo(int n)
{
    if (n == 1)
        return 0;
    else if (n == 2)
        return 1;
    else if (n == 3)
        return 1;
    else
        return fibo(n - 1) + fibo(n - 2);
}

void getFiboList(int n, IList<int> fiboList)
{
    fiboList.Add(fibo(n));

    if (n > 1)
        getFiboList(n - 1, fiboList);
}

ulong getPowerSelfFromList(int n, IList<int> fiboList)
{
    if (n == 0)
    {
        return 0;
    }
    else
    {
        var item = fiboList.ElementAt(n - 1);
        return powerSelf(item) + getPowerSelfFromList(n - 1, fiboList);
    }
}

ulong sumaFibo3(int n)
{
    var fiboList = new List<int>();
    getFiboList(n, fiboList);

    if (n == 0)
    {
        return 0;
    }
    else
    {
        return getPowerSelfFromList(n, fiboList);
    }
}

void main()
{
    Console.WriteLine("*** Pregunta 1 : sumaFibo3 ***");
    Console.Write("Ingrese la cantidad de términos: ");

    if (!int.TryParse(Console.ReadLine(), out int n))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("(!) Error de data");
        return;
    }

    Console.WriteLine("*** Solución ***\n");

    var fibo3 = sumaFibo3(n);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"-> sumaFibo3({n}) = {fibo3}");

}

main();