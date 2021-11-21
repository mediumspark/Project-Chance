using System.Collections.Generic;
using UnityEngine;

public enum WeaponSelected { Default, Phil, Mayor}

[System.Serializable]
public class WeaponHandler
{
    public Weapon CurrentWeapon;
    public List<Weapon> Weapons;

    public WeaponHandler()
    {
        Weapons = new List<Weapon>();
    }

    public void Fire()
    {
        CurrentWeapon.Fire(10);
    }

    public WeaponSelected GetWeapon()
    {
        switch (CurrentWeapon)
        {
            case Default D:
                return WeaponSelected.Default;

            case ThePhilanthropist P:
                return WeaponSelected.Phil;

            case TheMayor M:
                return WeaponSelected.Mayor;

            default:
                throw new System.Exception("Weapon Not Implemented");
        }
    }

    public void Add(Weapon weapon)
    {
        Weapons.Add(weapon);
    }

    public void SetCurrentWeapon(int index)
    {
        CurrentWeapon = Weapons[index];
    }

    public void WeaponSwap(float direction)
    {
        int index = Weapons.IndexOf(CurrentWeapon);
        if(direction > 0)
        {
            index++;
            index = index >= Weapons.Count ? 0 : index;
        }
        else
        {
            index--;
            index = index <= 0 ? Weapons.Count - 1 : index;
        }
        
        CurrentWeapon = Weapons[index];
    }
}