namespace TrainConsole
{
    public interface IClock
    {
        public string Time { get; set; }
        public void Tick();
    }
}
