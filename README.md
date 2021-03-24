# CowEngine2021
epic game engine for epic gamers

CowEngine is not a 100% a game engin., Its a thing built ontop of raylib to make game creation easyer, faster and more simular to unity

Spinning cow example (CowEngine):
```csharp
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
```

Spinning cow example (Just raylib):
```csharp
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.CameraMode;
using static Raylib_cs.CameraType;
using System.Collections.Generic;

namespace CowSpeen
{
    class cow
    {
        public Vector3 Position = Vector3.Zero;
        Vector3 RotationPiviot = new Vector3(0, 1, 0);
        public float RotationAngle = 90;
        float scale = 2;

        Model model;
        Texture2D texture;

        public unsafe cow()
        {
            model = LoadModel("cow.obj");
        }

        public void draw()
        {
            DrawModelEx(model, Position, RotationPiviot, RotationAngle, Vector3.One * scale, WHITE);
        }
    }

    class Program
    {
        static unsafe void Main(string[] args)
        {
            InitWindow(1000, 1000, "Cow speeen");

            Camera3D camera = new Camera3D();
            camera.position = new Vector3(0.0f, 2f, 500.0f);  // Camera position
            camera.target = new Vector3(0.0f, 2.0f, 0.0f);      // Camera looking at point
            camera.up = new Vector3(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
            camera.fovy = 60.0f;                                // Camera field-of-view Y
            camera.type = CAMERA_PERSPECTIVE;                   // Camera mode type
            SetCameraMode(camera, CAMERA_ORBITAL);

            cow c = new cow();

            SetTargetFPS(60);

            while (!WindowShouldClose())
            {
                UpdateCamera(ref camera);

                BeginDrawing();
                ClearBackground(WHITE);
                BeginMode3D(camera);

                c.draw();

                DrawGrid(10, 1.0f);

                EndMode3D();

                DrawFPS(10, 10);
                EndDrawing();
            }

            CloseWindow();
        }
    }
}

```
