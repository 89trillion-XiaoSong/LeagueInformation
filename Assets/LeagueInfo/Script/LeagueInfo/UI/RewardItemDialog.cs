using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardItemDialog: MonoBehaviour
{
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtGold;
    [SerializeField] private Button btnAward;
    [SerializeField] private Text txtAward;

    private ItemConfig _itemConfig = new ItemConfig();
    
    public void Init(ItemConfig itemConfig)
    {
        _itemConfig = itemConfig;
        txtScore.text = itemConfig.score.ToString();
        if (itemConfig.isAwarded)
        {
            SetRewardButton(itemConfig.isAwarded);
        }

        switch (itemConfig.score)
        {
            case 4000:
                txtGold.text = "1段";
                btnAward.gameObject.SetActive(false);
                break;
            case 5000:
                txtGold.text = "2段";
                btnAward.gameObject.SetActive(false);
                break;
            case 6000:
                txtGold.text = "3段";
                btnAward.gameObject.SetActive(false);
                break;
            default:
                txtGold.text = itemConfig.gold.ToString();
                btnAward.gameObject.SetActive(true);
                break;
        }
    }

    public void GetRewardClick()
    {
        if (txtGold.IsActive())
        {
            PlayerData.instance.Gold += _itemConfig.gold;
        }
        _itemConfig.isAwarded = true;
        SetRewardButton(_itemConfig.isAwarded);
    }

    private void SetRewardButton(bool isAwarded)
    {
        if (!isAwarded)
        {
            btnAward.interactable = true;
            txtAward.text = "领取";
        }
        else
        {
            btnAward.interactable = false;
            txtAward.text = "已领取";
        }
    }
}
