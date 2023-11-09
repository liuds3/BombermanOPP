using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombermanMultiplayer.Objects;

namespace BombermanMultiplayer.Objects.Facade
{
    public class BombermanFacade
    {
        private NonExplosiveBombFactory nonExplosiveBombFactory;
        private BombFactory bombFactory;
        private Player player;

        public BombermanFacade()
        {
            nonExplosiveBombFactory = new NonExplosiveBombFactory();
            bombFactory = new BombFactory();
            player = new Player(1, 2, 33, 33, 1, 1, 48, 48, 80, 1);
        }

       
        public void CreateNonExplosiveBomb(int row, int column)
        {
         
            nonExplosiveBombFactory.CreateBomb(BombType.NonExplosive, row, column, 8, 48, 48, 2000, 48, 48, 1);
        }

        public void CreateExplosiveBomb(int row, int column)
        {
            
            bombFactory.CreateBomb(BombType.Explosive, row, column, 8, 48, 48, 2000, 48, 48, 1);
        }

        public void MovePlayer(Player.MovementDirection direction)
        {
         
            player.Orientation = direction;
            player.Move();
        }

    }
}
