using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameUI
{
    public class CardManager : MonoBehaviour
    {
        private CardBase Myself;
        [SerializeField] private TextMeshProUGUI cost;
        [SerializeField] private TextMeshProUGUI power;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI description;
        public void Spawned(CardBase me)
        {
            Myself = me;
            cost.text = Myself.cost.ToString();
            power.text = Myself.power.ToString();
            title.text = Myself.name.ToString();
            description.text = Myself.description.ToString();
        }

    }
}