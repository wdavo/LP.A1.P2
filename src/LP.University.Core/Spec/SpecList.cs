﻿using System.Collections.Generic;
using System.Linq;

namespace LP.University.Core.Spec
{
    public abstract class SpecList
    {
        private List<ISpec> _specs;

        protected List<ISpec> Specs
        {
            get
            {
                if (_specs == null)
                    _specs = Specifications()?.ToList() ?? new List<ISpec>();

                return _specs;
            }
        }

        public virtual string Description =>
            $"The following conditions must be satisfied:\n{string.Join("\n", Specs.Select(x => x.Description))}";

        protected abstract IEnumerable<ISpec> Specifications();

        public SpecListResult IsSatisfied()
        {
            var satisfied = true;
            var violations = new List<string>();

            foreach (var spec in Specs)
            {
                if (!spec.IsSatisfied())
                {
                    satisfied = false;
                    violations.Add(spec.Description);
                    break;
                }
            }

            var result = new SpecListResult(satisfied, violations);
            return result;

        }

        public class SpecListResult
        {
            private readonly List<string> _violations;

            public bool IsSatisifed { get; }
            public IEnumerable<string> Violations => _violations;

            public SpecListResult(bool isSatisfied, List<string> violations)
            {
                IsSatisifed = isSatisfied;
                _violations = violations;
            }

        }

    }
}
