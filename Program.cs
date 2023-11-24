using System;

// Определение делегата
public delegate double MathOperation(double x, double y);

class Program
{
    // Статические методы для выполнения арифметических операций
    public static double Add(double x, double y) => x + y;
    public static double Subtract(double x, double y) => x - y;
    public static double Multiply(double x, double y) => x * y;
    public static double Divide(double x, double y) => y != 0 ? x / y : double.NaN;

    // Метод для выполнения операции, представленной делегатом
    public static double PerformOperation(double x, double y, MathOperation operation)
    {
        return operation(x, y);
    }

    static void Main()
    {
        // Создание экземпляров делегата, инициализированных методами
        MathOperation addOperation = Add;
        MathOperation subtractOperation = Subtract;
        MathOperation multiplyOperation = Multiply;
        MathOperation divideOperation = Divide;

        // Использование делегатов
        Console.WriteLine("Using delegates:");
        Console.WriteLine($"Add: {PerformOperation(5, 3, addOperation)}");
        Console.WriteLine($"Subtract: {PerformOperation(5, 3, subtractOperation)}");
        Console.WriteLine($"Multiply: {PerformOperation(5, 3, multiplyOperation)}");
        Console.WriteLine($"Divide: {PerformOperation(5, 3, divideOperation)}");

        // Использование анонимных методов
        MathOperation anonymousAdd = delegate (double x, double y) { return x + y; };
        Console.WriteLine("\nUsing anonymous methods:");
        Console.WriteLine($"Add: {PerformOperation(5, 3, anonymousAdd)}");

        // Использование лямбда-выражений
        MathOperation lambdaSubtract = (x, y) => x - y;
        Console.WriteLine("\nUsing lambda expressions:");
        Console.WriteLine($"Subtract: {PerformOperation(5, 3, lambdaSubtract)}");

        // Цепочка делегатов
        MathOperation chainedOperations = addOperation + subtractOperation + multiplyOperation;
        Console.WriteLine("\nChained delegates:");
        Console.WriteLine($"Chained result: {chainedOperations(5, 3)}");

        Console.ReadLine();
    }
}
