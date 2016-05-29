using System;

namespace HomeWork3
{
    public static class Zodiac
    {
        public enum ZodiacSign
        {
            Aries, // (21 March-20 April)
            Taurus, // (21 April-21 May)
            Gemini, // (22 May-21 June)
            Cancer, // (22 June-22 July)
            Leo, // (23 July-22 August)
            Virgo, // (23 August-21 September)
            Libra, // (22 September-22 October)
            Scorpio, // (23 October-21 November)
            Sagittarius, // (22 November-21 December)
            Capricorn, // (22 December-20 January)
            Aquarius, // (21 January-19 February)
            Pisces, // (20 February-20 March)
        }

        public static int GetAge(DateTime birthday)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            TimeSpan span = DateTime.Now - birthday;
            return (zeroTime + span).Year - 1;
        }

        public static ZodiacSign GetZodiacSign(DateTime birthday)
        {
            if ((birthday.Month == 3 && birthday.Day >= 21) || (birthday.Month == 4 && birthday.Day <= 20))
                return ZodiacSign.Aries;
            if ((birthday.Month == 4 && birthday.Day >= 21) || (birthday.Month == 5 && birthday.Day <= 21))
                return ZodiacSign.Taurus;
            if ((birthday.Month == 5 && birthday.Day >= 22) || (birthday.Month == 6 && birthday.Day <= 21))
                return ZodiacSign.Gemini;
            if ((birthday.Month == 6 && birthday.Day >= 22) || (birthday.Month == 7 && birthday.Day <= 22))
                return ZodiacSign.Cancer;
            if ((birthday.Month == 7 && birthday.Day >= 23) || (birthday.Month == 8 && birthday.Day <= 22))
                return ZodiacSign.Leo;
            if ((birthday.Month == 8 && birthday.Day >= 23) || (birthday.Month == 9 && birthday.Day <= 21))
                return ZodiacSign.Virgo;
            if ((birthday.Month == 9 && birthday.Day >= 22) || (birthday.Month == 10 && birthday.Day <= 22))
                return ZodiacSign.Libra;
            if ((birthday.Month == 10 && birthday.Day >= 23) || (birthday.Month == 11 && birthday.Day <= 21))
                return ZodiacSign.Scorpio;
            if ((birthday.Month == 11 && birthday.Day >= 22) || (birthday.Month == 12 && birthday.Day <= 21))
                return ZodiacSign.Sagittarius;
            if ((birthday.Month == 12 && birthday.Day >= 22) || (birthday.Month == 1 && birthday.Day <= 20))
                return ZodiacSign.Capricorn;
            if ((birthday.Month == 1 && birthday.Day >= 21) || (birthday.Month == 2 && birthday.Day <= 19))
                return ZodiacSign.Aquarius;
            return ZodiacSign.Pisces;
        }

    }
}