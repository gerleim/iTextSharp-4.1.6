namespace iTextSharp.text.html.Extras
{
    using System;
    using System.Collections.Generic;


    internal class CellWidths : List<CellWidth>
    {
        public int NumberOfEmpyWidths { get; set; }

        public float Sum { get; set; }

        public void Add(CellWidth cellWidth)
        {
            if (Math.Abs((int)(cellWidth.Width - (-1))) > 0.01) Sum += cellWidth.Width;
            else NumberOfEmpyWidths++;

            base.Add(cellWidth);
        }

        public void Add(float cellWidth)
        {
            Add(new CellWidth(cellWidth));
        }

        public void Add(float cellWidth, int colSpan)
        {
            Add(new CellWidth(cellWidth, colSpan));
        }

        public float[] GetRelativeWiths()
        {
            float[] relativeWidths100 = new float[Count];
            for (int i = 0; i < Count; i++)
            {
                if (Math.Abs((int)(this[i].Width - (-1))) > 0.01)
                    if (Sum <= 100) relativeWidths100[i] = this[i].Width / 100;
                    else relativeWidths100[i] = this[i].Width / Sum;
                else
                {
                    if (Sum <= 100) relativeWidths100[i] = (100 - Sum) / NumberOfEmpyWidths / 100;
                    else relativeWidths100[i] = Sum / NumberOfEmpyWidths / 100;
                }
            }

            return relativeWidths100;
        }
    }
}