using System;

namespace BombermanMultiplayer.Objects.Prototype
{
    public interface IPrototype
    {
        IPrototype ShallowCopy();
        IPrototype DeepCopy();
    }
}