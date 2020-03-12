using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.misskiss
{
    


    public class AudioManager : MonoBehaviour
    {
        
        public Clip[] clips;


        [Serializable]
        public class Clip
        {
            public string name;
            public AudioClip audio;


  
        }
    }
}