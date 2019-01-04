using System;
using System.Text;

namespace AddTwoFloatNumbers
{
                    
  public class AddTwoFloatNumbers
{	
    public static void Main()
    {
        FloatAddition floatAdd = new FloatAddition();
        FloatDecimal floatDec = new FloatDecimal();
        Console.WriteLine("********************Enter first float number****************************");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("********************Enter second float number****************************");
        double secondNumber = double.Parse(Console.ReadLine());
        string finalBinaryResult=String.Empty;
        double finalFloatResult=0.0;
        if(firstNumber>0 && secondNumber<0)
        {
          finalBinaryResult=floatAdd.PerformAddVersion2(firstNumber,secondNumber,"second");
          finalFloatResult=floatDec.GetFloatNumber(finalBinaryResult,"second");		
        }
        else if(firstNumber<0 && secondNumber>0)
        {
          finalBinaryResult=floatAdd.PerformAddVersion2(firstNumber,secondNumber,"first");
          finalFloatResult=floatDec.GetFloatNumber(finalBinaryResult,"first");		
        }
        else if(firstNumber<0 && secondNumber<0)
        {
          finalBinaryResult=floatAdd.PerformAddVersion2(firstNumber,secondNumber,"both");
          finalFloatResult=floatDec.GetFloatNumber(finalBinaryResult,"both");		
        }
        else
        {
          finalBinaryResult=floatAdd.PerformAddVersion2(firstNumber,secondNumber,"none");
          finalFloatResult=floatDec.GetFloatNumber(finalBinaryResult,"none");		
        }
        
        if(firstNumber>=secondNumber && firstNumber>0)
        {
            Console.WriteLine("res:=> "+"+"+finalBinaryResult);
        }
        else
        {
          Console.WriteLine("res:=> " + "-" + finalBinaryResult);
        }
        Console.WriteLine(finalFloatResult);
      Console.ReadLine();
    }

} 
}
