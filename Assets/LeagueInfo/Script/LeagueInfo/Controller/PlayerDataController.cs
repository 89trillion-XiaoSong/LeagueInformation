using UnityEngine;

public class PlayerDataController
{
    public static PlayerDataController instance;
    public PlayerDataController()
    {
        
    }
    
    public void seasonChange()
    {
        int playerScore = PlayerData.instance.Score;
        if (playerScore > 4000)
        {
            PlayerData.instance.Score -= (playerScore - 4000) / 2;
            
            //刷新奖励
            
            //
        }
        
    }
}
