using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Room", menuName = "cenas/rooms")]
public class rooms : ScriptableObject
{

    public _transition[] transition;
    [System.Serializable]
    public class _transition
    {
        public bool isLoked;
    }

    public _personagens[] personagens;
    [System.Serializable]
    public class _personagens
    {
        public bool ativo;
        public Vector3 initialPosition;
        public moveState move;
        public float speed;
        public Vector2[] pointPositions;
    }

    public _talk[] talk;
    [System.Serializable]
    public class _talk
    {
        public bool opicional;
        public bool ativo;
        public Dialogues dialogo;
    }


}
