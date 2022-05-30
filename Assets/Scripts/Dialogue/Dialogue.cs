using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public SentenceBlock[] sentenceSets;
}

[System.Serializable]
public class Sentence
{
    public Sprite changePortrait;
    [TextArea(3, 10)]
    public string text;
}

[System.Serializable]
public class SentenceBlock
{
    public Sentence[] sentences;
    public Sentence[] newSentences;
    [HideInInspector]
    public bool seen;
}