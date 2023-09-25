using Godot;
using System.Collections.Generic;

namespace Dungeonesque
{
    public partial class SceneHandler : Node
    {    
        private AnimationPlayer sceneAnim;
        
        [Export] 
        private State menu;
        [Export]
        private Godot.Collections.Array<PackedScene> pkStates;
        private List<State> inStates;
        private int currentState;
        
        public override void _Ready()
        {
            sceneAnim = GetChild<AnimationPlayer>(0);
            inStates = new List<State>();
            
            // instantiate all the UI scene and populate inStates
            for (int i = 0; i < pkStates.Count; i++)
            {
                State _state = (State)pkStates[i].Instantiate();
                _state.Transition += (next) => HandleTransition(next);
                inStates.Add(_state);
                if (i > 0) _state.Visible = false;
                this.GetParent().CallDeferred("add_child", _state);
            }
            currentState = 0;
        }

        /// <summary>
        /// Change scene to the next/previous
        /// </summary>
        /// <param name="next">If true go to the next scene, else go the previous one</param>
        private void HandleTransition(bool next)
        {
            if (next)
            {
                if (currentState >= inStates.Count - 1) return;
                currentState++;
            }
            else
            {
                if (currentState == 0)
                {
                    GetTree().Quit();
                    return;
                }
                else if (currentState >= inStates.Count - 1)
                {
                    currentState = 0;
                }
                else currentState--;
            }
            State _next = inStates[currentState];
            _next.OnEnterState();
            GD.Print("Scene transitioned to " + inStates[currentState].Name);
        }
    }
}