using System;
using BombermanMultiplayer;
using BombermanMultiplayer.Objects;

namespace BombermanMultiplayer
{
    public class BombermanGameFacade
    {
        private IBombAbstractFactory bombFactory;

        public BombermanGameFacade(IBombAbstractFactory factory)
        {
            bombFactory = factory;
        }

        public IBomb CreateBomb(BombType type, int caseLigne, int caseCol, int totalFrames, int frameWidth, int frameHeight, int detonationTime, int TileWidth, int TileHeight, short proprietary)
        {
            return bombFactory.CreateBomb(type, caseLigne, caseCol, totalFrames, frameWidth, frameHeight, detonationTime, TileWidth, TileHeight, proprietary);
        }

        public void ExplodeBomb(IBomb bomb, Tile[,] MapGrid, Player player1, Player player2)
        {
            bomb.Explosion(MapGrid, player1, player2);
        }
    }
}
