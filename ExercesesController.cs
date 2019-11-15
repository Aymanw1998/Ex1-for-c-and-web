using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EX1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercesesController : ControllerBase
    {

        //4,10,13,16,18





        //Exercese 4 (1)
        
        //api/Exerceses/PrintOddWords
        
        [HttpGet("PrintOddWords")]
        public string PrintOddWords (string sentence) //Accepts a sentence and returns the odd Worlds
        {
   
            if (sentence == null) { 
                
                    return "ERROR1: Not sent to a value server\n" +
                            "Or\n" +
                            "You have a problem with RS:querystring\n" +
                                         "\t The currect queryatring is: /api/Exerceses/PrintOddWords?sentence=value"; 
            
            }

            //if sentence not null...
            string result="";int i = 1;                                          //'i' is For counting the sentece and understanding when the words in odd plac
            
            var sentenceArrays = sentence.Split(' ');
            
            foreach (var str in sentenceArrays) {                              //This loop is about keep the words in Odd place
                    if (i++ % 2 == 1)
                            result+= str+ ' ';
            }
                
            return result;

        }



        //Exercese 10 (2)
        //api/Exerceses/wordsChartoInt

        [HttpGet("wordsChartoInt")]
        public List<int> wordsChartoInt(string word)
        {
            var list = new List<int>();
            
            if (word == null)
            {list.Add(-1); return list;}
           
            //if sentence not null ...
            word = word.ToLower();
            
            foreach (char str in word)
                    list.Add(Convert.ToInt32(str) - 96);
            
            return list;
        
        }




        //Exercese 13 (3)
        //api/Exerceses/calculator
        
        [HttpGet("calculator")]
        public List<float> calculator(float num1, float num2)
        {                                   // if num2 =0 so the Divide is null becouse 1/0 = no answer -
                                            // so if num2 =0 I will return in index for to Divide the zero (0) like null
            var list = new List<float>();
            if (num1 == 0 && num2 == 0)
            {
                    int i = 4;
                    
                    while ((i--) !=0)
                            list.Add(0);
                    
                return list;
            }
            
            //if sentence not null ...          // My Ansower like this:  [(+),(-),(*),(/)]

            list.Add(num1 + num2);              // Connecting two numbers
            list.Add(num1 - num2);              // Subtracting two numbers
            list.Add(num1 * num2);              // Multiply two numbers
            if (num2 == 0)
            {
                list.Add(0);                   //לא נתן לחישוב 
            }
            else
            {
                list.Add(num1 / num2);// Divide two numbers
            }
            return list;
        }




        //Exercese 16 (4)
        //api/Exerceses/MinNumber
        
        [HttpGet("MinNumber")]
        public float MinNumber(float num1, float num2, float num3, float num4)
        {
            float min = num1; float[]array = {num2, num3, num4};
            
            for (int i = 0; i <3; i++)
            {
                    if(min > array[i])
                        min = array[i];
            }
            return min;
        }


        //Exercese 18 (5)
        //api/Exerceses/PrintWordInSentence
        [HttpGet("PrintWordInSentence")]
        public string PrintWordInSentence(string sentence, int index) //Accepts a sentence and returns the odd Worlds
        {
            var sentenceArrays = sentence.Split(' ');
            
            if (sentence == null || index==0 || sentenceArrays.Length < index)
            {
             
                    return "ERROR1: Not sent to a value server\n" +
                            "Or\n" +
                            "index is greater than the length of the sentence\nOr\n"+
                            "You have a problem with RS:querystring\n" +
                                     "\t The currect queryatring is: /api/Exerceses/PrintWordInSentence?sentence=value&index=(Number>0)";
            }

            //if sentence not null...
            string result = ""; int i = 1;                                                          //'i' is For counting the sentece and understanding when the word has same index  
            foreach (var str in sentenceArrays)
            {                              
                    if (i++ == index)
                        result += str;
            }
            
            return result;
        }
    }
}