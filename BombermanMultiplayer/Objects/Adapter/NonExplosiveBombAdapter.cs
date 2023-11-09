using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanMultiplayer.Objects.Adapter
{
    public class NonExplosiveBombAdapter : IBombAdapter
    {
        private readonly NonExplosiveBomb _adapteeBomb;

        public NonExplosiveBombAdapter(NonExplosiveBomb adapteeBomb)
        {
            _adapteeBomb = adapteeBomb;
        }

        public void Detonate()
        {
            _adapteeBomb.DetonationTime = 0;
        }
    }
}
