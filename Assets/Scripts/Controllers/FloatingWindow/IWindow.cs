using System;
using System.Collections;
using TMPro;

namespace Controllers.FloatingWindow
{
    public interface IWindow
    {
        Action OnClose { get; set; }
        void Show(Hashtable args);

        void Close();
    }
}