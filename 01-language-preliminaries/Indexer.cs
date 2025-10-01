namespace LearningUtsav
{
    class Indexes
    {
        private string[] values = new string[3];
        // indexer declration
        public string this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }
    }
}