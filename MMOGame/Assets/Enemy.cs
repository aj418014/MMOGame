using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject selected;
    public Enums.selected isSelected;
    public int health;
    public int maxhealth;
    public int level;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        switch (isSelected)
        {
            case Enums.selected.notselected:
                selected.SetActive(false);
                break;
            case Enums.selected.targeted:
                selected.SetActive(true);
                break;
            default:
                break;
        }
    }
}
