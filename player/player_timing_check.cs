using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_timing_check : MonoBehaviour
{
    [SerializeField] player_data player_temp;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("monster"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            player_temp.check_timing_m = this.transform.localPosition.y - collision.transform.localPosition.y;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        player_temp.check_timing_m = 0;
    }
}
