using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scr
{
    public class PVTBehaviour: MonoBehaviour
    {
        protected void Awake()
        {
            loadComponents();
        }
        protected void Reset()
        {
            loadComponents();
        }
        protected virtual void OnEnable()
        {
            
        }
        protected virtual void FixedUpdate()
        {
        }
        protected virtual void Update()
        {
        }
        protected virtual void loadComponents() { }

    }
}
