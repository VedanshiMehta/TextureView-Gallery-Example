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

namespace TextureViewEx
{
    class GalleryAdapter : BaseAdapter
    {
        Context c;

        public GalleryAdapter(Context c)
        {
            this.c = c;
        }

        public override int Count { get { return turid.Length; } }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView iView = new ImageView(c);

            iView.SetImageResource(turid[position]);
            iView.LayoutParameters = new Gallery.LayoutParams(450, 550);
            iView.SetScaleType(ImageView.ScaleType.FitXy);
            return iView;
        }

        int[] turid = {

                Resource.Drawable.TurkeyAnkara,
                Resource.Drawable.TurkeyAntalya,
                Resource.Drawable.TurkeyCappadocia,
                Resource.Drawable.TurkeyEphesus,
                Resource.Drawable.TurkeyIzmir,

        };



    }
}