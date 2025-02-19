using System;
public class Calculadora
{
    private double ultimoResultado;
    public double UltimoResultado
    {
        get { return ultimoResultado; }
        private set { ultimoResultado = value; }
    }

    public double Sumar(double a, double b)
    {
        UltimoResultado = a + b;
        return UltimoResultado;
    }
    public double Restar(double a, double b)
    {
        ultimoResultado = a - b;
        return ultimoResultado;
    }
    public double Multiplicar(double a, double b)
    {
        ultimoResultado = a * b;
        return ultimoResultado;
    }
    public double Dividir(double a, double b)
    {
        try
        {
            ultimoResultado = a / b;

        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
            UltimoResultado = double.NaN;
        };
        return ultimoResultado;
    }
}