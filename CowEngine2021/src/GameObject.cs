using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace CowEngine
{
    public class GameObject
    {
        public Transform transform;
        public List<Behavior> Behaviors = new List<Behavior>();

        public GameObject(Behavior.CallHandle CreateDefaultBehavior = null)
        {
            transform.scale = Vector3.One;

            if (CreateDefaultBehavior != null)
            {
                Behavior b = new Behavior(CreateDefaultBehavior);
                Behaviors.Add(b);
            }
        }
    }

    public class Behavior
    {
        public enum callTypes { onUpdate, onDraw, onDrawSpacial, onAwake }
        public delegate void CallHandle(callTypes call, GameObject g);

        public CallHandle onCall;

        public Behavior(CallHandle onCall)
        {
            this.onCall = onCall;
        }
        public Behavior() { }
    }
}
