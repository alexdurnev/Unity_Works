using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelBalance", menuName = "LevelSystem")]
public class LevelSystem : ScriptableObject 
{
    public Level CurrentLevel { get; set; }
    public int CurrentXP { get; set; }  
     
    public List<Level> levels;

    public void ToNextLevel()
    {
        int lastLevelIdx = levels.Count - 1;  
        int nextLevelIdx = CurrentLevel.Id; 
        if(CurrentLevel.Id<=lastLevelIdx) 
            CurrentLevel = levels[nextLevelIdx]; 
    }


    public bool CheckIfLevelUpRequired()
    {
        if (CurrentXP >= CurrentLevel.TargetXP)
            return true;
        else return false;
    }

    
    public void SetLevelData() 
    {
        levels = new List<Level>();
        
        levels.Add(new Level(1, 20));
        levels.Add(new Level(2, 60));
        levels.Add(new Level(3, 120));
        levels.Add(new Level(4, 200));
        levels.Add(new Level(5, 300));

        CurrentLevel = levels[0]; 

    }

    public void AddXP()
    {
        CurrentXP += 10;
    }
}
