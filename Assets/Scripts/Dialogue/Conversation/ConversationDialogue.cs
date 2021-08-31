using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConversationDialogue
{
    public string name;
    public Sprite portrait;
    [TextArea(3, 10)]
    public string[] sentences;
    public BaseTask[] task;
    public bool current;
}
