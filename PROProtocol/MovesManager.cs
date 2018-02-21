using Newtonsoft.Json;
using System.Collections.Generic;

namespace PROProtocol
{
    public class MovesManager
    {
        public class MoveData
        {
            public string Name;
            public int Power;
            public int Accuracy;
            public string Type;
            public bool Status;
            public DamageType DamageType;
        }

        public enum DamageType
        {
            Physical = 0,
            Special = 1
        }

        private static MovesManager _instance;

        public static MovesManager Instance
        {
            get
            {
                return _instance ?? (_instance = new MovesManager());
            }
        }

        public Dictionary<int, MoveData> Moves;

        private MovesManager()
        {
            Moves = JsonConvert.DeserializeObject<Dictionary<int, MoveData>>(Properties.Resources.moves);
            //Moves[0] is custom unkown move, because MoveName[0]=string.Empty in Poke Pro.
            Moves.Add(0, new MoveData { Name = "Unknown Move", Power = 0, Accuracy = 0, Type = "normal", Status = false, DamageType = DamageType.Physical });
        }

        public MoveData GetMoveData(int moveId)
        {
            if (moveId < Moves.Count)
            {
                return Moves[moveId];
            }
            return Moves[0];
        }
    }
}
