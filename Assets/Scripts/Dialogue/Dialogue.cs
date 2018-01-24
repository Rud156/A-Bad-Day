using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Basic")]
public class Dialogue : ScriptableObject
{
    public new string name;

    [TextArea]
    public string[] sentences;
}
