using System.Collections;
using UnityEditor.U2D;
using UnityEngine;

namespace Managers
{
    public abstract class Panel : MonoBehaviour
    {
        public virtual void Show(Hashtable args)
        {
        }
    }
}