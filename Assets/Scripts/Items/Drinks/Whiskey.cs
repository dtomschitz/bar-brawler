using UnityEngine;
using Utils;

namespace Items
{
    public class Whiskey : Consumable
    {
        public override void OnPrimary()
        {
            base.OnPrimary();
            StartDrinking();
        }
    }
}

