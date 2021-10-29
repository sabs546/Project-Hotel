using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public Sentence[] sentences;
    public Sentence[] newSentences;
    public Sentence[] questSentences;
    public Sentence[] newQuestSentences;
}

[System.Serializable]
public class Sentence
{
    public Sprite changePortrait;
    [TextArea(3, 10)]
    public string text;
}