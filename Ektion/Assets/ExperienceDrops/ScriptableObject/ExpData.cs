using UnityEditor.Animations;
using UnityEngine;
[CreateAssetMenu(fileName = "ExpData", menuName = "ScriptableObject/ExpData")]

public class ExpData : ScriptableObject
{
    public AnimatorController[] animatorControllers;
    public int[] values;
}
