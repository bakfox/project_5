using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_data
{
    public int user_gold_now = 0;
    public int now_stage = 0;
    public bool end_game = false;

    public int[] upgrade_value = new int[2]{0,0};//hp,atck

    public bool boss_die = false;//Á×À¸¸é º¯°æ
    public bool boos_miss = false;//³õÁü 
}
