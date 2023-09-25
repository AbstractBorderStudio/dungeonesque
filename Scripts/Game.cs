using Godot;
using System.Collections.Generic;

namespace Dungeonesque
{
    /// <summary>
    /// Global Game Manger to handle game's data
    /// </summary>
    /// 
    public partial class Game : Node
    {
        public static Game Instance {get; set;}
        private Story story = new Story();
        private List<Player> players = new List<Player>();
        public Story Story {
            get{return story;} 
            set{story = value;}
        }
        public List<Player> Players {
            get{return players;}
            set{players = value;}
        }

        public override void _Ready()
        {
            Instance = this;
        }
    }
}
