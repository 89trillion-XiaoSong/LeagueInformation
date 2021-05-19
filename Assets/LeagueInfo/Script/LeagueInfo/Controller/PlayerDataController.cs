public class PlayerDataController
{
    public void seasonChange()
    {
        int playerScore = PlayerData.instance.Score;
        if (playerScore > 4000)
        {
            PlayerData.instance.Score -= (playerScore - 4000) / 2;
        }
    }
}
