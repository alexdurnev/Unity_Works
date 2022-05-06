using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PointsController : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI levelValue, currentXpValue, xpToLevelUpValue; 
    public LevelSystem levelSystem; 


    // Start is called before the first frame update
    void Start()
    {
        levelSystem = ScriptableObject.CreateInstance<LevelSystem>();
        levelSystem.SetLevelData(); 
        currentXpValue.text = levelSystem.CurrentXP.ToString();
        xpToLevelUpValue.text = levelSystem.CurrentLevel.TargetXP.ToString();
        levelValue.text = levelSystem.CurrentLevel.Id.ToString();
    }

    public void AddButtonClicked()
    {
        levelSystem.AddXP();   
        currentXpValue.text = levelSystem.CurrentXP.ToString();
        
        if (levelSystem.CheckIfLevelUpRequired())
        {
            levelSystem.ToNextLevel(); 
            xpToLevelUpValue.text = levelSystem.CurrentLevel.TargetXP.ToString();
            levelValue.text = levelSystem.CurrentLevel.Id.ToString();
        }

    }
}

