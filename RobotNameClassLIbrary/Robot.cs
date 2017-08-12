using System;
using System.Collections.Generic;

namespace RobotNameClassLibrary
{
    public class Robot
    {
        public Robot()
        {
            SetName();
        }

        private string name;

        public string GetName()
        {
            return name;
        }

        public void SetName()
        {
            name = RandomChars(2) + RandomThreeDigitNumber(3);

            var robotCounter = RobotCounter.GetInstance;
            robotCounter.AddRobotName(name);

            NameUsedPreviously();
        }

        private string RandomChars(int numberOfChars)
        {
            Random random = new Random();
            string alphabetOfUppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string randomChars = ""; 

            for (int i = 0; i < numberOfChars; i++)
            {
                randomChars += alphabetOfUppers.ToCharArray()[random.Next(0, 25)];
            }

            return randomChars; 
        }

        private string RandomThreeDigitNumber(int numberOfDigits)
        {
            Random random = new Random();

            string numberString = 
                random.Next(0, Convert.ToInt32(GetMaxNumber(numberOfDigits))).ToString();

            numberString = RightPadNumberToLength(3, numberString);

            return numberString; 
        }

        private string GetMaxNumber(int numberOfDigits)
        {
            var maxNumberString = "";

            for (int i = 0; i < numberOfDigits; i++)
            {
                maxNumberString += '9';
            }

            return maxNumberString;
        }

        private string RightPadNumberToLength(int numberOfDigits, string numberString)
        {
            while (numberString.Length <= 2)
            {
                numberString += "0";
            }

            return numberString;
        }

        public void Reset()
        {
            name = "";
        }

        public void NameUsedPreviously()
        {
            var robotCounter = RobotCounter.GetInstance;

            if (robotCounter.ContainsName(name))
            {
                name = RandomChars(2) + RandomThreeDigitNumber(3);
                NameUsedPreviously();
            }
        }
    }
}
