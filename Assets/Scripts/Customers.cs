using UnityEngine;
[CreateAssetMenu(fileName = "Customer", menuName = "Customers")]
public class Customers : ScriptableObject
{
    public int neededAmount;
    public int moveValue;
    public Sprite sprite;
    public string dialog;
}
