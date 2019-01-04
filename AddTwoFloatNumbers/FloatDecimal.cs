using System;
using System.Text;
public class FloatDecimal
{
     /// <summary>
     ///   This method represents conversion of binary decimal part of float number to decimal. 
     /// </summary>
     /// <param name="number"></param>
     /// <returns>int</returns>
    
    public  int BinaryToFloatDecimalPart(string sNumber)
    {
        StringBuilder number = new StringBuilder(sNumber);
        int result=0,place=1,length=number.Length;
        
        while(length!=0)
        {
            int Remainder = int.Parse(number[length-1].ToString());
            Remainder *= place;
            result += Remainder;
            place *= 2;
            length--;
         }
         return result;
   }
     /// <summary>
     ///    This method represents flipping bits from 1 to 0 and viceversa.
     /// </summary>
     /// <param name="c"></param>
     /// <returns>char</returns>
    
    public char Flip(char c)
    {
        return c=='0'?'1':'0';
    }

    
    /// <summary>
    ///   This method represents calculation of FRACTIONAL part of float number. 
    /// </summary>
    /// <param name="number"></param>
    /// <returns>string</returns>
    
    public  double CalculateFractionalPart(string sNumber)
    {
         StringBuilder number = new StringBuilder(sNumber); 
        int digits = -1,length =number.Length;
        double temp=0.0,result=0.0;
        for(int i=0;i<length;i++)
        {
             temp=int.Parse(number[i].ToString())*Math.Pow(2,digits);
             result+=temp;
             digits--;	
         }
       return result;
    }

    public double GetFloatNumber(string number,string mode)
    {
        FloatAddition floatAdd = new FloatAddition();
        String temp=String.Empty;
        int negativeNumber =number.Split('.')[0].Length;
        switch(mode)
        {
            
        case "first":
                     return BinaryToFloatDecimalPart(number.Split('.')[0])+CalculateFractionalPart(number.Split('.')[1]);
                     break;
        
        case "second":
                     return BinaryToFloatDecimalPart(number.Split('.')[0])+CalculateFractionalPart(number.Split('.')[1]);
                     break;
        case "both"  :      
                     temp =floatAdd.FindTwosComplement(number);
                     return BinaryToFloatDecimalPart(temp.Split('.')[0])+CalculateFractionalPart(temp.Split('.')[1]);
                     break;
         }
        
        
        
        return BinaryToFloatDecimalPart(number.Split('.')[0])+CalculateFractionalPart(number.Split('.')[1]);
            
    }
}