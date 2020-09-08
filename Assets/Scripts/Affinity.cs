using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;


    public abstract class Affinity
    {
        public enum AffinityType
        {
            Fire,
            Wind,
            Water,
            Earth,
            Dark,
            Light
        }

        private static readonly Dictionary<Tuple<AffinityType, AffinityType>, float> affinityInteractionValues = new Dictionary<Tuple<AffinityType, AffinityType>, float>
        {
            { new Tuple<AffinityType, AffinityType> (AffinityType.Dark,  AffinityType.Dark),  0.5f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Dark,  AffinityType.Light), 2.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Dark,  AffinityType.Fire),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Dark,  AffinityType.Water), 1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Dark,  AffinityType.Wind),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Dark,  AffinityType.Earth), 1.0f },

            { new Tuple<AffinityType, AffinityType> (AffinityType.Light, AffinityType.Dark),  2.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Light, AffinityType.Light), 0.5f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Light, AffinityType.Fire),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Light, AffinityType.Water), 1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Light, AffinityType.Wind),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Light, AffinityType.Earth), 1.0f },

            { new Tuple<AffinityType, AffinityType> (AffinityType.Fire,  AffinityType.Dark),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Fire,  AffinityType.Light), 1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Fire,  AffinityType.Fire),  0.5f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Fire,  AffinityType.Water), 2.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Fire,  AffinityType.Wind),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Fire,  AffinityType.Earth), 0.0f },

            { new Tuple<AffinityType, AffinityType> (AffinityType.Water, AffinityType.Dark),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Water, AffinityType.Light), 1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Water, AffinityType.Fire),  0.5f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Water, AffinityType.Water), 0.5f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Water, AffinityType.Wind),  2.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Water, AffinityType.Earth), 1.0f },

            { new Tuple<AffinityType, AffinityType> (AffinityType.Wind,  AffinityType.Dark),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Wind,  AffinityType.Light), 1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Wind,  AffinityType.Fire),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Wind,  AffinityType.Water), 0.5f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Wind,  AffinityType.Wind),  0.5f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Wind,  AffinityType.Earth), 0.5f },

            { new Tuple<AffinityType, AffinityType> (AffinityType.Earth, AffinityType.Dark),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Earth, AffinityType.Light), 1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Earth, AffinityType.Fire),  1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Earth, AffinityType.Water), 1.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Earth, AffinityType.Wind),  2.0f },
            { new Tuple<AffinityType, AffinityType> (AffinityType.Earth, AffinityType.Earth), 0.5f }

        };

        public static float InteractValue(AffinityType attack, AffinityType target)
        {
            return affinityInteractionValues[new Tuple<AffinityType, AffinityType>(attack, target)];
        }
    }

