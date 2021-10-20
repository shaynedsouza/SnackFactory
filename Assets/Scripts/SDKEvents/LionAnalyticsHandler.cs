using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LionStudios.Analytics;
namespace underDOGS.SDKEvents
{
    [CreateAssetMenu(fileName = "LionAnalyticsSettings", menuName = "Settings/SDKs/LionAnalyticsSettings")]
    public class LionAnalyticsHandler : SDKEventHandler
    {
        public override void InitSDK()
        {
            LionAnalytics.GameStart();
        }

        public override void SendEvent(SDKEventData data)
        {
#if UNITY_EDITOR
            Debug.Log($"Lion Analytics Send Event called: {data.GetEventDataString()}");
#endif

            switch (data.status)
            {
                case "start":
                    LionAnalytics.LevelStart((int)data.level, 1);
                    break;

                case "fail":
                    LionAnalytics.LevelFail((int)data.level, 1);
                    break;

                case "complete":
                    LionAnalytics.LevelComplete((int)data.level, 1);
                    break;
            }
        }
    }
}
