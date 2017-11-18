namespace iTextSharp.text.html.Extras
{

    internal class CellWidth
    {
        public CellWidth()
        {
        }

        public CellWidth(float width)
        {
            Width = width;
            ColSpan = 1;
        }

        public CellWidth(float width, int colSpan)
        {
            Width = width;
            ColSpan = colSpan;
        }


        public float Width { get; set; }

        public int ColSpan { get; set; }
    }

}