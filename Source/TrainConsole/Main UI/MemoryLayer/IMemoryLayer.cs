using System.Collections.Generic;

namespace TrainConsole
{
    public interface IMemoryLayer
    {
        public List<IDrawable> Drawables { get; set; }
        public bool IsInDrawables(IDrawable drawable);
        public void TryAppend(IDrawable tryUnit);
    }
}
