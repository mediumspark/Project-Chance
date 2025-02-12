﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using System.Linq;

public class ThePhilanthropistBoss : Boss
{
    [SerializeField]
    private GameObject Phase_1, Phase_2, Phase_3;

    [SerializeField]
    private List<GameObject> PossiblePositions;

    [SerializeField]
    private GameObject RealOneObject;

    private TextBoxManager IntroText;
    [SerializeField]
    private PlayableDirector Intro, Victory;

    public Slider enemyHealthBar;

    protected override void Awake()
    {
        IntroText = GetComponentInChildren<TextBoxManager>();
        Phase_1.SetActive(false); Phase_2.SetActive(false); Phase_3.SetActive(false);
        MaxHealth = 50;
        CurrentHealth = MaxHealth;
        PrizeWeapon = new ThePhilanthropist(FindObjectOfType<Player>());

        enemyHealthBar = GameObject.Find("EnemyHealthBar").GetComponent<Slider>();
        enemyHealthBar.maxValue = MaxHealth;
    }

    public override void OnTakeDamage(int damage)
    {
        base.OnTakeDamage(damage);
    }// for damage sound effect

    protected override void OnDeath()
    {
        base.OnDeath();
        Victory.gameObject.SetActive(true);
        
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

    private void Update()
    {
        if (IntroText.Finished)
        {
            Intro.gameObject.SetActive(true);
        }
        enemyHealthBar.value = CurrentHealth;
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
            Fakes.GetComponent<PhilAttack>().Summon();
        }

        PossiblePositions = null; //Empties array for next round of spawning

    }

    protected override IEnumerator Phase1Attack()
    {
        SpawnInPhils(Phase_1);
        GetComponentInChildren<Animator>().Play("PAttack");
        foreach(PhilAttack attack in FindObjectsOfType<PhilAttack>())
        {
            attack.Attack = true;
           // attack.GetComponentInChildren<Animator>().Play("PAttack");
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
        startAttack = true;

    }

    //Maybe round three has him spawn robots from the sky for a couple seconds and player just needs to survive
    //"Your mission is almost done, you just need to be patient enough to see the results"
    protected override IEnumerator Phase3Attack()
    {
        SpawnInPhils(Phase_3);
        foreach (PhilAttack attack in FindObjectsOfType<PhilAttack>())
        {
            attack.Attack = true;
            attack.PlayerLocation = FindObjectOfType<Player>().transform.position;
        }
        yield return new WaitForSeconds(BaseCooldownTime);
        Phase_3.gameObject.SetActive(false);
        yield return new WaitForSeconds(BaseCooldownTime);
        startAttack = true;

    }

    //Sounds

    private void PhilAttack()
    {
        AkSoundEngine.PostEvent("Play_Philanthropist_Attack", this.gameObject);
    }

    private void PhilClone()
    {
        AkSoundEngine.PostEvent("Play_Philanthropist_Clone", this.gameObject);
    }

    private void PhilDamaged()
    {
        AkSoundEngine.PostEvent("Play_Philanthropist_Damaged", this.gameObject);
    }

    private void PhilFootsteps()
    {
        AkSoundEngine.PostEvent("Play_Philanthropist_Footsteps", this.gameObject);
    }
}
