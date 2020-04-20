using System.Collections.Generic;

namespace EugineFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        protected readonly IDataSaver manager = new SerializeDataSaver(); //DataBaseDataSaver()

        protected void Save<T>(List<T> item) where T: class 
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T: class
        {
            return manager.Load<T>();
        }
    }
}
