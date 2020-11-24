using Assets.Scripts.DataStructures;
using UnityEngine;

namespace Assets.Scripts.SampleMind
{
    public class AStar : AbstractPathMind {

        Lista movimientos;
        Lista lista;
        bool aStarted = false;
        public override void Repath()
        {
            
        }

        public void ReCalcular(BoardInfo boardInfo, CellInfo currentPos, CellInfo[] goals) {
            Nodos inicial = new Nodos(currentPos);
            inicial.calcularFstar(goals[0]);
            lista = new Lista(inicial);
            while (lista.inicial.info != goals[0])
            {
                Nodos[] nuevos = lista.expand(boardInfo);
                for (int i = 0; i < nuevos.Length; i++)
                {
                    if (nuevos[i].info != null)
                    {
                        nuevos[i].calcularFstar(goals[0]);
                        lista.agregarOrdenado(nuevos[i]);
                    }
                }
            }

        
        }
        public override Locomotion.MoveDirection GetNextMove(BoardInfo boardInfo, CellInfo currentPos, CellInfo[] goals)
        {
            if (!aStarted) {
                ReCalcular(boardInfo, currentPos, goals);
            }
            CellInfo[] adyacentes = currentPos.WalkableNeighbours(boardInfo);

            int val = 0;
            bool free = false;

            while (!free) 
            {
                val = Random.Range(0, 4);
                if (adyacentes[val] != null) 
                {
                    if (adyacentes[val].ItemInCell != null)
                    {

                        if (adyacentes[val].ItemInCell.Type != PlaceableItem.ItemType.Enemy)
                        {

                            free = true;
                        }
                    }
                    else
                    {
                        free = true;
                    }
  
                }
            }

            

            if (val == 0) return Locomotion.MoveDirection.Up;
            if (val == 1) return Locomotion.MoveDirection.Right;
            if (val == 2) return Locomotion.MoveDirection.Down;
            return Locomotion.MoveDirection.Left;
            
        }
    }
}
