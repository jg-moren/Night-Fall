using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class scenes : ScriptableObject
{
    public Atos[] atos;
    [System.Serializable]
    public class Atos
    {
        public Cenas[] cenas;
        [System.Serializable]
        public class Cenas
        {
            public string name;
            public Object scene;

            public _transition[] transition;
            [System.Serializable]
            public class _transition
            {
                public bool isLoked;
            }

            public _talk[] talk;
            [System.Serializable]
            public class _talk
            {
                public Dialogues dialogo;
            }

        }
    }
}

