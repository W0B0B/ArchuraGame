using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName ="New Dialog",menuName ="Dialogue System/Dialogue")]
public class DialogueScripts : ScriptableObject
{
    public List<DialogueClass> Dialogues=new List<DialogueClass>();
}

