using System;

namespace Open_Lab_05._02
{
    public class StringTools
    {
        public string NoYelling(string sentence)
        {
            for (int i = sentence.Length - 1 ; i >= 0; i--)
            {
                if (sentence[i] == '?' || sentence[i] == '!')
                {
                    if (sentence[i-1] == sentence[i])
                        sentence = sentence.Remove(i, 1);
                }
                else
                {
                    break;
                }
            }
            return sentence;
        }
    }
}
