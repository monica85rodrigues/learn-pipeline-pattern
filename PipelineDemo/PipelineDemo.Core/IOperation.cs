namespace PipelineDemo.Core
{
    using System.Threading.Tasks;

    public interface IOperation<TMessage>
    {
        void Register(IOperation<TMessage> filter);
        Task Execute(TMessage context);
    }
}
