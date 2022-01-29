using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHearts : MonoBehaviour
{
    public PlayerStats playerStats;

    public GameObject UI_HEART;

    // Start is called before the first frame update
    void Start()
    {
        // current player health
        UpdateUI();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void RemoveHearts(int value)
    {
        for(int i = 0; i < value; i++)
        {
            var heartToRemove = this.transform.GetChild(this.transform.childCount - 1);
            heartToRemove.gameObject.GetComponent<Animator>().Play("heart_melting");
            await Task.Delay(500);
            if(playerStats.Health > 0)
            {
                UpdateUI();
            }
            else
            {
                SceneManager.LoadScene(2);
            }
            
        }
    }

    public void UpdateUI()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }

        int hp = playerStats.Health;

        if (hp <= 0)
        {
            SceneManager.LoadScene(2);
        }

        for (int i = 0; i < hp; i++)
        {
            Vector3 placeOnCanvas = this.transform.position;
            placeOnCanvas.x = this.transform.position.x + 36 * i;
            var newHeart = Instantiate(UI_HEART, placeOnCanvas, Quaternion.identity);
            newHeart.transform.parent = this.transform;
        }
    }

}
