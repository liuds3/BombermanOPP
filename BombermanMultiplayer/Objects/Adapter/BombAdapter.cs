using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanMultiplayer.Objects.Adapter
{
    public class BombAdapter : IBombAdapter
    {
        private readonly Bomb _adapteeBomb;

        public BombAdapter(Bomb adapteeBomb)
        {
            _adapteeBomb = adapteeBomb;
        }

        public void Detonate()
        {
            _adapteeBomb.DetonationTime = 0;
        }
    }
}
