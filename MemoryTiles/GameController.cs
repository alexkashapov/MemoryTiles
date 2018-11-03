using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles
{
    class GameController
    {
        public string[,] generate(int row)
        {
            return GameModel.GetInstance().Generate(row);
        }

        public int click(string text)
        {
            return GameModel.GetInstance().click(text);
        }

        public bool checkForWinner()
        {
            return GameModel.GetInstance().CheckForWinner();
        }

        public void destroyGame()
        {
            GameModel.DestroyInstance();
        }
    }
}
