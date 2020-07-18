using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    Transform currentTarget;
    public UnityEngine.UI.Slider myslider;
    public UnityEngine.UI.Text myText;
    Enemy currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.tag == "Enemy")
                {
                    currentEnemy = hit.transform.GetComponent<Enemy>();
                    currentEnemy.isSelected = Enums.selected.targeted;
                    currentTarget = hit.transform;
                    print(currentEnemy.level);
                    myText.text = "Lvl " + currentEnemy.level.ToString() + ' ' + currentEnemy.name;
                    myslider.maxValue = currentEnemy.maxhealth;
                    myslider.value = currentEnemy.health;
                    myslider.gameObject.SetActive(true);
                }
                else
                {
                    if (currentTarget != null)
                    {
                        currentTarget.GetComponent<Enemy>().isSelected = Enums.selected.notselected;
                        currentTarget = null;
                        currentEnemy = null;
                        myslider.gameObject.SetActive(false);
                    }
                }
            }
        }
        if(currentEnemy != null)
        {
            myslider.value = currentEnemy.health;
        }
    }
}
