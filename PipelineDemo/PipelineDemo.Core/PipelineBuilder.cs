namespace PipelineDemo.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PipelineBuilder<TMessage>
    {
        private IList<Func<IOperation<TMessage>>> filters = new List<Func<IOperation<TMessage>>>();

        public PipelineBuilder<TMessage> Register(Func<IOperation<TMessage>> filter)
        {
            filters.Add(filter);
            return this;
        }

        public PipelineBuilder<TMessage> Register(IOperation<TMessage> filter)
        {
            filters.Add(() => filter);
            return this;
        }

        public IOperation<TMessage> Build()
        {
            var root = filters.First().Invoke();

            foreach (var filter in filters.Skip(1))
            {
                root.Register(filter.Invoke());
            }

            return root;
        }
    }
}
