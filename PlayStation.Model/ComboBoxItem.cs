using System;

namespace PlayStation.Model
{
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public int GetValue()
        {
            return Convert.ToInt32(Value);
        }
    }
}
