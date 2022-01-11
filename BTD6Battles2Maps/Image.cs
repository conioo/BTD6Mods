using MelonLoader;
using HarmonyLib;

using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity;
using System.IO;
using Assets.Main.Scenes;
using UnityEngine;
using System.Linq;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Data.MapSets;
using Assets.Scripts.Models.Map.Spawners;
using Assets.Scripts.Models.Map;
using UnhollowerBaseLib;
using Assets.Scripts.Data;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper;
using Assets.Scripts.Unity.Map;
using Assets.Scripts.Unity.Bridge;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Net;
using Il2CppSystem.Collections.Generic;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppSystem.Reflection;
using Assets.Scripts.Unity.UI_New.Main.MapSelect;
using Assets.Scripts.Unity.Player;
using NinjaKiwi.Common;

namespace BTDBattles2Maps
{
    class Image
    {
        public static byte[] Resize(byte[] data, int width, int height)
        {
            using (var stream = new MemoryStream(data))
            {
                var image = System.Drawing.Image.FromStream(stream);

                Bitmap b = ResizeImage(image, width, height);

                using (var thumbnailStream = new MemoryStream())
                {
                    b.Save(thumbnailStream, ImageFormat.Png);
                    return thumbnailStream.ToArray();
                }
            }
        }

        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = System.Drawing.Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
