using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Transform[] cropLocations;
    [SerializeField] private GameObject[] cropPrefabs;
    private Vector3[] instantiatePos;
    private int cashForCrops;
    private int cash;
    private float hunger;
    public GameObject Button1, Button2;
    public void BackToMenu()
    {
        GameManager.Instance.IsGameOver = true;
        SceneManager.LoadScene(0);
    }
    public void PlantCrop()
    {
        cashForCrops = GameManager.Instance.Cash / 100;
        Debug.Log(cashForCrops);
        instantiatePos = new Vector3[cashForCrops];
        if(cashForCrops>16)
        {
            cashForCrops = 16;
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
        else if(cashForCrops < 1)
        {
            return;
        }
        else
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
            if (GameObject.FindObjectOfType<Food>() == null)
            {
                StartCoroutine(PlantDelay());
            }
            else
            {
                Debug.Log("Pick up the present crops first");
            }
        }
        GameManager.Instance.UpdateCash(-cashForCrops * 100);
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
    
}
