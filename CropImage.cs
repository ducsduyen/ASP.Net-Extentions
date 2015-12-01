public static System.Drawing.Image CropImage(System.Drawing.Image image, int width, int height)
    {
        #region Tính toán tỉ lệ
        int sourceWidth = image.Width;
        int sourceHeight = image.Height;
        int sourceX = 0;
        int sourceY = 0;

        double nScaleW = 0;
        double nScaleH = 0;

        if (width <= 0 && height <= 0) { throw new Exception("width <= 0 && height <= 0"); }

        if (height <= 0) { height = (int)((width * sourceHeight) / (double)sourceWidth); }
        if (width <= 0) { width = (int)((height * sourceWidth) / (double)sourceHeight); }

        nScaleW = ((double)width / (double)sourceWidth);
        nScaleH = ((double)height / (double)sourceHeight);



        if (nScaleW < nScaleH)
        {
            sourceWidth = (int)((width * image.Height) / (double)height);
            sourceX = (int)((image.Width - sourceWidth) / (double)2);
        }
        else
        {
            sourceHeight = (int)((height * image.Width) / (double)width);
            sourceY = (int)((image.Height - sourceHeight) / (double)2);
        }


        #endregion

        System.Drawing.Bitmap bmPhoto = new System.Drawing.Bitmap(width, height);

        using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
        {
            grPhoto.InterpolationMode = InterpolationMode.Default;
            grPhoto.CompositingQuality = CompositingQuality.Default;
            grPhoto.SmoothingMode = SmoothingMode.Default;

            Rectangle to = new System.Drawing.Rectangle(0, 0, width, height);
            Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
            grPhoto.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);

            return bmPhoto;
        }
    }
