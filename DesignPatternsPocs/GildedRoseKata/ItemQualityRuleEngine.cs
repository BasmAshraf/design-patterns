using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata
{
    public class ItemQualityRuleEngine
    {
        private List<RuleBase> _rules = new List<RuleBase>(); 
        public ItemQualityRuleEngine(List<RuleBase> rules)
        {
            _rules = rules;
        }

        public void ApplyRules(ItemProxy item)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(item))
                    rule.UpdateQuality(item);
            }
        }

        public class Builder
        {
            private  List<RuleBase> _rules = new List<RuleBase>();

            public Builder WithAgedBrieItemRule()
            {
                _rules.Add(new AgedBrieItemRule());
                return this;
            }

            public Builder WithBackStageItemRule()
            {
                _rules.Add(new BackstageItemRule());
                return this;
            }

            public Builder WithSulfurasItemRule()
            {
                _rules.Add(new SulfurasItemRule());
                return this;
            }

            public Builder WithConjuredItemRule()
            {
                _rules.Add(new ConjuredItemRule());
                return this;
            }
            public ItemQualityRuleEngine Build()
            {
                _rules.Add(new NormalItemRule());
                return new ItemQualityRuleEngine(_rules);
            }
        }
    }
}
