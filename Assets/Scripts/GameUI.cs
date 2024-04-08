using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Transform[] cropLocations;
    [SerializeField] private GameObject[] cropPrefabs;
    private Vector3[] instantiatePos;
    private int cashForCrops;
    private int cash;
    private float hunger;
    public GameObject Button1, Button2;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Cash;
    public void BackToMenu()
    {
        GameManager.Instance.IsGameOver = true;
        SceneManager.LoadScene(0);
    }
    private void LateUpdate()
    {
        UpdateUI();
    }
    public void PlantCrop() //Abstraction Example
    {
        cashForCrops = GameManager.Instance.Cash / 100;
        Debug.Log(cashForCrops);
        instantiatePos = new Vector3[cashForCrops];
        CalculationForCropBudget();
        GameManager.Instance.UpdateCash(-cashForCrops * 100);
    }
    private void CalculationForCropBudget() //Abstraction Example
    {
        if (cashForCrops > 16)
        {
            cashForCrops = 16;
            CalculationForCropSpawning();
        }
        else if (cashForCrops < 1)
        {
            return;
        }
        else
        {
            CalculationForCropSpawning();
        }
    }
    void CalculationForCropSpawning() //Abstraction Example
    {
        for (int i = 0; i < cashForCrops; i++)
        {
            Vector3 tmp = cropLocations[i].position;
            int j = Random.Range(i, cashForCrops);
            cropLocations[i].position = cropLocations[j].position;
            cropLocations[j].position = tmp;
        }
        for (int i = 0; i < cashForCrops; i++)
        {
            instantiatePos[i] = cropLocations[i].position + new Vector3(0f, 2.3f, 0f);
        }
        if (FindObjectOfType<Food>() == null)
        {
            StartCoroutine(PlantDelay());
        }
        else
        {
            Debug.Log("Pick up the present crops first");
        }
    }
    IEnumerator PlantDelay()
    {
        for(int i = 0;i<cashForCrops;i++)
        {
            int randomIndex = Random.Range(0, cropPrefabs.Length);
            Quaternion instantiateRot = cropPrefabs[randomIndex].transform.rotation;
            Instantiate(cropPrefabs[randomIndex], instantiatePos[i], instantiateRot);
            yield return new WaitForSeconds(Random.Range(0.5f,1f));
        }
    }
    public void GetInfo(float foodAmount, int cashAmount)
    {
        hunger = foodAmount;
        cash = cashAmount;
        Button1.SetActive(true);
        Button2.SetActive(true);
    }
    public void Sell()
    {
        GameManager.Instance.UpdateCash(cash);
        Button1.SetActive(false);
        Button2.SetActive(false);
    }
    public void Eat()
    {
        GameManager.Instance.UpdateHunger(hunger);
        Button1.SetActive(false);
        Button2.SetActive(false);
    }

    public void UpdateUI()
    {
        Health.text = "Hunger: " + GameManager.Instance.Hunger;
        Cash.text = "Cash: " + GameManager.Instance.Cash;
    }
    
}
