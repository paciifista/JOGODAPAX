using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NavGame.Models
{

    public class LevelData
    {
        public int CointCount { get; private set; }
        public void AddCoins(int amount)
        {
            CointCount += amount;
        }


        public void ConsumeCoins(int amount)
        {
            ValidadeCoinAmount(amount);
            CointCount -= amount;
        }

        public void ValidadeCoinAmount(int amount)
        {
            if (CointCount < amount)
            {
                throw new InvalidOperationException("Need " + amount + " coins");
            }
        }


    }


}
