using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    [Serializable]
    public class GameResult
    {
        public string Player { get; set; }
        public DateTime StartTime { get; set; }
        public string GameTime { get; set; }
        public int MoveCount { get; set; }
        public GameResult()
        { }
        public GameResult(string player, DateTime startTime, string gameTime, int moveCount)
        {
            Player = player;
            StartTime = startTime;
            GameTime = gameTime;
            MoveCount = moveCount;
        }
    }
}
