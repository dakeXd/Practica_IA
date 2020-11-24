using Assets.Scripts.DataStructures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lista : MonoBehaviour
{
    public Nodos inicial;
    public Nodos ultimo;
    int longitud;

    public Lista(Nodos inicial) {
        this.inicial = inicial;
        this.ultimo = inicial;
        this.longitud = 1;

    }
    public Lista() {
        this.inicial = null;
        this.longitud = 0;
        this.ultimo = null;
    }

    public void push(Nodos nodo) {
        if (longitud > 0)
        {
            ultimo.siguiente = nodo;
            nodo.anterior = ultimo;
            ultimo = nodo;
            longitud++;
        }
        else {
            this.inicial = nodo;
            this.ultimo = nodo;
            this.longitud = 1;
        }
    }

    public Nodos pop() {
        if (longitud > 0)
        {
            Nodos aux = inicial;
            inicial = inicial.siguiente;
            longitud--;
            return aux;
        }
        else {
            return null;
        }
    }

    public Nodos[] expand(BoardInfo board)
    {
        int gStarNew = inicial.gStar++;
        Nodos[] nodosExpandidos = new Nodos[4];
        CellInfo[] cercanas = inicial.info.WalkableNeighbours(board);
        for (int i = 0; i < cercanas.Length; i++) {
            nodosExpandidos[i] = new Nodos(cercanas[i]);
            nodosExpandidos[i].gStar = gStarNew;    
     
        }
        pop();
        return nodosExpandidos;
    }

    public void agregarOrdenado(Nodos nodo) {

        Nodos aux = inicial;
        int contador = 0;
        while (nodo.fStar > aux.fStar && contador < longitud) {
            aux = aux.siguiente;
        }
        if (aux == inicial)
        {
            nodo.siguiente = inicial;
            inicial.anterior = nodo;
            inicial = nodo;
            longitud++;
        }
        else
        if (contador == longitud - 1)
        {
            push(nodo);
        }
        else {
            aux.anterior.siguiente = nodo;
            nodo.anterior = aux.anterior;
            aux.anterior = nodo;
            nodo.siguiente = aux;
            longitud++;
        }
    }

}

