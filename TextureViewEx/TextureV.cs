using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Hardware;
using Android;

namespace TextureViewEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    class TextureV : Activity, TextureView.ISurfaceTextureListener
    {
        [Obsolete]
        Camera _myCamera;
        TextureView _mytextureView;
       readonly string[] permissionGroup = {
         Manifest.Permission.Camera
       };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _mytextureView = new TextureView(this);
            _mytextureView.SurfaceTextureListener = this;

            SetContentView(_mytextureView);
            RequestPermissions(permissionGroup, 0);
        }

        [Obsolete]
        public void OnSurfaceTextureAvailable(Android.Graphics.SurfaceTexture surface, int width, int height)
        {
            if (Camera.NumberOfCameras == 0)
            {
                Toast.MakeText(this, Resource.String.no_camera, ToastLength.Long).Show();
                return;
            }
            _myCamera = Camera.Open();
            if (_myCamera == null)
                _myCamera = Camera.Open(0);



            var previewSize = _myCamera.GetParameters().PreviewSize;
            _mytextureView.LayoutParameters =
                new FrameLayout.LayoutParams(previewSize.Width, previewSize.Height, GravityFlags.Center);
            try
            {
                _myCamera.SetPreviewTexture(surface);
                _myCamera.StartPreview();
            }
            catch (Java.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            _mytextureView.Rotation = 45.0f;
            _mytextureView.Alpha = 0.5f;
        }

        [Obsolete]
        public bool OnSurfaceTextureDestroyed(Android.Graphics.SurfaceTexture surface)
        {
            _myCamera.StopPreview();
            _myCamera.Release();
            return true;
        }

        public void OnSurfaceTextureSizeChanged(Android.Graphics.SurfaceTexture surface, int width, int height)
        {
           // throw new NotImplementedException();
        }

        public void OnSurfaceTextureUpdated(Android.Graphics.SurfaceTexture surface)
        {
           // throw new NotImplementedException();
        }

      
    }
}