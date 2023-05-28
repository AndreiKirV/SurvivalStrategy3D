using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Dictionary
{
    public class Dictionaries
    {

        public class Path
        {
            public static readonly string PRREFABS = "Prefabs/";
            public static readonly string BUILDINGS = PRREFABS + "Buildiings/";

            public class UI
            {
                protected internal static readonly string Ui = PRREFABS + "UI/";
                public static readonly string  Cursor = Ui + "Cursor";
                public class STORE
                {
                    private static readonly string Stores = Ui + "Stores/";
                }
            }
        }
    }    
}