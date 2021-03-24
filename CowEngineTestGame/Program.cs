using CowEngine;
using Raylib_cs;
using System;
using System.Numerics;
using static CowEngine.Behavior;
using static Raylib_cs.Raylib;

namespace CowEngineTestGame
{
    class Program
    {
        static void Main(string[] args)
        {
            float t = 0;

            Game Game = new Game(WindowProperties.Default, (Game g) => {

                MeshRenderer PlayerMesh = new MeshRenderer("cow.obj");

                GameObject Player = new GameObject((callTypes call, GameObject obj) => {
                    if (call == callTypes.onAwake)
                    {
                        PlayerMesh.tint = Color.RED;
                    }

                    if(call == callTypes.onUpdate)
                    {
                        t += GetFrameTime();
                        g.cam.transform.translation = new Vector3((float)Math.Sin(t) * 10, 5, (float)Math.Cos(t) * 10);
                    }

                    if (call == callTypes.onDrawSpacial) { DrawGrid(10, 1); }
                    if (call == callTypes.onDraw) { DrawFPS(10, 10); }

                });

                Player.Behaviors.Add(PlayerMesh);
                g.Objects.Add(Player);

                g.Window = WindowProperties.Sqaure;
                g.Window.Name = "Cow speeeen";

                g.Enable3D();
                g.StartGame();

            });
        }
    }
}
