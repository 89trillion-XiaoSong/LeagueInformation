using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuRefresh : MonoBehaviour
{
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtGold;
    [SerializeField] private Text txtSeason;

    private void Start()
    {
        PlayerData.instance.scoreChangeEvent += SetScore;
        PlayerData.instance.goldChangeEvent += SetGold;
        PlayerData.instance.seasonChangeEvent += SetSeason;
    }

    private void SetScore(int score)
    {
        txtScore.text = score.ToString();
    }

    private void SetGold(int gold)
    {
        txtGold.text = gold.ToString();
    }

    private void SetSeason(int season)
    {
        txtSeason.text = season.ToString();
    }
}
