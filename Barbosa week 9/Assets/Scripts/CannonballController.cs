using Unity.VisualScripting;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    // Start is called before the first frame update
    private ScoreboardController scoreboard;
    void Start()
    {
        scoreboard = GameObject.Find("Scoreboard").GetComponent<ScoreboardController>();
        Destroy(gameObject, 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cannon ball"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("target zone"))
        {
            scoreboard.Score += 1;

            Destroy(gameObject);
        }
    }

}
