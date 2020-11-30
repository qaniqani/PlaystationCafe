namespace PlayStation.Model
{
    public class KeyValueData
    {
        public KeyValueData(string Text)
        {
            text = Text;
            itemData = 0;
        }

        public KeyValueData(string Text, decimal ItemData)
        {
            text = Text;
            itemData = ItemData;
        }

        public decimal ItemData
        {
            get
            {
                return itemData;
            }
            set
            {
                itemData = value;
            }
        }

        public override string ToString()
        {
            return text;
        }

        public string text;
        public decimal itemData;
    }
}
