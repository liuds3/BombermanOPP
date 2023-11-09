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

        void TimingExplosion(int elsapedTime);

        void Explosion(Tile[,] MapGrid, Player player1, Player player2);

        bool GetExplosing();

        void UpdateFrame(int elsapedTime);

        bool CheckProprietary(byte player);

        void Dispose();

        void LoadSprite(Image sprite);

        void Draw(Graphics gr);

    }
}
