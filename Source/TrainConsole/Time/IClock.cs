namespace TrainConsole
{
    public interface IClock
    {
        public string Time { get; set; }
        public int Ticks { get; set; }
        public void Tick();
    }
}
