namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] _seeds;

        private string[] _names; 

        public IList<String> Seeds
        {
            get => _seeds.ToList();
            set => _seeds = value.ToArray();
        }

        public IList<String> Names
        {
            get => _names.ToList();
            set => _names = value.ToArray();
        }

        public int DeckSize => _names.Length * _seeds.Length;
        

        public ISet<Card> Deck
        {
            get
            {
                if (this._names == null || this._seeds == null)
                {
                    throw new InvalidOperationException();
                }

                return new HashSet<Card>(Enumerable
                    .Range(0, this._names.Length)
                    .SelectMany(i => Enumerable
                        .Repeat(i, this._seeds.Length)
                        .Zip(
                            Enumerable.Range(0, this._seeds.Length),
                            (n, s) => Tuple.Create(this._names[n], this._seeds[s], n)))
                    .Select(tuple => new Card(tuple))
                    .ToList());
            }
        }
    }
}
