using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI balanceScreenp;

    void Update()
    {
        UpdateDisplay();
    }
    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        UpdateDisplay();
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        UpdateDisplay();
        currentBalance -= Mathf.Abs(amount);
        if(currentBalance < 0)
        {
            //Lose the game;
            ReloadScene();
            
        }
    }

    void UpdateDisplay()
    {
        balanceScreenp.text = "Gold: " + currentBalance;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
