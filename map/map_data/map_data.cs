using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_data :MonoBehaviour
{
    public bool go_destination = false;//멈추기 용도
    public float go_road_m = 0;//길따라 이동한 거리
    public int stop_max_m = 500;
    public int stop_max_ui_m = 940;

    public float player_spead = 0.5f;
    public int player_spead_up_comber = 10;
    public float player_spead_up_interval = 0.2f;
    public int map_recool_y = -19;
    public int map_start_y = 19;
}
