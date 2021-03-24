using Raylib_cs;
using System.Numerics;

namespace CowEngine
{
    public class CameraObject : GameObject
    {
        public Camera3D cam;
        public new CameraTransform transform;

        public CameraObject()
        {
            cam = new Camera3D();
            transform.translation = new Vector3(0, 5, 10);
            transform.target = new Vector3(0, 0, 0);
            transform.rotation = new Vector4(0, 1, 0, 0);
            cam.fovy = 60;
            cam.type = CameraType.CAMERA_PERSPECTIVE;

            Behaviors.Add(new Behavior((Behavior.callTypes call, GameObject g) => {
                if (call == Behavior.callTypes.onUpdate)
                {
                    cam.position = transform.translation;
                    cam.up = new Vector3(transform.rotation.X, transform.rotation.Y, transform.rotation.Z);
                    cam.target = transform.target;
                }
            }));
        }

        public struct CameraTransform
        {
            public Vector3 translation;
            public Vector4 rotation;
            public Vector3 scale;
            public Vector3 target;
        }
    }
}
