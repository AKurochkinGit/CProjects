using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пятнашки
{
    [Serializable]
    class GameData
    {
        public string Player { get; set; }
        public DateTime StartTime { get; set; }
        public string GameTime { get; set; }
        public int MoveCount { get; set; }
        public GameData()
        { }
        public GameData(string player, DateTime startTime, string gameTime, int moveCount)
        {
            Player = player;
            StartTime = startTime;
            GameTime = gameTime;
            MoveCount = moveCount;
        }
    }
}
