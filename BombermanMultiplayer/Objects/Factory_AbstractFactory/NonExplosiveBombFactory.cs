using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanMultiplayer.Objects
{
    public class NonExplosiveBombFactory : IBombAbstractFactory
    {
        public IBomb CreateBomb(BombType type, int caseLigne, int caseCol, int totalFrames, int frameWidth, int frameHeight, int detonationTime, int TileWidth, int TileHeight, short proprietary)
        {
            switch (type)
            {
                case BombType.NonExplosive:
                default:
                    return new NonExplosiveBomb(caseLigne, caseCol, totalFrames, frameWidth, frameHeight, detonationTime, TileWidth, TileHeight, proprietary);
            }
        }
    }
}
