using System;
using System.Linq;
namespace Arithmetic_Coding
{
    class Program
    {
        static void Main(string[] args)
        {
         Console.WriteLine("Welcome To Aritmetic Coding"); 
         string Message; 
         //string NonRepeatMessage; 
         Console.WriteLine("Enter the meassage to be coded ");
          Message = Console.ReadLine();
         //Console.WriteLine("Enter the non repeated symbols");
         //NonRepeatMessage=Console.ReadLine();
         //Console.WriteLine("Enter probablity of each symbol");
         Program nn = new Program();
         string NRM = nn.gg(Message);
         Console.WriteLine(NRM);
         double[] probablities=new double[NRM.Length]; 
         for(int i =0; i<NRM.Length;i++)
            {
                double n=0;
                for(int j=0; j<Message.Length; j++)
                {
                    if(NRM[i]==Message[j])
                    {
                        
                        n=n+1;
                    } 
                    
                }
                probablities [i] = n/Message.Length;
            }
            

         
        //  
         double[] rangeUpper=new double[Message.Length];
         double[] rangeLower=new double[Message.Length];
         //Console.WriteLine(NRM.Length);
        rangeLower[NRM.Length-1]=0;
         rangeUpper[0]=1;
         for(int i=NRM.Length-1; i>0; i--)
         {
             rangeLower[i-1]=rangeLower[i]+probablities[i];
             rangeUpper[i]=rangeLower[i]+probablities[i];
         } 
        //  for(int i=0;i<NonRepeatMessage.Length;i++)
        //  {
        //     Console.WriteLine(rangeUpper[i]);
        //     Console.WriteLine(rangeLower[i]);
        //  }
        double[] Lvalue = new double[Message.Length+1]; 
        double[] Hvalue = new double[Message.Length+1];
        Lvalue[0]=0;
        Hvalue[0]=1;
        for (int i=0; i<Message.Length;i++)
        {
            for(int j=0; j<NRM.Length;j++)
            {
                if(Message[i]==NRM[j])
                {
                    Lvalue[i+1]=Lvalue[i]+(Hvalue[i]-Lvalue[i])*rangeLower[j];
                    Hvalue[i+1]=Lvalue[i]+(Hvalue[i]-Lvalue[i])*rangeUpper[j];
                }
            }
        }
        Console.WriteLine("Encoding/////////////////////////////////////");
        for(int i=0;i<=Message.Length;i++)
        {
            Console.WriteLine(Lvalue[i]);
            Console.WriteLine(Hvalue[i]);
        }
        double TAG = ((Lvalue[Message.Length]+ Hvalue[Message.Length])/2);
        //Console.WriteLine(TAG);
        double decode = TAG;
        Console.WriteLine("The TAG Is "+TAG );
        Console.WriteLine("Decoding/////////////////////////////////////");
        string Final_Result = "";
        //rangeLower[NonRepeatMessage.Length-1]=0;
         //rangeUpper[0]=1;

        for (int i=0; i<Message.Length;i++)
        {
            for(int j=0; j<NRM.Length;j++)
            {
                if(Message[i]==NRM[j])
                {  
                    
                   if(i==0)
                   {
                        decode = (decode-0)/(1-0);
                        Console.WriteLine(decode);
                   } 
                   
                   else{
                       for(int k=0; k<NRM.Length;k++)
                       {
                            if(Message[i-1]==NRM[k])
                            {
                                    decode = (decode-rangeLower[k])/(rangeUpper[k]-rangeLower[k]);
                                    Console.WriteLine(decode);
                            }
                       }    
                   }
                   for(int k=0; k<NRM.Length;k++)
                   {
                   if(rangeLower[k]<decode && rangeUpper[k]>decode)
                   {
                   Final_Result = Final_Result+NRM[k];
                   }
                   }
                   
                }
            }
        }
        Console.WriteLine("The Decoded Output Is///////////////////////");
        Console.WriteLine(Final_Result);
        
         }
         public string gg(string input)
            {
                return new string(input.ToCharArray().Distinct().ToArray());
            }
    }
    
}