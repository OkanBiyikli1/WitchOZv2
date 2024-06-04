using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Items> items = new List<Items>();
    public static GameManager instance;
    [SerializeField] private GameObject container;
    [SerializeField] private TextMeshProUGUI containerText;
    public int potionAmount;

    void Awake()
    {
        if(instance = this)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        containerText.text = potionAmount.ToString();
    }

}
