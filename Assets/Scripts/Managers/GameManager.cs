using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerData playerData;
    private string saveFilePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            saveFilePath = Application.persistentDataPath + "/playerData.json";

            playerData = LoadPlayerData();

            if (playerData == null || playerData.playerStrength == 0)
            {
                InitializeDefaultPlayerData();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeDefaultPlayerData()
    {
        playerData = new PlayerData
        {
            playerStrength = 1,
            playerAgility = 1,
            playerIntelligence = 1,
            playerWisdom = 1,
            playerVitality = 1,
            playerDurability = 1,
            playerLuck = 1,
            playerGreed = 1,
            playerSouls = 0,
            playerInventoryItems = new string[0]
        };
        SavePlayerData(playerData);
    }

    public void SoftReset(string attribute)
    {
        switch (attribute.ToLower())
        {
            case "strength":
                playerData.playerStrength++;
                break;
            case "agility":
                playerData.playerAgility++;
                break;
            case "intelligence":
                playerData.playerIntelligence++;
                break;
            case "wisdom":
                playerData.playerWisdom++;
                break;
            case "vitality":
                playerData.playerVitality++;
                break;
            case "durability":
                playerData.playerDurability++;
                break;
            case "luck":
                playerData.playerLuck++;
                break;
            case "greed":
                playerData.playerGreed++;
                break;
            default:
                Debug.LogWarning("Unknown attribute: " + attribute);
                return;
        }

        // Очищаем инвентарь
        playerData.playerInventoryItems = new string[0];

        SavePlayerData(playerData);
    }

    public void HardReset()
    {
        InitializeDefaultPlayerData();
    }

    public void SavePlayerData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }

    public PlayerData LoadPlayerData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        return null;
    }
}
