using Godot;

namespace Dungeonesque
{
    public partial class State : Control
    {
        [Signal] public delegate void TransitionEventHandler(bool next);
        [Signal] public delegate void QuitEventHandler();

        /// <summary>
        /// Called when exiting current state
        /// </summary>
        /// <param name="next">If true go to the next scene, else go the previous one</param>
        public virtual void OnExitState(bool next)
        {}

        /// <summary>
        /// Called when entering current state
        /// </summary>
        public virtual void OnEnterState()
        {}
    }
}