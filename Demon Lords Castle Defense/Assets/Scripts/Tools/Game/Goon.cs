using UnityEngine;

public class Goon : MonoBehaviour
{


    // Written rules (Esther)
    // speed = 0, Goon is stationary in assigned Slot

    // [ATTACK- MELEE]
    // attack range = 1/6 of the Tile size, recangular shape
    //      (6 Goons should cover 1 Tile)
    // 1 Goon attack 2 Hero at a time
    // When a hero enters attack range:
    //      if is damaging 2 Heroes, no change
    //      if is damaging 1 Hero, fight the new Hero as well
    //      if is damaging 0 Hero, fight
    // When defeating 1 or 2 hero it's fighting:
    //      if any Hero within attack range, fight the one(s) closest to leaving said range

    // [ATTACK- RANGE]
    // attack range = 1 Tile
    // 1 Goon attack 1 Hero at a time
    // When a hero enters attack range:
    //      if is damaging 1 Hero, no change
    //      if it damaging 0 Hero, fight
    // When defeating 1 Hero
    //      if any Hero within attack range, pick the one closest to leaving said range

    // [General]
    // if removed from slot:
    //      stop attacking
    //      HP remains the same as before removal

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
