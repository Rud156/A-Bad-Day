using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Basic")]
public class Dialogue : ScriptableObject
{
    public new string name;

    public Texture spriteImage;

    public Color nameColor;

    [TextArea]
    public string[] sentences;
}
