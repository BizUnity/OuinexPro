using OuinexPro.Bases.Interfaces;

namespace OuinexPro.Bases.Impl
{
    public class OHLC : IOHLC
    {
        public DateTime Time { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal Volumes { get; set; }
    }


    public class OHLCs : IOHLCs
    {
        private List<IOHLC> _list = new List<IOHLC>();

        public IReadOnlyList<IOHLC> Bars { get { return _list; } }

        public event BarAdded OnBarAdded;
        public event BarChanged OnBarChanged;

        public void AddBar(IOHLC bar)
        {
            _list.Add(bar);

            OnBarAdded?.Invoke(bar);
        }
    }
}
