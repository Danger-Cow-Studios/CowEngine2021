using System.Collections.Generic;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace CowEngine
{
    public class Game
    {
        public enum DrawMode { Flat, FlatAndSpacial };

        public WindowProperties Window;
        public delegate void init(Game g);
        DrawMode mode = DrawMode.Flat;
        public CameraObject cam;

        public List<GameObject> Objects = new List<GameObject>();

        public void StartGame()
        {
            InitWindow(Window.Width, Window.Height, Window.Name);

            SetTargetFPS(Window.FPSLimit);
            CallObjects(Behavior.callTypes.onAwake);

            while (!WindowShouldClose())
            {
                CallObjects(Behavior.callTypes.onUpdate);

                BeginDrawing();
                ClearBackground(Color.WHITE);

                if (mode == DrawMode.FlatAndSpacial)
                {
                    BeginMode3D(cam.cam);

                    CallObjects(Behavior.callTypes.onDrawSpacial);

                    EndMode3D();
                }

                CallObjects(Behavior.callTypes.onDraw);

                EndDrawing();
            }
        }

        public void Enable3D()
        {
            mode = DrawMode.FlatAndSpacial;

            cam = new CameraObject();
            Objects.Add(cam);
        }

        void CallObjects(Behavior.callTypes type)
        {
            foreach (GameObject o in Objects) { foreach (Behavior b in o.Behaviors) {
                b.onCall(type, o);
            }}
        }

        public Game(WindowProperties WindowSettings, init InitilizeScript)
        {
            Window = WindowSettings;
            InitilizeScript(this);
        }
    }

    public class WindowProperties
    {
        public int Width, Height, FPSLimit;
        public string Name;
        public Color ClearColor = Color.WHITE;

        public WindowProperties(int width, int height, string name, int FPSLimit = 60)
        {
            Width = width;
            Height = height;
            Name = name;

            this.FPSLimit = FPSLimit;
        }

        public static readonly WindowProperties Default = new WindowProperties(800, 450, "RaylibWindow");
        public static readonly WindowProperties Sqaure = new WindowProperties(450, 450, "RaylibWindow");
    }
}
