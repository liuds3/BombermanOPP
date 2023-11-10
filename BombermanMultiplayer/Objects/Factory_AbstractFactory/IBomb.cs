using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BombermanMultiplayer
{
    public interface IBomb
    {

        void CalculateBombExplodeTime(int elsapedTime);

        void BombExplode(Tile[,] MapGrid, Player player1, Player player2);

        bool IsExploding();

        void UpdateAnimFrame(int elsapedTime);

        bool CheckProprietary(byte player);

        void Dispose();

        void LoadSprite(Image sprite);

        void ShowFrame(Graphics gr);

    }
}
