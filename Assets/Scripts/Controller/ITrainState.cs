using System;

namespace Game.Controller
{
    public interface ITrainState
    {
        IDisposable Init(TrainMachine machine);
    }
}