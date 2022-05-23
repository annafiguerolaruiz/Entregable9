using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class MenuManager : MonoBehaviour
{
    private int level;
    private int minLevel = 1;
    private int maxLevel = 10;
    public TextMeshProUGUI levelText;
    public TMP_InputField username;
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
    }
    public void LoadUserOptions()
    {
        level = PlayerPrefs.GetInt("LEVEL");
        UpdateLevel();

        if (PlayerPrefs.HasKey("USERNAME"))
        {
            username.text = PlayerPrefs.GetString("USERNAME");
        }
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
}
