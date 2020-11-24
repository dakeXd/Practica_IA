using Assets.Scripts.DataStructures;
using UnityEngine;

namespace Assets.Scripts.SampleMind
{
    public class RandomMind : AbstractPathMind {
        public override void Repath()
        {
            
        }

        public override Locomotion.MoveDirection GetNextMove(BoardInfo boardInfo, CellInfo currentPos, CellInfo[] goals)
        {
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
