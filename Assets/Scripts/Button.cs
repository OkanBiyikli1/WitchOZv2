using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Button : MonoBehaviour
{
    [SerializeField] private Items buttonItem;
    [SerializeField] private TextMeshProUGUI valueText;
    // Start is called before the first frame update
    void Start()
    {
        GetItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetItem()
    {
        buttonItem = GameManager.instance.items[Random.Range(0, GameManager.instance.items.Count)];
        valueText.text = buttonItem.value.ToString();
    }

    public void OnMouseDown()
    {
        if(GameManager.instance.playerMove > 0)
        {
            switch (buttonItem.type)
            {
                case Type.Multiply:
                    Multiply(buttonItem.value);
                    Debug.Log("carptın");
                    break;
                case Type.Minus:
                    Minus(buttonItem.value);
                    Debug.Log("cıkardın");
                    break;
                case Type.Additional:
                    Additional(buttonItem.value);
                    Debug.Log("topladın");
                    break;
                case Type.Divide:
                    Divide(buttonItem.value);
                    Debug.Log("cıkardın");
                    break;
                case Type.DivideMinus:
                    Divide(buttonItem.value);
                    Debug.Log("cıkardın");
                    break;
                case Type.MultiplyMinus:
                    Divide(buttonItem.value);
                    Debug.Log("cıkardın");
                    break;
            }

            buttonItem = null;

            GetItem();
            GameManager.instance.playerMove--;
            GameManager.instance.UpdateContainerText();
        }else
        {
            Debug.Log("out of moves");
        }
    }

    public void Multiply(int value)
    {
        GameManager.instance.potionAmount *= value;
    }

    public void Additional(int value)
    {
        GameManager.instance.potionAmount += value;
    }

    public void Divide(int value)
    {
        GameManager.instance.potionAmount /= value;
    }

    public void Minus(int value)
    {
        GameManager.instance.potionAmount += value;
    }

    public void DivideMinus(int value)
    {
        GameManager.instance.potionAmount /= value;
    }

    public void MultiplyMinus(int value)
    {
        GameManager.instance.potionAmount *= value;
    }

}
