using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerMove = 0;
    [Header("Items")]
    public List<Items> items = new List<Items>();
    public static GameManager instance;
    [SerializeField] private GameObject container;
    [SerializeField] private TextMeshProUGUI containerText;
    public int potionAmount = 0;

    [Header("Customers")]
    [SerializeField] List<Customers> customers;
    [SerializeField] private GameObject customer;
    [SerializeField] private TextMeshProUGUI customerText, customerMoveText;
    [SerializeField] private int customerIndex = 0;

    void Awake()
    {
        if(instance = this)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        GetNextCustomer(customerIndex);
        containerText.text = potionAmount.ToString();
    }

    public void UpdateContainerText()
    {
        containerText.text = potionAmount.ToString();
        customerMoveText.text = playerMove.ToString();
    }

    public void Generate()
    {
        if(potionAmount == customers[0].neededAmount)
        {
            potionAmount = 0;
            customerIndex++;
            GetNextCustomer(customerIndex);
            UpdateContainerText();
            Debug.Log("iyilestirdin");
        }
        else if(potionAmount < customers[customerIndex].neededAmount)
        {
            Debug.Log("değeri arttirmalisin");
        }
        else if(potionAmount > customers[customerIndex].neededAmount)
        {
            Debug.Log("değeri azaltmalisin");
        }
    }

    public void GetNextCustomer(int index)
    {
        customerText.text = customers[customerIndex].neededAmount.ToString();
        customerMoveText.text = customers[customerIndex].moveValue.ToString();
        playerMove = customers[customerIndex].moveValue;
    }

}
