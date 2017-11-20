namespace iTextSharp.text.html.Extras
{
    using System;
    using System.Collections.Generic;


    internal class CellWidths : List<CellWidth>
    {
        public int NumberOfEmpyWidths { get; set; }

        public float Sum { get; set; }

        public new void Add(CellWidth cellWidth)
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
            List<float> relativeWidths100 = new List<float>();

            for (int i = 0; i < Count; i++)
            {
                float currentWith;
                if (Math.Abs((int)(this[i].Width - (-1))) > 0.01)
                { 
                    if (Sum <= 100)
                        currentWith = this[i].Width / 100;
                    else
                        currentWith = this[i].Width / Sum;
                    }
                else
                {
                    if (Sum <= 100)
                        currentWith = (100 - Sum) / NumberOfEmpyWidths / 100;
                    else
                        currentWith = Sum / NumberOfEmpyWidths / 100;
                }

                float colspanWidth = currentWith / this[i].ColSpan;
                for (int colSpans = 1; colSpans <= this[i].ColSpan; colSpans++)
                {
                    relativeWidths100.Add(colspanWidth);
                }
            }

            return relativeWidths100.ToArray();
        }
    }
}