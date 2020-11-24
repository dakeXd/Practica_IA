using Assets.Scripts.DataStructures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodos : MonoBehaviour
{
    // Start is called before the first frame update

    public Nodos anterior;
    public Nodos siguiente;
    public CellInfo info;
    public int gStar = 0;
    public int fStar = 0;

    public Nodos(Nodos anterior, Nodos siguiente, CellInfo info) {
        this.anterior = anterior;
        this.siguiente = siguiente;
        this.info = info;
    }
   public Nodos(Nodos anterior, CellInfo info)
    {
        this.anterior = anterior;
        this.siguiente = null;
        this.info = info;
        
    }
    public Nodos(CellInfo info)
    {
        this.anterior = null;
        this.siguiente = null;
        this.info = info;
    }
    public Nodos() {
        this.anterior = null;
        this.siguiente = null;
        this.info = null;
    }

    public void calcularFstar(CellInfo objetivo) {
        fStar = info.Hstar(objetivo);
    }
    
}
