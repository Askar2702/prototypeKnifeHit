using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class KnifeCount : MonoBehaviour
{
    public Text tx;
    private Target target;
    [SerializeField] private int SetCountKnaife;
    [SerializeField] private GameObject meter;
    [SerializeField] private Color color;
    public List<GameObject> childMeter = new List<GameObject>();
    void Start()
    {
        target = FindObjectOfType<Target>();
        target.notyfi += MeterKnife;
        GameManager.gameManager.nextLevel += NextLvl;
        SpawnMeter();

    }

    private void MeterKnife()
    {
        var knife = childMeter.LastOrDefault(item => item.GetComponent<SpriteRenderer>().color != color);
        tx.text = target.ToString();
        knife.GetComponent<SpriteRenderer>().color = color;
        childMeter.Remove(knife);
        SetCountKnaife--;
        if (SetCountKnaife <= 0)
        {
            SetCountKnaife = 10;
            GameManager.gameManager.EndLvl();
            target.instanceLogs();
        }
    }
    


    private void NextLvl()
    {
        target = FindObjectOfType<Target>();
        target.notyfi += MeterKnife;
        for (int i = 0; i < childMeter.Count; i++)
            Destroy(childMeter[i]);
        SpawnMeter();
    }
    public void SetKnaifeCount(int count)
    {
        SetCountKnaife = 10 - count;
    }

    private void SpawnMeter()
    {
        for (int i = 0; i < SetCountKnaife; i++)
        {
            var sprite = meter.GetComponent<SpriteRenderer>();
            var spriteSize = sprite.bounds.size - new Vector3(0f, 0.7f); // это нужно для границы сетки
            var position = new Vector2(transform.position.x, transform.position.y + i * spriteSize.y);
            GameObject _metter = Instantiate(meter, position, Quaternion.Euler(0f, 0f, 50f));
            _metter.transform.parent = transform;
            childMeter.Add(_metter);
        }
    }
    private void OnDisable()
    {
        target.notyfi -= MeterKnife;
        GameManager.gameManager.nextLevel -= NextLvl;
    }
}
