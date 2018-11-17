using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TapiskAPP.Controls
{
    public class ShadowControl : Frame
    {
        public static BindableProperty ElevationProperty = BindableProperty.Create(nameof(Elevation), typeof(float), typeof(ShadowControl), 4.0f);

        public float Elevation
        {
            get
            {
                return (float)GetValue(ElevationProperty);
            }
            set
            {
                SetValue(ElevationProperty, value);
            }
        }
    }
}
