using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RewardEntry : MonoBehaviour
{
    [SerializeField] private TMP_Text rewardText; // Reference to the Text component
    private DailyRewardData.RewardInfo rewardInfo;

    // Called when setting up the entry
    public void Setup(DailyRewardData.RewardInfo info)
    {
        rewardInfo = info;
        rewardText.text = $"Day {info.day}: {info.rewardAmount} {info.rewardType}";
    }

    // Called when the button is clicked
    public void OnRewardClicked()
    {
        Debug.Log($"Reward Claimed - Day: {rewardInfo.day}, Type: {rewardInfo.rewardType}, Amount: {rewardInfo.rewardAmount}");
    }
}