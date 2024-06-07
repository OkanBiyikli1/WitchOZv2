using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private Items buttonItem;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private Image image;
    [SerializeField] private ParticleSystem puffParticle;
    [SerializeField] private Material greenMat, blueMat, purpleMat, orangeMat;
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
        image.sprite = buttonItem.sprite;
    }

    public void OnMouseDown()
    {
        if(GameManager.instance.playerMove > 0)
        {
            switch (buttonItem.type)
            {
                case Type.Multiply:
                    Multiply(buttonItem.value);
                    ChangeParticleMaterial(orangeMat);
                    Debug.Log("carptın");
                    break;
                case Type.Additional:
                    AdditionalorMinus(buttonItem.value);
                    ChangeParticleMaterial(blueMat);
                    Debug.Log("topladın");
                    break;
                case Type.Divide:
                    Divide(buttonItem.value);
                    ChangeParticleMaterial(purpleMat);
                    Debug.Log("böldün");
                    break;
                case Type.Minus:
                    Minus(buttonItem.value);
                    ChangeParticleMaterial(greenMat);
                    Debug.Log("böldün");
                    break;
            }

            buttonItem = null;

            GetItem();
            GameManager.instance.playerMove--;
            GameManager.instance.UpdateContainerText();
            puffParticle.Play();
        }
        else
        {
            Debug.Log("out of moves");
        }
    }

    public void Multiply(int value)
    {
        GameManager.instance.potionAmount *= value;
    }

    public void AdditionalorMinus(int value)
    {
        GameManager.instance.potionAmount += value;
    }

    public void Minus(int value)
    {
        GameManager.instance.potionAmount += value;
    }

    public void Divide(int value)
    {
        GameManager.instance.potionAmount /= value;
    }

    private void ChangeParticleMaterial(Material mat)
    {
        var renderer = puffParticle.GetComponent<ParticleSystemRenderer>();
        renderer.material = mat;
    }
}
