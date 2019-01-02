using System;
using System.Text;
					
public class AddTwoFloatNumbers
{	
	// This method represents calculation of DECIMAL part of float number.
	public static int CalculateDecimalPart(double number)
	{
		int result=0,place=1; 
	    int decimalPart =(int)Math.Truncate(number);	
		while(decimalPart!=0)
	    {
			int Remainder = decimalPart%2;
			decimalPart /= 2;
			result += Remainder*place;
			place *= 10;
	     }
		 return result;
   }
		// This method represents flipping bits from 1 to 0 and viceversa.
	public static char Flip(char c)
	{
		return c=='0'?'1':'0';
	}
	// This method represents to find Twos complement of a number.
	public static string FindTwosComplement(String tempNumber)
	{
		StringBuilder number=new StringBuilder(tempNumber);
		int temp=0,length=number.Length;
	    for(int i=0;i<number.Length;i++)
		{
			  number[i] = number[i]!='.'?Flip(number[i]):'.';
		}
		for(int i=length-1;i>=0;i--)
		{
			if(number[i]!='.')
			{
			  if(number[i]=='1')
			  {
			   number[i]='0';
			   }
			  else if(number[i]=='0')
			   {
			     number[i]='1';
				 break;
			   }
			 }	
		}
		return number.ToString();
	}
	
	// This method represents calculation of FRACTIONAL part of float number.
	public static string CalculateFractionalPart(double number)
	{
		double fractionalPart = number-(int)Math.Truncate(number);
	    int digits = 1,integerPart=0;
		String a=String.Empty;
		while ((digits < 32))
		{
		  fractionalPart = fractionalPart * 2;
          integerPart = (int)fractionalPart;
		  a+=integerPart;	
		  fractionalPart = fractionalPart - integerPart;
		  digits++;	
		 }
	   return a;
	}
	// This method is mainly implemented to populate bits(padding of bits).
	public static string PopulateBits(String s,int num,bool isDecimal)
	{
		string a=String.Empty;
		while(num!=0)
	     {
	         a+='0';
		     num--;
	     }
		if(isDecimal)
		{
	        s=a+s;
		}
		else
		{
		   s=s+a;
		}
	  
		return s;
	}
	// This method represents concatenation of DECIMAL and FRACTIONAL part of float number.
	public static string GetBinaryNumbers(double firstNumber,double secondNumber, string isType)
	{
		int sizeOfFirstDecimalBits=0,sizeOfSecondDecimalBits=0,sizeOfFirstFractionalBits=0,sizeOfSecondFractionalBits=0;
		String firstBinaryNumber=String.Empty,secondBinaryNumber=String.Empty;
		String sFirstDecimalPart  = CalculateDecimalPart(firstNumber).ToString();
		String sSecondDecimalPart = CalculateDecimalPart(secondNumber).ToString();
		String sFirstFractionalPart=CalculateFractionalPart(firstNumber).ToString();
		String sSecondFractionalPart=CalculateFractionalPart(secondNumber).ToString();
		sizeOfFirstDecimalBits =sFirstDecimalPart.Length;
		sizeOfSecondDecimalBits =sSecondDecimalPart.Length;
		sizeOfFirstFractionalBits =sFirstFractionalPart.Length;
		sizeOfSecondFractionalBits =sFirstFractionalPart.Length;
		if(isType=="first")
		{
			 sFirstDecimalPart = FindTwosComplement(sFirstDecimalPart+"."+sFirstFractionalPart).Split('.')[0];
		     sFirstFractionalPart = FindTwosComplement(sFirstDecimalPart+"."+sFirstFractionalPart).Split('.')[1]; 
			 sizeOfFirstDecimalBits =sFirstDecimalPart.Length;
			 sizeOfFirstFractionalBits =sFirstFractionalPart.Length;
		}
		else if(isType=="second")
		{
		    sSecondDecimalPart = FindTwosComplement(sSecondDecimalPart+"."+sFirstFractionalPart).Split('.')[0];
		    sSecondFractionalPart = FindTwosComplement(sSecondDecimalPart+"."+sFirstFractionalPart).Split('.')[1]; 
			sizeOfSecondDecimalBits =sSecondDecimalPart.Length;
		    sizeOfSecondFractionalBits =sSecondFractionalPart.Length;
		}	
		
		if(sizeOfFirstDecimalBits > sizeOfSecondDecimalBits)
		{
		  sSecondDecimalPart = PopulateBits(sSecondDecimalPart,sizeOfFirstDecimalBits-sizeOfSecondDecimalBits,true);
		}
		else
		{
          sFirstDecimalPart=PopulateBits(sFirstDecimalPart,sizeOfSecondDecimalBits-sizeOfFirstDecimalBits,true);		
		}
		if(sizeOfFirstFractionalBits>sizeOfSecondFractionalBits)
		{
		  sSecondFractionalPart = PopulateBits(sSecondFractionalPart,sizeOfFirstFractionalBits-sizeOfSecondFractionalBits,false);
		}
		else
		{
          sFirstFractionalPart=PopulateBits(sFirstFractionalPart,sizeOfSecondFractionalBits-sizeOfFirstFractionalBits,false);		
		}
	      firstBinaryNumber = sFirstDecimalPart +"." + sFirstFractionalPart;
		  secondBinaryNumber = sSecondDecimalPart+"."+sSecondFractionalPart;
		
       return firstBinaryNumber+";"+secondBinaryNumber;
	}
	
