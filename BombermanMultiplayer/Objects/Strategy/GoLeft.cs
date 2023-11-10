using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BombermanMultiplayer.Objects.Strategy
{
    public class GoLeft : Strategy
    { 

        public void move(Player player)
        {
            player.DeplGauche();
        }

    }
}
