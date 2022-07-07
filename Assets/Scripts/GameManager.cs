using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //PlayerPrefs.DeleteAll();
        
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    public Player player;

    public int pesos;
    public int xp;

    public void SaveState()
    {
        string s = "";
        
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += xp.ToString() + "|";
        s += "0";
        
        PlayerPrefs.SetString("SaveState", s);

        Debug.Log("SaveState");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        //change skin
        pesos = int.Parse(data[1]);
        xp = int.Parse(data[2]);
        //change weapon level

        Debug.Log("LoadState");
    }

  
}
