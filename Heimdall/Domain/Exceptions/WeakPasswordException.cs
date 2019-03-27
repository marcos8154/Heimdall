using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Domain.Exceptions
{
    public class WeakPasswordException : Exception
    {

        public WeakPasswordException(string message,
            int minLenght = 1, int maxLenght = 10, int minLettersCount=1,
            int minNumberCount = 1, int minSpecialCharsCount = 1)
            : base(message)
        {
            MinLenght = minLenght;
            MaxLenght = maxLenght;
            MinLettersCount = minLettersCount;
            MinNumberCount = minNumberCount;
            MinSpecialCharsCount = minSpecialCharsCount;
        }

        public int MinLenght { get; }
        public int MaxLenght { get; }
        public int MinLettersCount { get; }
        public int MinNumberCount { get; }
        public int MinSpecialCharsCount { get; }
    }
}
