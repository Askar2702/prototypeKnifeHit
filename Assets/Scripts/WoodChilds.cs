using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChilds : MonoBehaviour
{
    [SerializeField] private GameObject[] AppleChilds;
    [SerializeField] private GameObject[] KnifeChilds;
    [SerializeField] private AppleSetting appleSetting;
    private KnifeCount knifeCount;
    void Start()
    {
        knifeCount = GameObject.Find("KnifeCount").GetComponent<KnifeCount>();
        Chance();
        KnifeSpawn();
    }

    
    private void Chance()
    {
        var _chance = Random.Range(0, 100);
        if (_chance <= appleSetting.SettingChance)
        {
            var index = Random.Range(0, AppleChilds.Length);
            for (int i = 0; i < index; i++)
            {
                AppleChilds[i].SetActive(true);
            }
        }
    }

    private void KnifeSpawn()
    {
        if(GameManager.gameManager.stage >= 3)
        {
            var countSpawn = Random.Range(0, KnifeChilds.Length);
            for ( int i = 0; i < countSpawn; i++)
            {
                KnifeChilds[Random.Range(0, KnifeChilds.Length)].SetActive(true);
            }
            knifeCount.SetKnaifeCount(countSpawn);
        }

    }
}
