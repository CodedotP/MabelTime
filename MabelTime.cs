using UnityEngine;

namespace Mabel.Timing
{
    public class MabelTime
    {
        float speedMultiplier = 1;
        int rawMinutes;

        [HideInInspector] public int Hour;
        [HideInInspector] public int Minutes;
        [HideInInspector] public float Seconds;



        //Update the current time
        public void UpdateTime(float scale)
        {
            if (Seconds >= 60)
            {
                Minutes++;
                rawMinutes++;
                if (Minutes >= 60)
                {
                    Minutes = 0;
                    Hour++;
                    if (Hour >= 24)
                    {
                        Hour = 0;
                        rawMinutes = 0;
                    }
                }
                Seconds = 0;
            }
            Seconds += (Time.fixedUnscaledDeltaTime * speedMultiplier) * scale;
        }
        public void UpdateTime()
        {
            if (Seconds >= 60)
            {
                Minutes++;
                rawMinutes++;
                if (Minutes >= 60)
                {
                    Minutes = 0;
                    Hour++;
                    if (Hour >= 24)
                    {
                        Hour = 0;
                        rawMinutes = 0;
                    }
                }
                Seconds = 0;
            }
            Seconds += (Time.fixedUnscaledDeltaTime * speedMultiplier);
        }

        //Constructor of the class
        public MabelTime(int hour, int minutes, int seconds)
        {
            Hour = (int)Mathf.Clamp(hour, 0, 24);
            Minutes = (int)Mathf.Clamp(minutes, 0, 60);
            Seconds = (int)Mathf.Clamp(seconds, 0, 60);
            rawMinutes = (int)(hour * 60f + minutes);
        }
        public MabelTime()
        {
        }

        //Set voids
        public void SetTime(int hour, int minutes, int seconds)
        {
            Hour = (int)Mathf.Clamp(hour, 0, 24);
            Minutes = (int)Mathf.Clamp(minutes, 0, 60);
            Seconds = (int)Mathf.Clamp(seconds, 0, 60);
            rawMinutes = (int)(hour * 60f + minutes);
        }
        public void SetSpeedMultiplier(float valu)
        {
            speedMultiplier = valu;
        }


        //Debug and lerping information
        public override string ToString()
        {
            return string.Format("Hour : {0}, Minutes : {1}, Seconds : {2}", this.Hour, this.Minutes, Mathf.RoundToInt(this.Seconds));
        }
        public static implicit operator float(MabelTime cl)
        {
            return cl.rawMinutes / 1440f;
        }

    }

}
