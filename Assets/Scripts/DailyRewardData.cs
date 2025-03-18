using UnityEngine;

[CreateAssetMenu(fileName = "DailyRewardData", menuName = "DailyRewards/DailyRewardData", order = 1)]
public class DailyRewardData : ScriptableObject
{
    [System.Serializable]
    public class RewardInfo
    {
        public int day;           // Day number (e.g., 1, 2, 3...)
        public string rewardType; // Type of reward (e.g., "Coins", "XP", "Weapon")
        public int rewardAmount;  // Amount of the reward
    }

    public RewardInfo[] rewards; // Array of rewards for each day
}