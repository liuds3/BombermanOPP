﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Media;
using System.Diagnostics;

namespace BombermanMultiplayer
{
    [Serializable]
    public class LongTimeBomb : GameObject, IDisposable, IBomb
    {

        private int _DetonationTime = 4000;
        public bool Explosing = false;
        private int BombPower = 5;

        //Who drops the Bomb2, player 1 = 1, player 2 = 2
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

        public bool IsExploding()
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
        public LongTimeBomb(int caseLigne, int caseCol, int totalFrames, int frameWidth, int frameHeight, int detonationTime, int TileWidth, int TileHeight, short proprietary)
            : base(caseCol * TileWidth, caseLigne * TileHeight, totalFrames, frameWidth, frameHeight)
        {
            CasePosition = new int[2] { caseLigne, caseCol };

            //Charge the sprite
            this.LoadSprite(Properties.Resources.Bombee);
            //Define the proprietary player (who drops this Bomb2)
            this.Proprietary = proprietary;
            this._DetonationTime = detonationTime;

            this._frameTime = DetonationTime / 8;
        }



        public void CalculateBombExplodeTime(int elsapedTime)
        {
            if (DetonationTime <= 0)
            {
                this.Explosing = true;
            }
            DetonationTime -= elsapedTime;
        }

        public void BombExplode(Tile[,] MapGrid, Player player1, Player player2)
        {
            int variablePosition = 0;

            bool PropagationUP, PropagationDOWN, PropagationLEFT, PropagationRIGHT;
            PropagationUP = PropagationDOWN = PropagationLEFT = PropagationRIGHT = true;


            //Give back a Bomb2 to the proprietary 
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

            //Check if player
            if (this.CasePosition == player1.CasePosition
                && player1.BonusSlot[0] != Objects.BonusType.Armor && player1.BonusSlot[1] != Objects.BonusType.Armor)
            {
                player1.Dead = true;
                player1.LoadSprite(Properties.Resources.Blood);
            }
            if (this.CasePosition == player2.CasePosition
                && player2.BonusSlot[0] != Objects.BonusType.Armor && player2.BonusSlot[1] != Objects.BonusType.Armor)
            {
                player2.Dead = true;
                player2.LoadSprite(Properties.Resources.Blood);
            }


            for (int i = 0; i < this.BombPower; i++)
            {

                //UP
                //If there's nothing undestroyable obstruing the path of the BombExplode
                if (PropagationUP)
                {

                    //If not out of bounds
                    if ((variablePosition = this.CasePosition[0] - i) <= MapGrid.GetLength(0) - 1)
                    {
                        //if destroyable block
                        if (MapGrid[variablePosition, this.CasePosition[1]].Destroyable == true)
                        {
                            MapGrid[variablePosition, this.CasePosition[1]].Destroyable = false;
                            MapGrid[variablePosition, this.CasePosition[1]].Walkable = true;
                            MapGrid[variablePosition, this.CasePosition[1]].Fire = true;
                            MapGrid[variablePosition, this.CasePosition[1]].SpawnBonus();

                        }
                        else if (!MapGrid[variablePosition, this.CasePosition[1]].Destroyable && MapGrid[variablePosition, this.CasePosition[1]].Walkable)
                        {
                            //If free case 
                            MapGrid[variablePosition, this.CasePosition[1]].Fire = true;


                        }
                        else if (!MapGrid[variablePosition, this.CasePosition[1]].Destroyable && !MapGrid[variablePosition, this.CasePosition[1]].Walkable)
                        {
                            PropagationUP = false;
                        }
                    }

                }


                //DOWN
                if (PropagationDOWN)
                {

                    //If not out of bounds
                    if ((variablePosition = this.CasePosition[0] + i) >= 0)
                    {
                        //if destroyable block
                        if (MapGrid[variablePosition, this.CasePosition[1]].Destroyable == true)
                        {
                            MapGrid[variablePosition, this.CasePosition[1]].Destroyable = false;
                            MapGrid[variablePosition, this.CasePosition[1]].Walkable = true;
                            MapGrid[variablePosition, this.CasePosition[1]].Fire = true;
                            MapGrid[variablePosition, this.CasePosition[1]].SpawnBonus();

                        }
                        else if (!MapGrid[variablePosition, this.CasePosition[1]].Destroyable && MapGrid[variablePosition, this.CasePosition[1]].Walkable)
                        {
                            //If free case 
                            MapGrid[variablePosition, this.CasePosition[1]].Fire = true;


                        }
                        else if (!MapGrid[variablePosition, this.CasePosition[1]].Destroyable && !MapGrid[variablePosition, this.CasePosition[1]].Walkable)
                        {
                            PropagationDOWN = false;
                        }

                    }

                }

                //LEFT
                if (PropagationLEFT)
                {
                    //If not out of bounds
                    if ((variablePosition = this.CasePosition[1] - i) >= 0)
                    {
                        //if destroyable block
                        if (MapGrid[this.CasePosition[0], variablePosition].Destroyable == true)
                        {
                            MapGrid[this.CasePosition[0], variablePosition].Destroyable = false;
                            MapGrid[this.CasePosition[0], variablePosition].Walkable = true;
                            MapGrid[this.CasePosition[0], variablePosition].Fire = true;
                            MapGrid[this.CasePosition[0], variablePosition].SpawnBonus();

                        }
                        else if (MapGrid[this.CasePosition[0], variablePosition].Destroyable == false && MapGrid[this.CasePosition[0], variablePosition].Walkable)
                        {
                            //If free case 
                            MapGrid[this.CasePosition[0], variablePosition].Fire = true;


                        }
                        else if (!MapGrid[this.CasePosition[0], variablePosition].Destroyable && !MapGrid[this.CasePosition[0], variablePosition].Walkable)
                        {
                            PropagationLEFT = false;
                        }

                    }
                }
                //RIGHT
                if (PropagationRIGHT)
                {
                    //If not out of bounds
                    if ((variablePosition = this.CasePosition[1] + i) <= MapGrid.GetLength(1) - 1)
                    {
                        //if destroyable block
                        if (MapGrid[this.CasePosition[0], variablePosition].Destroyable == true)
                        {
                            MapGrid[this.CasePosition[0], variablePosition].Destroyable = false;
                            MapGrid[this.CasePosition[0], variablePosition].Walkable = true;
                            MapGrid[this.CasePosition[0], variablePosition].Fire = true;
                            MapGrid[this.CasePosition[0], variablePosition].SpawnBonus();
                        }
                        else if (MapGrid[this.CasePosition[0], variablePosition].Destroyable == false && MapGrid[this.CasePosition[0], variablePosition].Walkable)
                        {
                            //If free case 
                            MapGrid[this.CasePosition[0], variablePosition].Fire = true;


                        }
                        else if (!MapGrid[this.CasePosition[0], variablePosition].Destroyable && !MapGrid[this.CasePosition[0], variablePosition].Walkable)
                        {
                            PropagationRIGHT = false;
                        }

                    }
                }
            }

            MapGrid[this.CasePosition[0], this.CasePosition[1]].Occupied = false;
            MapGrid[this.CasePosition[0], this.CasePosition[1]].bomb = null;


            this.Dispose();

        }

        public LongTimeBomb Clone()
        {
            return (LongTimeBomb)this.MemberwiseClone();
        }


        //public Bomb2 Clone()
        //{
        //    // Create a new instance of Bomb2 and copy the properties
        //    Bomb2 newBomb2 = (Bomb2)this.MemberwiseClone();

        //    // Perform a deep copy of properties that are reference types
        //    newBomb2.Sprite = this.Sprite != null ? (Image)this.Sprite.Clone() : null;

        //    // Return the deep copy
        //    return newBomb2;
        //}



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
        // ~Bomb2() {
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
        #endregion









    }
}
