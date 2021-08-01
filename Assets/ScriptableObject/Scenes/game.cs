using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "game", menuName = "cenas/game")]
public class game : ScriptableObject
{
    public Atos[] atos;
    [System.Serializable]
    public class Atos
    {
        public string name;
        public atos ato;
    }
}