﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanMultiplayer.Objects.Adapter
{
    public class BombAdapter : IBombAdapter
    {
        private readonly Bomb adaptBomb;

        public BombAdapter(Bomb adapteeBomb)
        {
            adaptBomb = adapteeBomb;
        }

        public void Detonate()
        {
            adaptBomb.DetonationTime = 0;
        }
    }
}
