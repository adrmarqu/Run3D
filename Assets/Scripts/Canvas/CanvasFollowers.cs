using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFollowers : MonoBehaviour
{
    public Text followers;

    public void FollowerCanvas(int num)
    {
        followers.text = "Followers: " + num;
    }
}
