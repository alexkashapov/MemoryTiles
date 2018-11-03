using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles
{
    class Fields
    {
        //поле 3x4
        private static List<string> icons1 = new List<string>()
        {
            "?","?",
            "n","n",
            "u","u",
            "i","i",
            "l","l",
            "q","q",
        };

        //поле 4x4
        private static List<string> icons2 = new List<string>()
        {
            "!", "!",
            "N", "N",
            ",", ",",
            "k", "k",
            "b", "b",
            "v", "v",
            "w", "w",
            "z", "z"
        };

        //поле 5x4
        private static List<string> icons3 = new List<string>()
        {
            "'","'",
            "o","o",
            "p","p",
            "[","[",
            ">",">",
            "<","<",
            "e","e",
            "f","f",
            "d","d",
            "r","r",
        };

        public static List<string> Icons1 { get => icons1; }
        public static List<string> Icons2 { get => icons2; }
        public static List<string> Icons3 { get => icons3; }
    }
}
