using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLecture : MonoBehaviour
{ 
    //This is how to create a value
    //public [type] [name] = [value];
    public int myInt = 0;
    public string myString = "Hello";
    //To make a string value, the value needs ""
    public string cup = "water";

    //public string bottle = 0;
    //Value has to be matched with type.
    public string number = "10";
    //all the value starts with lower case, no spaces
    //cup with milk -> cupWithMilk
    //my int -> myInt, my string -> myString
    //create a string, that named big cup, has coffee as a value
    public string bigCup = "coffee";

    //Challenge: IntroduceMe

    public string myName = "Mike";

    void Start()
    {

        //Debug.Log("name: " + myName + ", age: " + myAge + ", hasPet?: " + hasPet + ", petName: " + petName);
    }

    void Update()
    {
        
    }
}
