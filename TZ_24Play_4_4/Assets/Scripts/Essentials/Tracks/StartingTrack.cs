using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TZ
{
    public class StartingTrack : Track
    {
        public override void ResetPosition()
        {
            Destroy(gameObject);
        }
    }
}
