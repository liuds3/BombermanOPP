using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanMultiplayer.Objects.Strategy
{
    public class StrategyClass
    {

        private Strategy _strategy;

        public void setStrategy(Strategy strategy)
        {
            _strategy = strategy;
        }

        public void executeStrategy(Player player)
        {
            _strategy.move(player);
        }

    }
}
