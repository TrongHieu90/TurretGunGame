using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    #region Singleton

    private static GameplayManager _instance;
    public static GameplayManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
    }

    #endregion

    [SerializeField] Text _infoText;
    [SerializeField] Text _highScoreText;
    private GameObject eventManager;
    AbstractGun _currentGun;
    public float _highScore;


    void Start()
    {
        _currentGun = FindObjectOfType<AbstractGun>();
        FindObjectOfType<DefaultTurretController>().gunSwap += FindGunInfo;
    }

    void Update()
    {
         _infoText.text = "Current Gun: " + _currentGun.gameObject.name + "\n\n"
                        + "Gun Damage: " + _currentGun.GunDmg.ToString() + "\n\n"
                        + "Bullet Count: " + _currentGun.BulletCount.ToString() + "\n\n"
                        + "Reload Timer: " + Mathf.Round(_currentGun.ReloadTimer).ToString();
       
        _highScoreText.text = "High Score: " + _highScore.ToString();
    }

    private void FindGunInfo()
    {
        _currentGun = FindObjectOfType<AbstractGun>();
    }
}
