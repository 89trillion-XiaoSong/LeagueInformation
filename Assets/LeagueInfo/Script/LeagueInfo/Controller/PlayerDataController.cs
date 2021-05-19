public class PlayerDataController
{
    /// <summary>
    /// 赛季更新
    /// </summary>
    public void seasonChange()
    {
        int playerScore = PlayerData.instance.Score;
        if (playerScore > 4000)
        {
            PlayerData.instance.Score -= (playerScore - 4000) / 2;
        }
    }
}
