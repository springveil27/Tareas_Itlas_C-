List<decimal> typedNumbers = new List<decimal>();

decimal result = 0;
int typedOption = 1;
int wantToContinue = 0;
bool running = true;


Console.WriteLine("This is the best calculator");

while (running)
{
    DisplayHeader();

    try
    {
        typedOption = Convert.ToInt32(Console.ReadLine());

        if (typedOption == 5)
        { running = false; }
        else
        {
            Console.WriteLine("Please Type the first number");
            typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

            Console.WriteLine("Please Type the second number");
            typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

            while (wantToContinue != 2)
            {
                Console.WriteLine("you want to continue inserting numbers? 1. Yes, 2. No");
                wantToContinue = Convert.ToInt32(Console.ReadLine());
                if (wantToContinue == 1)
                {
                    Console.WriteLine("Please Type another number");
                    typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));
                }
            }

            switch (typedOption)
            {
                case 1:
                    {
                        result = AddList(typedNumbers);
                    }
                    break;
                case 2:
                
                    {
                        result = SubstractList(typedNumbers);
                    }

                    break;
                case 3:
                    {
                        result = MultiplicationList(typedNumbers);
                    }

                    break;
                case 4:
                    {
                        result = DivisionList(typedNumbers);
                    }
                    break;
                default:
                    result = 0;
                    break;
            }

            Console.WriteLine($"The Result of the operation is:{result}");


        }
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"you can not divide by zero: {ex.Message}");
    }
    catch (ArithmeticException ex)
    {
        Console.WriteLine($"you can not divide by zero: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"You need to choose a correct option: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("Closing Db Conection");
    }

}
//procceess
static void AddByRef(ref decimal valueToModify, decimal value)
{
    valueToModify += value;
}

//function
static decimal Add(decimal valueToModify, decimal value)
{
    valueToModify += value;
    return valueToModify;
}

static decimal Substract(decimal valueToModify, decimal value)
{
    if (valueToModify > 0)
    {
        valueToModify -= value;
        return valueToModify;
    }
    valueToModify = value;
    return valueToModify;
}static decimal Multiplication(decimal valueToModify, decimal value)
{
    if (valueToModify > 0)
    {
        valueToModify *= value;
        return valueToModify;
    }
    valueToModify = value;
    return valueToModify;
}

static decimal Division(decimal valueToModify, decimal value)
{
    if (valueToModify > 0)
    {
        valueToModify /= value;
        return valueToModify;
    }
    valueToModify = value;
    return valueToModify;
}

static decimal AddList(List<decimal> typedNumbers)
{
    decimal result = 0;
    foreach (int typedNumber in typedNumbers)
    {
        result = Add(result, typedNumber);
        // AddByRef(ref result, typedNumber);
        // result += typedNumber;
    }
    typedNumbers.Clear();
    return result;
}
static decimal SubstractList(List<decimal> typedNumbers)
{
    decimal result = 0;
    foreach (int typedNumber in typedNumbers)
    {
        result = Substract(result, typedNumber);
        // AddByRef(ref result, typedNumber);
        // result += typedNumber;
    }
    typedNumbers.Clear();
    return result;

}
static decimal MultiplicationList(List<decimal> typedNumbers)
{
    decimal result = 0;
    foreach (int typedNumber in typedNumbers)
    {
        result = Multiplication(result, typedNumber);
        // AddByRef(ref result, typedNumber);
        // result += typedNumber;
    }
    typedNumbers.Clear();
    return result;
}

static decimal DivisionList(List<decimal> typedNumbers)
{
    decimal result = 0;
    foreach (int typedNumber in typedNumbers)
    {
        result = Division(result, typedNumber);
        // AddByRef(ref result, typedNumber);
        // result += typedNumber;
    }
    typedNumbers.Clear();
    return result;
}

static void DisplayHeader()
{
    Console.WriteLine("Please Type the option number than you want");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("1. Sum, \n2. Substract,  \n3. Multiplication,  \n4. Division,  \n5. Exit");
}