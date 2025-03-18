using UnityEngine;
using UnityEngine.UI;

public class DailyRewardsManager : MonoBehaviour
{
    [SerializeField] private DailyRewardData rewardData;    // Reference to the ScriptableObject
    [SerializeField] private GameObject rewardEntryPrefab;  // Reward entry prefab
    [SerializeField] private Transform contentParent;       // ScrollView's Content transform

    void Start()
    {
        PopulateRewards();
    }

    public void PopulateRewards()
    {
        // Null checks with debug logs
        if (rewardData == null)
        {
            Debug.LogError("rewardData is null! Please assign a DailyRewardData asset in the Inspector.");
            return;
        }
        if (rewardData.rewards == null || rewardData.rewards.Length == 0)
        {
            Debug.LogError("rewardData.rewards is null or empty! Please populate the rewards array in the DailyRewardData asset.");
            return;
        }
        if (rewardEntryPrefab == null)
        {
            Debug.LogError("rewardEntryPrefab is null! Please assign the RewardEntryPrefab in the Inspector.");
            return;
        }
        if (contentParent == null)
        {
            Debug.LogError("contentParent is null! Please assign the ScrollView's Content transform in the Inspector.");
            return;
        }

        // Clear existing entries
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Instantiate reward entries
        foreach (var reward in rewardData.rewards)
        {
            GameObject entry = Instantiate(rewardEntryPrefab, contentParent);
            RewardEntry rewardEntry = entry.GetComponent<RewardEntry>();
            if (rewardEntry == null)
            {
                Debug.LogError("RewardEntry component missing on the instantiated prefab!");
                continue;
            }

            rewardEntry.Setup(reward);

            // Add click listener
            Button button = entry.GetComponent<Button>();
            if (button == null)
            {
                Debug.LogError("Button component missing on the instantiated prefab!");
                continue;
            }
            button.onClick.AddListener(rewardEntry.OnRewardClicked);
        }

        // Adjust content size dynamically
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentParent.GetComponent<RectTransform>());
    }
}