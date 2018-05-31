namespace PipelineDemo.Core
{
    using System;
    using System.Threading.Tasks;

    public abstract class Operation<TMessage> : IOperation<TMessage>
    {
        private IOperation<TMessage> next;

        public Task Execute(TMessage context)
        {
            return Execute(context, ctx => next == null
                  ? Task.CompletedTask
                  : next.Execute(ctx));
        }

        public void Register(IOperation<TMessage> filter)
        {
            if (next == null)
            {
                next = filter;
                return;
            }

            next.Register(filter);
        }

        protected abstract Task Execute(TMessage context, Func<TMessage, Task> next);
    }
}
