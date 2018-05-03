using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    //Класс для синхронизации кода и UI (данные в коде, вывод на экране и наоборот)
    public class GameService : MonoBehaviour
    {

        public static HeroesSet GetHeroEnum(int index)
        {
            switch (index)
            {
                case 0:
                    return HeroesSet.Lich;
                case 1:
                    return HeroesSet.Grunt;
                case 2:
                    return HeroesSet.Footman;
                default:
                    return 0;
            }
        }

        public static int GetIndexOfChoosenHero()
        {
            return GameObject.Find("ScrollView").GetComponent<ScrollSnapRect>().GetCurrentPage();
        }

        public static string GetPlayerName()
        {
            string plName = GameObject.Find("NameInputField").GetComponent<InputField>().text;
            //Debug.Log(plName);
            return plName;
        }

    }
}
