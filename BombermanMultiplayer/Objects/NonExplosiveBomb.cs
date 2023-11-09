using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Media;
using System.Diagnostics;
using BombermanMultiplayer.Objects.Prototype;

namespace BombermanMultiplayer
{
    [Serializable]
    public class NonExplosiveBomb : GameObject, IDisposable, IBomb, IPrototype
    {

        private int _DetonationTime = 2000;
        public bool Explosing = false;
        private int BombPower = 3;

        //Who drops the NonExplosiveBomb, player 1 = 1, player 2 = 2
        public short Proprietary;

        #region Accessors



        public int DetonationTime
        {
            get
            {
                return _DetonationTime;
            }

            set
            {
                if (_DetonationTime > 0)
                    _DetonationTime = value;
            }
        }




        #endregion

        public bool GetExplosing()
        {
            if (this.Explosing)
                return true;
            else
                return false;
        }

        public bool CheckProprietary(byte player)
        {
            if (this.Proprietary == player)
                return true;
            else
                return false;
        }
        public NonExplosiveBomb(int caseLigne, int caseCol, int totalFrames, int frameWidth, int frameHeight, int detonationTime, int TileWidth, int TileHeight, short proprietary)
            : base(caseCol * TileWidth, caseLigne * TileHeight, totalFrames, frameWidth, frameHeight)
        {
            CasePosition = new int[2] { caseLigne, caseCol };

            //Charge the sprite
            this.LoadSprite(Properties.Resources.NonExplosiveBombe);
            //Define the proprietary player (who drops this NonExplosiveBomb)
            this.Proprietary = proprietary;
            this._DetonationTime = detonationTime;

            this._frameTime = DetonationTime / 8;
        }



        public void TimingExplosion(int elsapedTime)
        {
            if (DetonationTime <= 0)
            {
                this.Explosing = true;
            }
            DetonationTime -= elsapedTime;
        }

        public void Explosion(Tile[,] MapGrid, Player player1, Player player2)
        {

            bool PropagationUP, PropagationDOWN, PropagationLEFT, PropagationRIGHT;
            PropagationUP = PropagationDOWN = PropagationLEFT = PropagationRIGHT = true;

            //Give back a bomb to the proprietary 
            if (Proprietary == 1)
            {
                player1.BombNumb++;

                if (player1.BonusSlot[0] == Objects.BonusType.PowerBomb || player1.BonusSlot[1] == Objects.BonusType.PowerBomb)
                {
                    this.BombPower++;
                }
            }
            else if (Proprietary == 2)
            {
                player2.BombNumb++;

                if (player2.BonusSlot[0] == Objects.BonusType.PowerBomb || player2.BonusSlot[1] == Objects.BonusType.PowerBomb)
                {
                    this.BombPower++;
                }
            }

            MapGrid[this.CasePosition[0], this.CasePosition[1]].Occupied = false;
            MapGrid[this.CasePosition[0], this.CasePosition[1]].bomb = null;

            this.Dispose();

        }




        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).

                    this.Sprite = null;

                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~NonExplosiveBomb() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        public Objects.Prototype.IPrototype ShallowCopy()
        {
            return (NonExplosiveBomb)this.MemberwiseClone();
        }

        public Objects.Prototype.IPrototype DeepCopy()
        {
            // Perform a deep copy of the NonExplosiveBomb instance
            NonExplosiveBomb clone = new NonExplosiveBomb(
                this.CasePosition[0],
                this.CasePosition[1],
                this.totalFrames,
               2,
                2,
                this.DetonationTime,
                // Copy other properties as needed
                5,
                5,
                this.Proprietary
            );

            // If you have more properties, such as collections or other objects that need deep copying,
            // make sure to copy them here.

            return clone;
        }
        #endregion









    }
}
