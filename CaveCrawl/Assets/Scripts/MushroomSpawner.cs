using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour {

      //Object variables
      public GameObject mushroomPrefab;
      public Transform spawnPoint1;
      public Transform spawnPoint2;
      public Transform spawnPoint3;
      public Transform spawnPoint4;
      public Transform spawnPoint5;
      public Transform spawnPoint6;
      public Transform spawnPoint7;
      public Transform spawnPoint8;
      public Transform spawnPoint9;

      //Timing variables
      private float spawnTimer1 = 0f;
      private float spawnTimer2 = 0f;
      private float spawnTimer3 = 0f;
      private float spawnTimer4 = 0f;
      private float spawnTimer5 = 0f;
      private float spawnTimer6 = 0f;
      private float spawnTimer7 = 0f;
      private float spawnTimer8 = 0f;
      public float spawnTimer9 = 0f;

      void Start(){
        Instantiate(mushroomPrefab, spawnPoint1.position, Quaternion.identity);
        Instantiate(mushroomPrefab, spawnPoint2.position, Quaternion.identity);
        Instantiate(mushroomPrefab, spawnPoint3.position, Quaternion.identity);
        Instantiate(mushroomPrefab, spawnPoint4.position, Quaternion.identity);
        Instantiate(mushroomPrefab, spawnPoint5.position, Quaternion.identity);
        Instantiate(mushroomPrefab, spawnPoint6.position, Quaternion.identity);
        Instantiate(mushroomPrefab, spawnPoint7.position, Quaternion.identity);
        Instantiate(mushroomPrefab, spawnPoint8.position, Quaternion.identity);
        Instantiate(mushroomPrefab, spawnPoint9.position, Quaternion.identity);
      }

      void FixedUpdate(){
        spawnTimer1 = spawnPointCheck(spawnPoint1, spawnTimer1);
        spawnTimer2 = spawnPointCheck(spawnPoint2, spawnTimer2);
        spawnTimer3 = spawnPointCheck(spawnPoint3, spawnTimer3);
        spawnTimer4 = spawnPointCheck(spawnPoint4, spawnTimer4);
        spawnTimer5 = spawnPointCheck(spawnPoint5, spawnTimer5);
        spawnTimer6 = spawnPointCheck(spawnPoint6, spawnTimer6);
        spawnTimer7 = spawnPointCheck(spawnPoint7, spawnTimer7);
        spawnTimer8 = spawnPointCheck(spawnPoint8, spawnTimer8);
        spawnTimer9 = spawnPointCheck(spawnPoint9, spawnTimer9);
      }

      float spawnPointCheck(Transform spPoint, float time) {
        if (spPoint.transform.gameObject.tag == "nomushroom") {
            time += .001f;
            if(time > 1f) {
                Instantiate(mushroomPrefab, spPoint.position, Quaternion.identity);
                time = 0f;
                spPoint.gameObject.tag = "mushroom";
            }
        }
        return time;
    }
}