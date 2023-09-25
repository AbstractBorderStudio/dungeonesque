using Godot;
using System;
using System.Collections.Generic;

namespace Dungeonesque {
    public partial class PlayerMenu : State
    {
        const int MIN_HEALT  = 3,
            MAX_HEALT = 10,
            MIN_INIT = 1,
            MAX_INIT = 7;

        [ExportGroup("Buttons")]
        [Export]
        private Button add, back, start, clear;
        [ExportGroup("Texts")]
        [Export]
        private TextEdit name, nick, ability, item;
        [ExportGroup("Box")]
        [Export]
        private CardDisplay playerCardContainer;
        private List<Player> players = new List<Player>(); 
        public override void _Ready()
        {
            add.ButtonUp += () => AddPlayer();
            back.ButtonUp += () => OnExitState(false);
            start.ButtonUp += () => OnExitState(true);
            clear.ButtonUp += () => ClearPlayers();
        }
        
        public override void OnExitState(bool next)
		{
			// do stuff
            if (!next) 
            {
                ClearTextMenu();
                ClearPlayers();
            }
            else 
            {
                // check if at least 1 player was added
                if (players.Count < 1) return;
                // update Game State
                Game.Instance.Players = players;
            }
            this.Visible = false;
			EmitSignal("Transition", next);
		}

		public override void OnEnterState()
		{
			this.Visible = true;
		}


        public void AddPlayer()
        {
            string _name = name.Text;
            string _nick = nick.Text;
            string _ability = ability.Text;
            string _item = item.Text;

            
            if (_name == "" || _nick == "" || _ability == "" || _item == "") return;

            ClearTextMenu();

            // randomize hp and initiative
            Random random = new Random();
            
            int _hp = random.Next(MIN_HEALT, MAX_HEALT);
            int _init = random.Next(MIN_INIT, MAX_INIT); 

            Player newPlayer = new Player(
                _name,
                _nick,
                _ability,
                _item,
                _hp,
                _init
            );

            players.Add(newPlayer);
            players.Sort((x,y) => y.Initiative.CompareTo(x.Initiative));

            playerCardContainer.ClearDisplay();
            
            foreach(Player p in players)
            {
                playerCardContainer.AddCard(p);
            }
            GD.Print("Player added successfully!");
        }

        public void ClearPlayers()
        {
            if (players.Count <= 0)
            {
                GD.Print("Player list already empty!");
                return;
            }
            // clear all players
            players.Clear();

            // update Game State
            Game.Instance.Players.Clear();

            // clear playerCardContainer
            playerCardContainer.ClearDisplay();
            GD.Print("Player list cleared successfully!");
        }

        public void ClearTextMenu()
        {
            name.Text = "";
            nick.Text = "";
            ability.Text = "";
            item.Text = "";
        }
    }
}
