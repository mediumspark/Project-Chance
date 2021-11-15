﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq; 

public class ThePhilanthropistBoss : Boss
{
    [SerializeField]
    private float BaseCooldownTime;

    [SerializeField]
    private GameObject Phase_1, Phase_2, Phase_3;

    [SerializeField]
    private List<GameObject> PossiblePositions;

    [SerializeField]
    private GameObject RealOneObject; 

    protected override void Awake()
    {
        Phase_1.SetActive(false); Phase_2.SetActive(false); Phase_3.SetActive(false);
        MaxHealth = 50;
        CurrentHealth = MaxHealth;  
    }

    public override void OnTakeDamage(int damage)
    {
        base.OnTakeDamage(damage);
    }// for damage sound effect

    protected override void OnDeath()
    {
        base.OnDeath();
    }// for death sound effect

    private List<GameObject> GatherChildren(GameObject Phase)
    {
        List<GameObject> Temp = new List<GameObject>(); 
        for(int i = 0; i < Phase.transform.childCount; i++)
        {
            Temp.Add(Phase.transform.GetChild(i).gameObject);
        }
        return Temp; 
    }

    private void Shuffle(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {

            // Find a random index
            int destIndex = Random.Range(0, gameObjects.Length);
            GameObject source = gameObjects[i];
            GameObject dest = gameObjects[destIndex];

            // If is not identical
            if (source != dest)
            {
                Vector3 tmp = source.transform.position;
                source.transform.position = dest.transform.position;
                dest.transform.position = tmp;
            }
        }
    }
    

    void SpawnInPhils(GameObject Phase)
    { 
        GameObject real = new GameObject();
        real.AddComponent<PhilAttack>().isReal = true;
        real.GetComponent<PhilAttack>().RealOneObject = RealOneObject; 

        startAttack = false; 
        Phase.SetActive(true);
        PossiblePositions = GatherChildren(Phase);
        Shuffle(PossiblePositions.ToArray()); 
        real.transform.parent = PossiblePositions[0].transform;
        real.transform.localPosition = Vector3.zero; 

        for(int i = 1; i < PossiblePositions.Count; i++)
        {
            GameObject Fakes = Instantiate(real, PossiblePositions[i].transform);
            Fakes.transform.localPosition = Vector3.zero; 
            Fakes.GetComponent<PhilAttack>().isReal = false; 
        }

        PossiblePositions = null; //Empties array for next round of spawning

    }

    protected override IEnumerator Phase1Attack()
    {
        SpawnInPhils(Phase_1);
        foreach(PhilAttack attack in FindObjectsOfType<PhilAttack>())
        {
            attack.Attack = true;
            attack.PlayerLocation = FindObjectOfType<Player>().transform.position; 
            yield return new WaitForSecondsRealtime(.75f);
        }
        yield return new WaitForSeconds(BaseCooldownTime);
        Phase_1.gameObject.SetActive(false);
        yield return new WaitForSeconds(BaseCooldownTime);
        startAttack = true;
    }

    protected override IEnumerator Phase2Attack()
    {
        SpawnInPhils(Phase_2);
        foreach (PhilAttack attack in FindObjectsOfType<PhilAttack>())
        {
            attack.Attack = true;
            attack.PlayerLocation = FindObjectOfType<Player>().transform.position;
            yield return new WaitForSecondsRealtime(.75f);
        }
        yield return new WaitForSeconds(BaseCooldownTime);
        Phase_2.gameObject.SetActive(false);
        yield return new WaitForSeconds(BaseCooldownTime);
        Phase_2.gameObject.SetActive(false);
    }


    protected override IEnumerator Phase3Attack()
    {
        SpawnInPhils(Phase_3);
        foreach (PhilAttack attack in FindObjectsOfType<PhilAttack>())
        {
            attack.Attack = true;
            attack.PlayerLocation = FindObjectOfType<Player>().transform.position;
            yield return new WaitForSecondsRealtime(.75f);
        }
        yield return new WaitForSeconds(BaseCooldownTime);
        Phase_3.gameObject.SetActive(false);
        yield return new WaitForSeconds(BaseCooldownTime);
        Phase_3.gameObject.SetActive(false);
    }
}