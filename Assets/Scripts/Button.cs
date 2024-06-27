using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Spine.Unity;

public class Button : MonoBehaviour
{
    [SerializeField] private Items buttonItem;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private Image image;
    [SerializeField] private ParticleSystem puffParticle;
    [SerializeField] private Material greenMat, blueMat, purpleMat, orangeMat;

    [SerializeField] private GameObject spinePrefab; // Spine animation prefab

    void Start()
    {
        GetItem();
    }

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
        if (GameManager.instance.playerMove > 0)
        {
            int spawnCount = Random.Range(3, 9);
            Debug.Log(spawnCount);
                
            // Execute item logic once
            switch (buttonItem.type)
            {
                case Type.Multiply:
                    Multiply(buttonItem.value);
                    //ChangeParticleMaterial(orangeMat);
                    Debug.Log("Multiplied");
                    break;
                case Type.Additional:
                    AdditionalorMinus(buttonItem.value);
                    //ChangeParticleMaterial(blueMat);
                    Debug.Log("Added");
                    break;
                case Type.Divide:
                    Divide(buttonItem.value);
                    //ChangeParticleMaterial(purpleMat);
                    Debug.Log("Divided");
                    break;
                case Type.Minus:
                    Minus(buttonItem.value);
                    //ChangeParticleMaterial(greenMat);
                    Debug.Log("Subtracted");
                    break;
            }

            // Spawn animations in the loop
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 randomPosition = GetRandomPositionAround(transform.position);
                GameObject spineInstance = Instantiate(spinePrefab, randomPosition, Quaternion.identity);
                var skeletonMecanim = spineInstance.GetComponent<SkeletonMecanim>();
                ChangeSpineSkin(skeletonMecanim, GetSkinName(buttonItem.type));
                StartCoroutine(DestroyAfterAnimation(spineInstance, skeletonMecanim));
            }

            GetItem();
            GameManager.instance.playerMove--;
            GameManager.instance.UpdateContainerText();
            puffParticle.Play();
            GameManager.instance.Lose();
        }
        else
        {
            Debug.Log("Out of moves"); 
        }
    }

    private Vector3 GetRandomPositionAround(Vector3 center)
    {
        float spawnRadius = .3f;
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(center.x + randomCircle.x, center.y + randomCircle.y, center.z);
        return spawnPosition;
    }

    private void ChangeSpineSkin(SkeletonMecanim skeletonMecanim, string skinName)
    {
        skeletonMecanim.initialSkinName = skinName;
        skeletonMecanim.Initialize(true); // Apply the skin change
    }

    private string GetSkinName(Type itemType)
    {
        switch (itemType)
        {
            case Type.Multiply:
                return "yellow";
            case Type.Additional:
                return "blue";
            case Type.Divide:
                return "red";
            case Type.Minus:
                return "green";
            default:
                return "default";
        }
    }

    private IEnumerator DestroyAfterAnimation(GameObject instance, SkeletonMecanim skeletonMecanim)
    {
        yield return new WaitForSeconds(.35f);
        Destroy(instance);
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
        GameManager.instance.potionAmount -= value; // Assuming this is a subtraction based on the naming
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
