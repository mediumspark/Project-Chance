using System.Collections.Generic;

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
        CurrentWeapon.Fire();
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