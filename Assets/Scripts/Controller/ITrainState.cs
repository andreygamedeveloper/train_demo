using System;

public interface ITrainState
{
    IDisposable Init(TrainMachine machine);
}
