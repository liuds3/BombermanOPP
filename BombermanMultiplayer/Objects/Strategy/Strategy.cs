using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanMultiplayer.Objects.Strategy
{
    public interface Strategy
    {
        void move(Player player);
    }
}