	// This method represents Bitwise addition of two float numbers.	
	public static string PerformAddVersion2(double firstNumber,double secondNumber,string isType)
	{
		   double first=firstNumber,second=secondNumber;
		    String twoNumberStrings = GetBinaryNumbers(Math.Abs(firstNumber),Math.Abs(secondNumber),isType);
		    String firstBinaryNumber =twoNumberStrings.Split(';')[0];
			String secondBinaryNumber =twoNumberStrings.Split(';')[1];
		    int carry=0,length=secondBinaryNumber.Length;
		    Console.WriteLine();
		    Console.WriteLine("1st:=> "+(first>0?"+"+firstBinaryNumber:"-"+firstBinaryNumber));
		    Console.WriteLine("2nd:=> "+(second>0?"+"+secondBinaryNumber:"-"+secondBinaryNumber));
		    Console.WriteLine("       ------------------------------------");
		    StringBuilder sb=new StringBuilder(secondBinaryNumber);
		for(int i = length-1;i>=0;i--)
		{
				if((firstBinaryNumber[i]=='0' && secondBinaryNumber[i]=='1') ||(firstBinaryNumber[i]=='1' && secondBinaryNumber[i]=='0'))
		       {
			     if(carry==0)
			     {
				   sb[i]='1';
			     }
					else
					{
				      sb[i]='0';	
					}
		        }
			else if(firstBinaryNumber[i]=='1' && secondBinaryNumber[i]=='1')
		    {
				if(carry==0)
			   {
				   sb[i]='0';
					carry=1;
			   }
			   else
			   { 
					     sb[i]='1';
		             	 carry=1;
			    }
		    }
			else
			{
				if((carry==1) && ( (firstBinaryNumber[i]!='.') && (secondBinaryNumber[i]!='.') ) )
			     {
			      sb[i]='1';
				  carry=0;
			      }
		    }
	     }
		if(isType=="none")
		{
		  return  carry+sb.ToString();		
		}
		else if(isType=="both")
		{
		return FindTwosComplement(carry+sb.ToString()); 
		}
		else
		{
		  if(carry==1)
		  {
		    return sb.ToString();
		  }
		  else
		  {
		    return FindTwosComplement("-"+sb.ToString());
		  }
		}
	}
	public static void Main()
	{
		Console.WriteLine("Enter two float numbers");
		double firstNumber = double.Parse(Console.ReadLine());
		double secondNumber = double.Parse(Console.ReadLine());
		string finalResult=String.Empty;
		if(firstNumber>0 && secondNumber<0)
		{
	      finalResult=PerformAddVersion2(firstNumber,secondNumber,"second");		
		}
		else if(firstNumber<0 && secondNumber>0)
		{
	      finalResult=PerformAddVersion2(firstNumber,secondNumber,"first");		
		}
		else if(firstNumber<0 && secondNumber<0)
		{
	      finalResult=PerformAddVersion2(firstNumber,secondNumber,"both");		
		}
		else
		{
		  finalResult=PerformAddVersion2(firstNumber,secondNumber,"none");		
		}
		
		if(firstNumber>=secondNumber && firstNumber>0)
		{
			Console.WriteLine("res:=> "+"+"+finalResult);
		}
		else
		{
		  Console.WriteLine("res:=> " + "-" + finalResult);
		}
	}
}