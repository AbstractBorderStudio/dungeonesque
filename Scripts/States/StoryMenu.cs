using Godot;
using Godot.Collections;
using System;

namespace Dungeonesque
{
    public partial class StoryMenu : State
    {
        [ExportGroup("Buttons")]
        [Export]
        private Button back, random, next;
        [ExportGroup("Texts")]
        [Export]
        private TextEdit place, type, description, objective;  
        private Array<Dictionary> storyList;
        public override void _Ready()
        {
            storyList = GetStoryList("res://Resources/settings.json");
            back.ButtonUp += () => OnExitState(false);
            random.ButtonUp += () => SetRandomStory();
            next.ButtonUp += () => OnExitState(true);
        }

        public override void OnExitState(bool next)
        {
            if (!next) 
            {
                ClearSetting();
            }
            else 
            {
                if (place.Text == "" || type.Text == "" || description.Text == "" || objective.Text == "") return;
            }
            this.Visible = false;
            EmitSignal("Transition", next);
        }

        public override void OnEnterState()
        {
            this.Visible = true;
        }

        /// <summary>
        /// Open a Json file and returns an Array of dictionaries
        /// </summary>
        private Array<Dictionary> GetStoryList(string path)
        {
            // retrive file data
            var file = FileAccess.Open(path, FileAccess.ModeFlags.Read); 
            var text = file.GetAsText();
            file.Close();

            var result = Json.ParseString(text);
            Dictionary dic = result.As<Dictionary>();
            var content = dic["places"];
            Array<Dictionary> list = content.As<Array<Dictionary>>();
            return list;
        }

        /// <summary>
        /// Randomize the story by choosing a random element from the *storyList*
        /// </summary>
        public void SetRandomStory()
        {
            Story newStory = new Story();

            Random random = new Random();
            Dictionary story = storyList[random.Next(0, storyList.Count)]; 

            // set values
            place.Text = newStory.Place = story["name"].As<string>();
            type.Text = newStory.Type = story["theme"].As<string>();
            description.Text = newStory.Description = story["description"].As<string>();
            objective.Text = newStory.Objective = story["objective"].As<string>();
            newStory.Entities = story["entities"].As<Array<string>>();

            // set story
            Game.Instance.Story = newStory;

            GD.Print("Random Story Set");
        }

        /// <summary>
        /// Clear the textEdits
        /// </summary>
        public void ClearSetting()
        {
            place.Text = "";
            type.Text = "";
            description.Text = "";
            objective.Text = ""; 

            Game.Instance.Story = null;

            GD.Print("Story cleard.");
        }
    }

    public class Story
    {
        private string place, type, description, objective;
        private Array<string> entities;

        public string Place {
            get{return place;}
            set{place = value;} 
        }

        public string Type {
            get{return type;}
            set{type = value;} 
        }

        public string Description {
            get{return description;}
            set{description = value;} 
        }

        public string Objective {
            get{return objective;}
            set{objective = value;} 
        }

        public Array<string> Entities {
            get{return entities;}
            set{entities = value;} 
        }
    }
}