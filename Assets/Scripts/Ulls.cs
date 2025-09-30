using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Knight_Adventyre.Ulls 
{
    public static class Ulls
    {
        public static Vector3 GetRoamingDir()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        } 
    }
}