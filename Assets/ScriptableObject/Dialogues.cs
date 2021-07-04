using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialogues : ScriptableObject
{
    [System.Serializable]
    public class Sentence
    {
        [TextArea(3, 5)]//aumenta o tamanho da caixa de texto no inspector da unity
        public string frase;//frases que serao mostradas
        public int nextSentence;
        public Sprite sprite;
        public bool hasAnswer;


        [System.Serializable]
        public class answer
        {
            [TextArea(3, 5)]//aumenta o tamanho da caixa de texto no inspector da unity
            public string frase;//frases que serao mostradas
            public int nextSentence;
        }
        public answer[] answers = new answer[4];
        


    }
    public Sentence[] sentence;
}
