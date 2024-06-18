using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] int points = 5;
    public int GetPoints {  get { return points; } }
    

}
