using UnityEngine;
using UnityEngine.UI;

public class RewardItem: MonoBehaviour
{
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtGold;
    [SerializeField] private Button btnAward;
    [SerializeField] private Text txtAward;

    public ItemConfig itemConfig;
    
    //初始化
    public void Init(ItemConfig itemConfig)
    {
        this.itemConfig = itemConfig;
        txtScore.text = itemConfig.score.ToString();

        SetRewardButton(itemConfig.isAwarded);

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
                txtGold.text = itemConfig.gold + "金币";
                btnAward.gameObject.SetActive(true);
                break;
        }
    }

    //领取按钮点击
    public void GetRewardClick()
    {
        if (txtGold.IsActive())
        {
            PlayerData.instance.Gold += itemConfig.gold;
        }
        itemConfig.isAwarded = true;
        SetRewardButton(itemConfig.isAwarded);
    }

    //设置领取按钮状态
    public void SetRewardButton(bool isAwarded)
    {
        if (!isAwarded)
        {
            txtAward.text = "领取";
            if (itemConfig.score > PlayerData.instance.Score)
            {
                btnAward.interactable = false;
            }
            else
            {
                btnAward.interactable = true;
            }
        }
        else
        {
            btnAward.interactable = false;
            txtAward.text = "已领取";
        }
    }
}
