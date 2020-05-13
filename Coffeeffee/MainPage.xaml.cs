using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;

namespace Coffeeffee
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        SKPaint whitePaint = new SKPaint() { Color = SKColor.Parse("#FFFFFF") };
        SKPath wavePath = SKPath.ParseSvgPathData("M615.59,178.35c-86.88,0-129.26-89.18-129.26-89.18S435.14,14,375,14,263.63,89.17,263.63,89.17s-42.2,89.18-129.26,89.18S0,0,0,0V200H750V0S702.61,178.35,615.59,178.35Z");

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new List<Coffee>
            {
                new Coffee { Title="XamaCoffee", Price=3.99, Quantity = 1, Image="xamacoffee" },
                new Coffee { Title="XamaCoffee Deluxe", Price=5.99, Quantity = 1 , Image="xamacoffee"},
                new Coffee { Title="XamaCoffee Super Deluxe", Price=10.99, Quantity = 1, Image="xamacoffee" },
            };
        }

        void SKCanvasView_PaintSurface(System.Object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;

            canvas.Clear();

            var pathInfo = wavePath.Bounds;
            var width = e.Info.Width;
            var height = e.Info.Height;

            canvas.Translate(width / 2f, height / 2f);

            var xRatio = width / pathInfo.Width;
            var yRatio = height / pathInfo.Height;
            var ratio = Math.Min(xRatio, yRatio);

            canvas.Scale(ratio);
            canvas.Translate(-wavePath.Bounds.MidX, 0);

            canvas.DrawPath(wavePath, whitePaint);

            canvas.Save();
        }
    }
}
