using System;
using TMPro;
using UnityEngine;

namespace Mechanics
{
    public class Item : MonoBehaviour    
    { 
        [field: SerializeField] public string Name { get; private set; }
    }
}