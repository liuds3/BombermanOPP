using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanMultiplayer.Objects.Adapter
{
    public class NoDamageBombAdapter : IBombAdapter
    {
        private readonly NoDamageBomb adaptBomb;

        public NoDamageBombAdapter(NoDamageBomb adapteeBomb)
        {
            adaptBomb = adapteeBomb;
        }

        public void Detonate()
        {
            adaptBomb.DetonationTime = 0;
        }
    }
}
