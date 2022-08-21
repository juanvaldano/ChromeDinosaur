using UnityEngine;
using System.Linq;

public class Utils : MonoBehaviour
{
    /*Static functions can be called from anywhere
    The script that contains them neend not be instantiated
    "params" + an array allows us to pass an unkown number of parameters*/
    static public bool AllPositiveValues(params float[] numbers)
    {
        return numbers.All(n => n > 0);
    }

    static public bool AllPositiveValues(params int[] numbers)
    {
        return numbers.All(n => n > 0);
    }
}
