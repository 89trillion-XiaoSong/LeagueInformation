using UnityEngine;
using UnityEngine.UI;

public class MainMenuRefresh : MonoBehaviour
{
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtGold;
    [SerializeField] private Text txtSeason;
    
    private void Start()
    {
        PlayerData.instance.scoreChangeEvent += ScoreRefresh;
        PlayerData.instance.goldChangeEvent += GoldRefresh;
        PlayerData.instance.seasonChangeEvent += SeasonRefresh;
    }

    /// <summary>
    /// 分数刷新
    /// </summary>
    /// <param name="score"></param>
    private void ScoreRefresh(int score)
    {
        txtScore.text = score.ToString();
    }

    /// <summary>
    /// 金币刷新
    /// </summary>
    /// <param name="gold"></param>
    private void GoldRefresh(int gold)
    {
        txtGold.text = gold.ToString();
    }

    /// <summary>
    /// 赛季刷新
    /// </summary>
    /// <param name="season"></param>
    private void SeasonRefresh(int season)
    {
        txtSeason.text = season.ToString();
    }
}
