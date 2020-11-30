using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

/// <summary>
/// Summary description for ImageResize
/// </summary>
public class ImageResize
{


    enum Dimensions
    {
        Width,
        Height
    }
    enum AnchorPosition
    {
        Top,
        Center,
        Bottom,
        Left,
        Right
    }
    public static Image ScaleByPercent(Image imgPhoto, int Percent)
    {
        float nPercent = ((float)Percent / 100);

        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;

        int destX = 0;
        int destY = 0;
        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        grPhoto.Dispose();
        return bmPhoto;
    }
    static Image ConstrainProportions(Image imgPhoto, int Size, Dimensions Dimension)
    {
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;
        float nPercent = 0;

        switch (Dimension)
        {
            case Dimensions.Width:
                nPercent = ((float)Size / (float)sourceWidth);
                break;
            default:
                nPercent = ((float)Size / (float)sourceHeight);
                break;
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
        new Rectangle(destX, destY, destWidth, destHeight),
        new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
        GraphicsUnit.Pixel);

        grPhoto.Dispose();
        return bmPhoto;
    }

    public static byte[] FixedSize(string ResimYolu, int Width, int Height)
    {
        Image imgPhoto = Image.FromFile(ResimYolu);
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);

        //if we have to pad the height pad both the top and the bottom
        //with the difference between the scaled height and the desired height
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = (int)((Width - (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = (int)((Height - (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.White);
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        grPhoto.Dispose();
        byte[] buffer = null;
        using (MemoryStream ms = new MemoryStream())
        {
            if (ResimYolu.IndexOf("jpg") > -1)
            {
                bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (ResimYolu.IndexOf("jpeg") > -1)
            {
                bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (ResimYolu.IndexOf("png") > -1)
            {
                bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (ResimYolu.IndexOf("gif") > -1)
            {
                bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            }
            else
            {
                bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            buffer = ms.ToArray();
        }
        return buffer;
    }

    public static byte[] imgCrop(string ResimYolu, int Width, int Height)
    {
        Image imgPhoto = Image.FromFile(ResimYolu);
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);

        if (nPercentH < nPercentW)
        {
            nPercent = nPercentW;
            destY = (int)((Height - (sourceHeight * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentH;
            destX = (int)((Width - (sourceWidth * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);
        grPhoto.Dispose();

        byte[] buffer = null;
        using (MemoryStream ms = new MemoryStream())
        {
            if (ResimYolu.IndexOf("jpg") > -1)
            {
                bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (ResimYolu.IndexOf("jpeg") > -1)
            {
                bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (ResimYolu.IndexOf("png") > -1)
            {
                bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (ResimYolu.IndexOf("gif") > -1)
            {
                bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            }
            else
            {
                bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            buffer = ms.ToArray();
        }
        return buffer;
    }


    public ImageResize()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}