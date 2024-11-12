using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField]private Button levelChange;
    private GameManager gameManager;
    public int difficultyLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       
        levelChange.onClick.AddListener(SetDifficulty);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log("Game has started");
        gameManager.GameStart(difficultyLevel); 
    }
}
