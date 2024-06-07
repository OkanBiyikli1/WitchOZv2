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
    [SerializeField] private int levelIndex = 0;
    [SerializeField] private TextMeshProUGUI dialogText;

    [Header("UI")]

    [SerializeField] private GameObject line2;
    [SerializeField] private GameObject line3;
    [SerializeField] private TextMeshProUGUI currentLevelText;

    void Awake()
    {
        if(instance = this)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        CheckLineToActivate();
        GetNextCustomer(levelIndex);
        containerText.text = potionAmount.ToString();
        dialogText.text = customers[levelIndex].dialog;
        currentLevelText.text = "Level: " + levelIndex.ToString();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            levelIndex++;
            GetNextCustomer(levelIndex);
            currentLevelText.text = "Level: " + levelIndex.ToString();
            CheckLineToActivate();
        }
    }

    public void UpdateContainerText()
    {
        containerText.text = potionAmount.ToString();
        customerMoveText.text = playerMove.ToString();
    }

    public void Generate()
    {
        if(potionAmount == customers[levelIndex].neededAmount)
        {
            potionAmount = 0;
            levelIndex++;
            GetNextCustomer(levelIndex);
            UpdateContainerText();
            Debug.Log("iyilestirdin");
            CheckLineToActivate();
            currentLevelText.text = "Level: " + levelIndex.ToString();
        }
        else if(potionAmount < customers[levelIndex].neededAmount)
        {
            Debug.Log("değeri arttirmalisin");
        }
        else if(potionAmount > customers[levelIndex].neededAmount)
        {
            Debug.Log("değeri azaltmalisin");
        }
    }

    public void GetNextCustomer(int index)
    {
        customerText.text = customers[levelIndex].neededAmount.ToString();
        customerMoveText.text = customers[levelIndex].moveValue.ToString();
        playerMove = customers[levelIndex].moveValue;
        dialogText.text = customers[levelIndex].dialog;
    }

    void CheckLineToActivate()
    {
        if(levelIndex == 25)
        line2.SetActive(true);

        if(levelIndex == 50)
        line3.SetActive(true);
    }

}
