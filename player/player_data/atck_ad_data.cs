using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atck_ad_data : MonoBehaviour
{
    public bool water_arrow = false;//����ȭ������ üũ 

    public Vector3 conect_position;
    public int atck_ad_value =0 ;//���ݿ� ���� ���� 0ȭ�� 1���� ..
    public player_atck_spawn_manger player_atck_spawn_tmep;//����
    public int atck_dmg;//������
    public float atck_value;//����

    public float target_max_y = 56;//��ǥ ��ġ 
    public float ad_spead = 2f;//���ư��� �ӵ�
}
