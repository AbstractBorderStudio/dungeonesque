using System;
using System.Dynamic;
using System.Globalization;
using Godot;

namespace Dungeonesque
{
    public class Player
    {
        public string Name{get; set;}
        public string Nickname{get; set;}
        public string Ability{get; set;}
        public string Item{get; set;}

        public int Hp {get; set;}
        public int Initiative {get; set;}

        public Player(
            string _name, 
            string _nick, 
            string _ability, 
            string _item,
            int _hp,
            int _init)
        {
            Name = _name;
            Nickname = _nick;
            Ability = _ability;
            Item = _item;
            Hp = _hp;
            Initiative = _init;
        }

        public void GetDamage(int damage)
        {
            Hp -= damage;
            if (Hp <= 0) Die();
        }

        public void Die()
        {
            GD.Print(Nickname + " died an horrible death.");
        }
    }
}
