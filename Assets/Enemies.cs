
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Enemy;

public class Enemies : MonoBehaviour, Interactuable
{
    public Enemy enemyData;
    Text message;
    public int startLife;

    void Start()
    {
        enemyData.life = startLife;
        message = GameObject.Find("Text").GetComponent<Text>();
    }

    public void Action()
    {
        message.text = enemyData.greeting;
    }
    public void Inaction()

    {
        message.text = "";
    }

    public void TakeDamage(int damage)
    {
        enemyData.life -= damage;
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled =false;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (enemyData.life <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
