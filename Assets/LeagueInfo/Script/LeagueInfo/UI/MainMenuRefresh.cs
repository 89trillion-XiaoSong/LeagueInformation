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

    //分数刷新
    private void ScoreRefresh(int score)
    {
        txtScore.text = score.ToString();
    }

    //金币刷新
    private void GoldRefresh(int gold)
    {
        txtGold.text = gold.ToString();
    }

    //赛季刷新
    private void SeasonRefresh(int season)
    {
        txtSeason.text = season.ToString();
    }
}
