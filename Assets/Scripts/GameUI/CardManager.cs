using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class CardManager : MonoBehaviour
    {
        private CardInGame Myself;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI cost;
        [SerializeField] private TextMeshProUGUI power;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI description;
        public void Spawned(CardInGame me)
        {
            Myself = me;
            image.sprite = me.baseCard.sprite;
            cost.text = Myself.currentCost.ToString();
            power.text = Myself.currentPower.ToString();
            title.text = Myself.baseCard.name.ToString();
            description.text = Myself.baseCard.description.ToString();

            if (me.currentPower > me.baseCard.power)
            {
                power.color = Color.green;
            }
            else if(me.currentPower < me.baseCard.power)
            {
                power.color = Color.red;
            }
            else
            {
                power.color = Color.white;
            }

            if (me.currentCost > me.baseCard.cost)
            {
                cost.color = Color.green;
            }
            else if (me.currentCost < me.baseCard.cost)
            {
                cost.color = Color.red;
            }
            else
            {
                cost.color = Color.white;
            }
        }

    }
}