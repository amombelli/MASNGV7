using System.Drawing;
using System.Windows.Forms;

namespace TradeGrid
{
    public class ImageAndTextDgvCell : DataGridViewTextBoxColumn
    {
        private Image imageValue;
        private Size imageSize;

        public ImageAndTextDgvCell()
        {
            this.CellTemplate = new ImageAndTextCell();
        }

        public override object Clone()
        {
            ImageAndTextDgvCell c = base.Clone() as ImageAndTextDgvCell;
            c.imageValue = this.imageValue;
            c.imageSize = this.imageSize;
            return c;
        }

        public Image Image
        {
            get { return this.imageValue; }
            set
            {
                if (this.Image != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;

                    if (this.InheritedStyle != null)
                    {
                        Padding inheritedPadding = this.InheritedStyle.Padding;
                        this.DefaultCellStyle.Padding = new Padding(imageSize.Width,
                            inheritedPadding.Top, inheritedPadding.Right,
                            inheritedPadding.Bottom);
                    }
                }
            }
        }

        private ImageAndTextCell ImageAndTextCellTemplate => this.CellTemplate as ImageAndTextCell;
        internal Size ImageSize => imageSize;
    }

    public class ImageAndTextCell : DataGridViewTextBoxCell
    {
        private Image imageValue;
        private Size imageSize;

        public override object Clone()
        {
            ImageAndTextCell c = base.Clone() as ImageAndTextCell;
            c.imageValue = this.imageValue;
            c.imageSize = this.imageSize;
            return c;
        }

        public Image Image
        {
            get
            {
                if (this.OwningColumn == null ||
                    this.OwningTextAndImageColumn == null)
                {
                    return imageValue;
                }
                else if (this.imageValue != null)
                {
                    return this.imageValue;
                }
                else
                {
                    return this.OwningTextAndImageColumn.Image;
                }
            }
            set
            {
                if (this.imageValue != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;

                    Padding inheritedPadding = this.InheritedStyle.Padding;
                    this.Style.Padding = new Padding(imageSize.Width,
                        inheritedPadding.Top, inheritedPadding.Right,
                        inheritedPadding.Bottom);
                }
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds,
            Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
            object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // Paint the base content
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
                value, formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);

            if (this.Image != null)
            {
                // Draw the image clipped to the cell.
                System.Drawing.Drawing2D.GraphicsContainer container =
                    graphics.BeginContainer();

                graphics.SetClip(cellBounds);

                // ====> Recalculate Location to have a Middle alignment
                int verticalPosition = cellBounds.Y + ((cellBounds.Height / 2) - (this.Image.Height / 2));

                //todo esto lo modifique yo para centrar tambien la imagen pero si
                //int horizontalPosition = cellBounds.X + ((cellBounds.Width / 2) - (this.Image.Width / 2));
                //cellBounds.Location = new Point(horizontalPosition, verticalPosition);
                cellBounds.Location = new Point(cellBounds.X, verticalPosition);

                graphics.DrawImageUnscaled(this.Image, cellBounds.Location);

                graphics.EndContainer(container);

            }
        }
        //protected override void Paint(Graphics graphics, Rectangle clipBounds,
        //    Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
        //    object value, object formattedValue, string errorText,
        //    DataGridViewCellStyle cellStyle,
        //    DataGridViewAdvancedBorderStyle advancedBorderStyle,
        //    DataGridViewPaintParts paintParts)
        //{
        //    // Paint the base content
        //    base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
        //        value, formattedValue, errorText, cellStyle,
        //        advancedBorderStyle, paintParts);

        //    if (this.Image != null)
        //    {
        //        // Draw the image clipped to the cell.
        //        System.Drawing.Drawing2D.GraphicsContainer container =
        //            graphics.BeginContainer();

        //        graphics.SetClip(cellBounds);
        //        graphics.DrawImageUnscaled(this.Image, cellBounds.Location);

        //        graphics.EndContainer(container);
        //    }
        //}
        private ImageAndTextDgvCell OwningTextAndImageColumn => this.OwningColumn as ImageAndTextDgvCell;
    }
}