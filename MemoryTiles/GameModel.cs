using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryTiles
{
    class GameModel
    {
        private static GameModel game;

        private string[,] field;

        private Random random = new Random();

        private String choose1 = null;

        private String choose2 = null;

        private List<string> icons;

        private int elementsRemained;

        public bool CheckForWinner()
        {
            if (elementsRemained != 0) return false;
            else return true;
        }

        public int click(string text)
        {
            if (choose1 == null)
            {
                choose1 = text;
                return 0;
            }
            if (choose2 == null)
            {
                choose2 = text;
            }
            if (checkForEqual())
            {
                free();
                elementsRemained -= 2;
                return 1;
            }
            else
            {
                free();
                return 2;
            }
        }

        private void free()
        {
            choose1 = null;
            choose2 = null;
        }

        private bool checkForEqual()
        {
            return choose1 == choose2;
        }

        public string[,] Generate(int row)
        {
            elementsRemained = row * 4;
            switch (row)
            {
                case 3:
                    icons = new List<string>(Fields.Icons1);
                    break;
                case 4:
                    icons = new List<string>(Fields.Icons2);
                    break;
                case 5:
                    icons = new List<string>(Fields.Icons3);
                    break;
            }
            field = new string[row,4];
            for(int i = 0; i < field.GetLength(0); i++)
            {
                for(int j = 0; j< field.GetLength(1); j++)
                {
                    int randomNumber = random.Next(icons.Count);
                    field[i, j] = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                }
            }
            return field;
        }

        private GameModel() { }

        public static GameModel GetInstance()
        {
            if (game == null)
            {
                game = new GameModel();
            }
            return game;
        }

        public static void DestroyInstance()
        {
            game = null;
        }
    }
}
