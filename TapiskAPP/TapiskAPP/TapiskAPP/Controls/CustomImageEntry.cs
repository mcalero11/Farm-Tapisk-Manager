using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TapiskAPP.Controls
{
    public class CustomImageEntry : Entry
    {
        public CustomImageEntry()
        {
            this.HeightRequest = 50;
        }
        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create(propertyName: nameof(Image), 
                                    returnType: typeof(string),
                                    declaringType: typeof(CustomImageEntry), 
                                    defaultValue: string.Empty);

        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create(nameof(LineColor), typeof(Xamarin.Forms.Color), typeof(CustomImageEntry), Color.White);

        public static readonly BindableProperty ImageHeightProperty =
            BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(CustomImageEntry), 40);

        public static readonly BindableProperty ImageWidthProperty =
            BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(CustomImageEntry), 40);

        public static readonly BindableProperty ImageAlignmentProperty =
            BindableProperty.Create(nameof(ImageAlignment), typeof(ImageAlignment), typeof(CustomImageEntry), ImageAlignment.Left);

        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public ImageAlignment ImageAlignment
        {
            get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }
            set { SetValue(ImageAlignmentProperty, value); }
        }
    }

    public enum ImageAlignment
    {
        Left,
        Right
    }
}

