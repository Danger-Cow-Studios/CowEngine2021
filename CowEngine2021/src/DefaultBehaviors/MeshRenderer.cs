using System.Numerics;
using System;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace CowEngine
{
    public class MeshRenderer : Behavior
    {
        public Model m;
        public Color tint = Color.WHITE;
        string meshFile;

        public MeshRenderer(string meshFile)
        {
            this.meshFile = meshFile;

            onCall = (callTypes call, GameObject g) => {
                this.meshFile = meshFile;
                if (call == callTypes.onAwake) m = LoadModel(this.meshFile);

                if (call == callTypes.onDrawSpacial)
                {
                    DrawModelEx(m, g.transform.translation, new Vector3(g.transform.rotation.X, g.transform.rotation.Y, g.transform.rotation.Z), g.transform.rotation.W, g.transform.scale, tint);
                }
            };
        }
    }
}
