using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int level;
    public int minLevel = 1;
    public int maxLevel = 10;
    public TextMeshProUGUI levelText;
    public TMP_InputField username;

    public TextMeshProUGUI powerUpText;
    public float randomNum;


    // Start is called before the first frame update
    void Start()
    {
        level = int.Parse(levelText.text);
        LoadUserOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveUserOptions()
    {
        PersistenciaDeDatos.sharedInstance.level = level;
        PersistenciaDeDatos.sharedInstance.username = username.text;
        // Persistencia de datos entre partidas
        PersistenciaDeDatos.sharedInstance.SaveForFutureGames();

        PersistenciaDeDatos.sharedInstance.powerUp = randomNum;
    }
    public void LoadUserOptions()
    {
        level = PlayerPrefs.GetInt("LEVEL");
        UpdateLevel();

        if (PlayerPrefs.HasKey("USERNAME"))
        {
            username.text = PlayerPrefs.GetString("USERNAME");
        }

        powerUpText.text = PlayerPrefs.GetFloat("PowerUp").ToString();
    }
    #region Level Settings

    public void PlusLevel()
    {
        level++;
        level = Mathf.Clamp(level, minLevel, maxLevel);
        UpdateLevel();
    }

    public void MinusLevel()
    {
        level--;
        level = Mathf.Clamp(level, minLevel, maxLevel);
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        levelText.text = level.ToString();
    }
    #endregion

    public void RandomPowerUp()
    {
        randomNum = Random.Range(1.0f, 10.0f);
        powerUpText.text = randomNum.ToString();

    }
}
