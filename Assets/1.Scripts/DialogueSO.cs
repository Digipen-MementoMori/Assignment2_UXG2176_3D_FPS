using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="dialogueSO")]
public class DialogueSO : ScriptableObject
{
    public List<string> dialogues = new List<string>();
    public List<string> specialDialog = new List<string>();
}
